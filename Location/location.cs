using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Location
{
    public class location
    {
        public static string output = "";//output to be sent to the UI viewer
        public static void runClient(string[] args)
        {
            try
            {
                string host = "whois.net.dcs.hull.ac.uk";  //default IP
                int port = 43;          //default port
                string httpType = "";
                int timeout = 3000;      //default timeout
                bool debugMode = false; //default debug mode position

                List<string> Args = new List<string>();
                for (int i = 0; i < args.Length; i++)
                {
                    Args.Add(args[i]);                      //copying the contends of the array into a list for ease of amending
                }
                if (Args.Contains("-d"))        //debug check
                {
                    debugMode = true;
                    Args.RemoveRange(Args.IndexOf("-d"), 1);
                }
                if (Args.Contains("-t"))        //timeout alter check
                {
                    timeout = int.Parse(Args[Args.IndexOf("-t") + 1]);
                    Args.RemoveRange(Args.IndexOf("-t"), 2);
                }   
                if (Args.Contains("-h"))        //host check
                {
                    host = Args[Args.IndexOf("-h") + 1];
                    Args.RemoveRange(Args.IndexOf("-h"), 2);
                }
                if (Args.Contains("-p"))        //port check
                {
                    port = int.Parse(Args[Args.IndexOf("-p") + 1]);
                    Args.RemoveRange(Args.IndexOf("-p"), 2);
                }
                if (Args.Contains("-h0"))       //http protocol check as follows        1.0
                {
                    httpType = "h0";
                    Args.RemoveAt(Args.IndexOf("-h0"));
                }
                if (Args.Contains("-h1"))           //1.1
                {
                    httpType = "h1";
                    Args.RemoveAt(Args.IndexOf("-h1"));
                }
                if (Args.Contains("-h9"))               //0.9
                {
                    httpType = "h9";
                    Args.RemoveAt(Args.IndexOf("-h9"));
                }
                string[] newArgs = new string[Args.Count];
                for (int i = 0; i < Args.Count; i++)
                {
                    newArgs[i] = Args[i];                   //copying the contents of the list into a new array
                }
                TcpClient client;
                StreamReader sr;
                StreamWriter sw;
                NetworkStream stream;

                if (debugMode)
                {
                    Console.WriteLine("Debug Mode");
                }
                switch (httpType)
                {
                    case "h0":
                        if (debugMode)
                        {
                            Console.WriteLine("HTTP 1.0");
                        }
                        client = new TcpClient();
                        client.Connect(host, port);
                        stream = client.GetStream();
                        stream.WriteTimeout = timeout;
                        stream.ReadTimeout = timeout;
                        if (newArgs.Length == 1)
                        {
                            byte[] send = Encoding.ASCII.GetBytes("GET /?" + newArgs[0] + " HTTP/1.0\r\n\r\n");     //expected 1.0 get request constructed and sent to the stream
                            stream.Write(send, 0, send.Length);
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);

                            List<string> words = new List<string>();
                            string tempresponse;
                            string response = "";
                            try
                            {
                                while ((tempresponse = sr.ReadLine()) != null)
                                {
                                    words.Add(tempresponse);                            //loop to copy the contents of the stream to a list which then joins to a single string
                                }
                                response = string.Join("\r\n", words);
                            }
                            catch (IOException)
                            {
                                if (words.Count > 0)
                                {
                                    response = string.Join("\r\n", words);              //the contents of the list still get sent to the string even if an exception occurs within the try

                                }
                            }

                            if (response.Contains("\r\n\r\n"))
                            {
                                response = response.Substring(response.LastIndexOf("\r\n\r\n"));        //cutting out the locatoin should there be one to avoid long full response 
                            }
                            Console.WriteLine(newArgs[0] + " is " + response.Trim());       //console output
                            output = newArgs[0] + " is " + response.Trim();             //output to UI list
                        }
                        else
                        {
                            byte[] send = Encoding.ASCII.GetBytes("POST /" + newArgs[0] + " HTTP/1.0\r\nContent-Length: " + newArgs[1].Length + "\r\n\r\n" + newArgs[1] + "\r\n");
                            stream.Write(send, 0, send.Length);         //construction of expected 1.0 post request
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);

                            List<string> words = new List<string>();
                            string tempresponse;
                            string response = "";
                            try
                            {
                                while ((tempresponse = sr.ReadLine()) != null)
                                {
                                    words.Add(tempresponse);                    //same as above, words added to a list to be joined as string
                                }
                                response = string.Join("\r\n", words);
                            }
                            catch (IOException)
                            {
                                if (words.Count > 0)
                                {
                                    response = string.Join("\r\n", words);

                                }
                            }
                            Console.WriteLine(newArgs[0] + " location changed to be " + newArgs[1]);            //console output
                            output = newArgs[0] + " location changed to be " + newArgs[1];              //UI output
                        }
                        client.Close();
                        stream.Close();
                        break;

                    case "h1":
                        if (debugMode)
                        {
                            Console.WriteLine("HTTP 1.1");
                        }
                        client = new TcpClient();
                        client.Connect(host, port);
                        stream = client.GetStream();
                        stream.WriteTimeout = timeout;
                        stream.ReadTimeout = timeout;
                        if (newArgs.Length == 1)
                        {
                            byte[] send = Encoding.ASCII.GetBytes("GET /?name=" + newArgs[0] + " HTTP/1.1\r\nHost: " + host + "\r\n\r\n");      //1.1 get request construction
                            stream.Write(send, 0, send.Length);
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);
                            if (host == "threethinggame.com")               //this code was needed for lab 3. to print out the contents from threethinggame.com
                            {
                                string words = "";
                                try
                                {

                                    int x;
                                    while ((x = sr.Read()) > 0)
                                    {
                                        words += (char)x;
                                    }
                                }
                                catch { }
                                words = words.Substring(words.IndexOf("\r\n\r\n")).Trim();
                                Console.Write(newArgs[0] + " is " + words);
                            }
                            else
                            {       //not threethinggame

                                List<string> words = new List<string>();
                                string tempresponse;
                                string response = "";
                                try
                                {
                                    while ((tempresponse = sr.ReadLine()) != null)
                                    {
                                        words.Add(tempresponse);                //same as above, added to list then joined
                                    }
                                    response = string.Join("\r\n", words);
                                }
                                catch (IOException)
                                {
                                    if (words.Count > 0)
                                    {
                                        response = string.Join("\r\n", words);

                                    }
                                }
                                if (response.Contains("\r\n\r\n"))
                                {
                                    response = response.Substring(response.LastIndexOf("\r\n\r\n"));
                                }
                                Console.WriteLine(newArgs[0] + " is " + response.Trim());//console output
                                output = newArgs[0] + " is " + response.Trim();         //UI output

                            }
                        }
                        else
                        {
                            byte[] send = Encoding.ASCII.GetBytes("POST / HTTP/1.1\r\nHost: " + host + "\r\nContent-Length: " + (newArgs[1].Length + newArgs[0].Length + 15) + "\r\n\r\nname=" + newArgs[0] + "&location=" + newArgs[1]);
                            stream.Write(send, 0, send.Length);         //construction of expected 1.1 Post request
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);

                            List<string> words = new List<string>();
                            string tempresponse;
                            string response = "";
                            try
                            {
                                while ((tempresponse = sr.ReadLine()) != null)
                                {
                                    words.Add(tempresponse);        //again, words to list to string. 
                                }
                                response = string.Join("\r\n", words);
                            }
                            catch (IOException)
                            {
                                if (words.Count > 0)
                                {
                                    response = string.Join("\r\n", words);

                                }
                            }
                            Console.WriteLine(newArgs[0] + " location changed to be " + newArgs[1]);  //console output
                            output = newArgs[0] + " location changed to be " + newArgs[1];      //UI output
                        }
                        client.Close();
                        stream.Close();
                        break;

                    case "h9":
                        if (debugMode)
                        {
                            Console.WriteLine("HTTP 0.9");
                        }
                        client = new TcpClient();
                        client.Connect(host, port);
                        stream = client.GetStream();
                        stream.WriteTimeout = timeout;
                        stream.ReadTimeout = timeout;
                        if (newArgs.Length == 1)
                        {
                            byte[] send = Encoding.ASCII.GetBytes("GET /" + newArgs[0] + "\r\n"); //constructon of expected 0.9 GET request
                            stream.Write(send, 0, send.Length);
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);

                            List<string> words = new List<string>();
                            string tempresponse;
                            string response = "";
                            try
                            {
                                while ((tempresponse = sr.ReadLine()) != null)
                                {
                                    words.Add(tempresponse);        //words to list to string
                                }
                                response = string.Join("\r\n", words);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                if (words.Count > 0)
                                {
                                    response = string.Join("\r\n", words);

                                }
                            }
                            if (response.Contains("\r\n\r\n"))
                            {
                                response = response.Substring(response.LastIndexOf("\r\n\r\n"));
                            }
                            Console.WriteLine(newArgs[0] + " is " + response.Trim());
                            output = newArgs[0] + " is " + response.Trim();

                        }
                        else
                        {
                            byte[] send = Encoding.ASCII.GetBytes("PUT /" + newArgs[0] + "\r\n\r\n" + newArgs[1] + "\r\n");  //expected 0.9 request PUT constructed
                            stream.Write(send, 0, send.Length);
                            stream.Flush();
                            if (debugMode)
                            {
                                string sentPost = Encoding.Default.GetString(send);
                                Console.WriteLine("Post sent: " + sentPost);
                            }
                            sr = new StreamReader(stream);

                            List<string> words = new List<string>();
                            string tempresponse;
                            string response = "";
                            try
                            {
                                while ((tempresponse = sr.ReadLine()) != null)
                                {
                                    words.Add(tempresponse);  //list to string
                                }
                                response = string.Join("\r\n", words);
                            }
                            catch (IOException)
                            {
                                if (words.Count > 0)
                                {
                                    response = string.Join("\r\n", words);

                                }
                            }
                            Console.WriteLine(newArgs[0] + " location changed to be " + newArgs[1]);
                            output = newArgs[0] + " location changed to be " + newArgs[1];
                        }
                        client.Close();
                        stream.Close();
                        break;

                    default:    //not http protocol. WHOIS
                        if (debugMode)
                        {
                            Console.WriteLine("WHOIS");
                        }
                        client = new TcpClient();
                        client.Connect(host, port);
                        sw = new StreamWriter(client.GetStream());
                        sr = new StreamReader(client.GetStream());
                        client.SendTimeout = timeout;
                        client.ReceiveTimeout = timeout;

                        if (newArgs.Length < 1 || newArgs.Length > 2)   //invalid number of inputs would be less than 1 and more than 2
                        {
                            Console.WriteLine("Please enter a valid number of arguments.");
                        }
                        else
                        {
                            if (newArgs.Length == 1)        //if the length is 1, the request would be a GET
                            {
                                sw.WriteLine(newArgs[0]);
                                sw.Flush();
                                if (debugMode)
                                {
                                    Console.WriteLine("Post sent: " + newArgs[0]);
                                }

                                List<string> words = new List<string>();
                                string tempresponse;
                                string response = "";
                                try
                                {
                                    while ((tempresponse = sr.ReadLine()) != null)
                                    {
                                        words.Add(tempresponse);
                                    }
                                    response = string.Join("\r\n", words);
                                }
                                catch (IOException)
                                {
                                    if (words.Count > 0)
                                    {
                                        response = string.Join("\r\n", words);

                                    }
                                }

                                Console.WriteLine(newArgs[0] + " is " + response); //console output
                                output = newArgs[0] + " is " + response;        //UI output
                            }
                            else
                            {       //else would be a POST request = args.length == 2
                                sw.WriteLine(newArgs[0] + " " + newArgs[1]);
                                sw.Flush();
                                if (debugMode)
                                {
                                    Console.WriteLine("Post sent: " + newArgs[0] + " " + newArgs[1]);
                                }

                                List<string> words = new List<string>();
                                string tempresponse;
                                string response = "";
                                try
                                {
                                    while ((tempresponse = sr.ReadLine()) != null)
                                    {
                                        words.Add(tempresponse);
                                    }
                                    response = string.Join("\r\n", words);
                                }
                                catch (IOException)
                                {
                                    if (words.Count > 0)
                                    {
                                        response = string.Join("\r\n", words);

                                    }
                                }
                                Console.WriteLine(newArgs[0] + " location changed to be " + newArgs[1]); //console out put
                                output = newArgs[0] + " location changed to be " + newArgs[1];  //UI output
                            }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}