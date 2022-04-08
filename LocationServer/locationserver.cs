using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace Locationserver
{
    public class locationserver
    {
        public static ConcurrentDictionary<string, string> userData;
        public static StreamWriter fs;
        public static DateTime now;

        public static void Save()
        {
            StreamWriter sw = File.AppendText("UserData.txt");
            foreach (KeyValuePair<string, string> data in userData)
            {
                sw.WriteLine(data.Key + " " + data.Value);  //saving user data to the file
                sw.Flush();
            }
            sw.Close();
        }
        public static void Load()   //method does not get called, null object exception
        {
            string[] lines = File.ReadAllLines("UserData.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                userData.TryAdd(parts[0], parts[1]); //exception caused here
            }
        }
        public static void runServer(List<string> args)
        {
            string filePath = "ServerLog.txt";      //default log file path
            fs = File.AppendText(filePath);     //initialize fstream if path is changed by user
            now = DateTime.Now;     //setting datetime, used for server log
            bool debugMode = false;     //default debug mode position
            int timeout = 2000;     //default timeout
            int port = 43;      //default listening port
            if (args.Contains("-l"))                                //the following arguments are sent from the UI. without loading the program with the argument -w, these options are not available
            {
                filePath = args[args.IndexOf("-l") + 1];        //check for change in file path for log
            }
            if (args.Contains("-d"))
            {
                debugMode = true;       //debug move change check
            }
            if (args.Contains("-t"))
            {
                timeout = int.Parse(args[args.IndexOf("-t") + 1]);      //timeout change check
            }
            if (args.Contains("-p"))
            {
                port = int.Parse(args[args.IndexOf("-p") + 1]);     //port change check
            }
            if (debugMode)
            {
                Console.WriteLine("Debug Mode");
                fs.WriteLine("Debug Mode");
            }
            fs.WriteLine("Server ran at: " + now);      //log file addition to note when server was used
            Console.WriteLine("Timeout set to: " + timeout);
            Console.WriteLine("Listening on port: " + port);
            fs.WriteLine("Timeout set to: " + timeout + "\r\n" + "Listening on port: " + port);     //repeating the previous output for the benefit of the log
            fs.Flush();
            TcpListener listener;
            Socket connection;
            Handler handler;
            userData = new ConcurrentDictionary<string, string>();      //container for user information 

            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                Console.WriteLine("I'm listening...");
                while (true)
                {
                    connection = listener.AcceptSocket();
                    handler = new Handler();
                    Thread thread = new Thread(() => handler.doRequest(connection, userData, timeout, ref fs));     //this code for threading is here but a null object exception is thrown when trying to use multiple threads
                    thread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                fs.WriteLine("Error: " + e);
            }
            finally
            {
                fs.Close();
            }
        }
    }
    public class Handler
    {
        public void doRequest(Socket connection, ConcurrentDictionary<string, string> info, int timeout, ref StreamWriter fs)       //parameters sent are those that need editing within
        {
            NetworkStream socketStream;
            socketStream = new NetworkStream(connection);
            Console.WriteLine("Connection detected");
            fs.WriteLine("Connection detected");
            fs.Flush();
            try
            {
                StreamWriter sw = new StreamWriter(socketStream);
                StreamReader sr = new StreamReader(socketStream);
                socketStream.WriteTimeout = timeout;
                socketStream.ReadTimeout = timeout;

                string response = null;
                try
                {
                    int x;
                    while ((x = sr.Read()) > 0)
                    {
                        response += (char)x;        //reading the response a character at a time to the response string
                    }
                }
                catch { }
                fs.WriteLine("Recieved: " + response);
                fs.Flush();

                if (response.StartsWith("GET " + "/") || response.StartsWith("PUT " + "/") || response.StartsWith("POST " + "/"))//differenciating the requests, these would mean HTTP protocols
                {
                    if (response.Contains("HTTP/1.0")) //the response containing this string would say its a 1.0 http request
                    {
                        if (response.StartsWith("GET"))//starting with GET would assume its a GET request
                        {
                            int endOfNameIndex = 0;
                            for (int i = response.IndexOf('?'); i < response.Length; i++)   //this algorithm finds the index number of the response where the name ends
                            {
                                if (response[i] == ' ')
                                {
                                    endOfNameIndex = i - response.IndexOf('?');     //there will be a space in the response after the name, and a ? occurs beforehand. using this information i can get the index of the name itself
                                    break;
                                }
                            }
                            string name = response.Substring(response.IndexOf('?') + 1, endOfNameIndex).Trim(); //creating a string containing the name with the start position of ? and the found end postiion of the space character
                            if (info.ContainsKey(name))//if the name is already in the database
                            {
                                Console.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name] + "\r\n");
                                sw.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name] + "\r\n");      //responses writing to console, back to the client, and also the log file
                                sw.Flush();
                                fs.WriteLine("HTTP / 1.0 200 OK\r\nContent - Type: text / plain\r\n\r\n" + info[name] + "\r\n");
                                fs.Flush();
                            }
                            else
                            {
                                Console.Write("HTTP/1.0 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.0 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");     //responses writing to console, back to the client, and also the log file
                                sw.Flush();
                                fs.WriteLine("HTTP/1.0 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                        }
                        else //POST 
                        {
                            int endOfNameIndex = 0;
                            for (int i = response.IndexOf('/'); i < response.Length; i++)
                            {
                                if (response[i] == ' ')
                                {
                                    endOfNameIndex = i - response.IndexOf('/');     //again finding the name based on the fact the name starts after a / and ends before a space 
                                    break;
                                }
                            }
                            string name = response.Substring(response.IndexOf('/') + 1, endOfNameIndex).Trim();
                            string location = response.Substring(response.LastIndexOf("\r\n\r\n")).Trim(); //find the location from the response. which comes after 2 new lines 
                            int length = location.Trim().Length;//length of the locatin string found with .length
                            if (!info.ContainsKey(name))//if the database does not contain the name, meaning to add it
                            {
                                info.TryAdd(name, location);//using a concurrentdictionary, the tryadd method is used
                                Console.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Flush();
                                fs.WriteLine("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");        //writing to console, client, and ui
                                fs.Flush();
                            }
                            else
                            {
                                info[name] = location;//else meaning the name is already there, so the database should be updating with the new location
                                Console.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");        //writing to console, client and ui
                                sw.Flush();
                                fs.WriteLine("HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                        }
                    }
                    else if (response.Contains("HTTP/1.1"))
                    {
                        if (response.StartsWith("GET"))
                        {
                            string name = response.Substring(response.IndexOf('=') + 1, response.IndexOf("HTTP") - response.IndexOf('=') - 2); //an intersting line of code i used to single out the name among the string
                            if (info.ContainsKey(name))//contains name == return name
                            {
                                Console.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name] + "\r\n");
                                sw.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name] + "\r\n");      //printing to console, client and ui
                                sw.Flush();
                                fs.WriteLine("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name] + "\r\n");
                                fs.Flush();
                            }
                            else // no name in database
                            {
                                Console.Write("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");     //printing not found to console, client, ui
                                sw.Flush();
                                fs.WriteLine("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                        }
                        else //POST
                        {
                            string newResponse = response.Substring(response.IndexOf("name="));
                            string[] split = newResponse.Split('&');
                            string name = split[0].Substring(split[0].IndexOf('=') + 1);        //retreiving name and location from response
                            string location = split[1].Substring(split[1].IndexOf('=') + 1);
                            if (!info.ContainsKey(name)) // no name, add
                            {
                                info.TryAdd(name, location);
                                Console.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");        //write to console, client, ui
                                sw.Flush();
                                fs.WriteLine("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                            else//name there, update 
                            {
                                info[name] = location;
                                Console.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");        //write to console, client, ui
                                sw.Flush();
                                fs.WriteLine("HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                        }
                    }
                    else //http0.9
                    {
                        if (response.StartsWith("GET"))
                        {
                            string name = response.Substring(response.IndexOf('/') + 1);    //getting name from response
                            if (info.ContainsKey(name.Trim()))
                            {
                                Console.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name.Trim()] + "\r\n");
                                sw.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name.Trim()] + "\r\n");       //print to client, console, ui
                                sw.Flush();
                                fs.WriteLine("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n" + info[name.Trim()] + "\r\n");
                                fs.Flush();
                            }
                            else  //name not in database
                            {
                                Console.Write("HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");     //print to client, console, ui
                                sw.Flush();
                                fs.WriteLine("HTTP/0.9 404 Not Found\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                        }
                        else //PUT
                        {
                            string name = response.Substring(response.IndexOf('/') + 1, response.IndexOf("\r\n") - response.IndexOf('/') - 1); //retrieving name from reponse
                            string location = response.Substring(response.IndexOf("\r\n")).Trim();//getting location from response
                            if (!info.ContainsKey(name)) //name not in database = new entry
                            {
                                info.TryAdd(name, location);
                                Console.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");            //response to client, console, ui after adding
                                sw.Flush();
                                fs.WriteLine("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }
                            else  //name in database update entry
                            {
                                info[name] = location;
                                Console.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                sw.Write("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");        //outputs
                                sw.Flush();
                                fs.WriteLine("HTTP/0.9 200 OK\r\nContent-Type: text/plain\r\n\r\n");
                                fs.Flush();
                            }

                        }
                    }
                }
                else//standard WHOIS handler
                {
                    string[] words = response.Split(' ');
                    string name = words[0].Trim();
                    string gatherWords = "";
                    for (int i = 1; i < words.Length; i++)
                    {
                        gatherWords += words[i] + " ";//gatherwords is used to handle locations of multiple words without error
                    }
                    string location = gatherWords.Trim();
                    if (words.Length == 1)
                    {
                        //lookup code
                        if (info.ContainsKey(name))
                        {
                            //print information 
                            Console.WriteLine(info[name] + "\r\n");
                            sw.WriteLine(info[name] + "\r\n");
                            sw.Flush();
                            fs.WriteLine(info[name] + "\r\n");
                            fs.Flush();
                        }

                        else
                        {
                            Console.WriteLine("ERROR: no entries found\r\n");
                            sw.WriteLine("ERROR: no entries found\r\n");
                            sw.Flush();
                            fs.WriteLine("ERROR: no entries found\r\n");
                            fs.Flush();
                        }
                    }
                    else if (words.Length > 1)
                    {
                        //update code               
                        if (info.ContainsKey(name))
                        {
                            //update info
                            info[name] = location;
                            Console.WriteLine("OK\r\n");
                            sw.WriteLine("OK\r\n");
                            sw.Flush();
                            fs.WriteLine("OK\r\n");
                            fs.Flush();
                        }
                        else
                        {
                            //add to info
                            info.TryAdd(name, location);
                            Console.WriteLine("OK\r\n");
                            sw.WriteLine("OK\r\n");
                            sw.Flush();
                            fs.WriteLine("OK\r\n");
                            fs.Flush();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Server error: " + e);
                fs.WriteLine("Server error: " + e);
                fs.Flush();
            }
            finally
            {
                socketStream.Close();
                connection.Close();
            }
        }
    }
}