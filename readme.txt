Folder contents are as follow;

Location
	location.cs		//initial client code
	program.cs		//class to hold main method for program
	client.cs		//code for client UI
	client.designer.cs	//generated code from UI design
LocationServer
	locationserver.cs	//initial server code
	program.cs		//class to hold main method for program
	server.cs		//code for serverUI
	server.designer.cs	//generated code from UI design

Server log file found in the debug folder of LocationServer

Client should be fully funtional including UI. Debug information will be printed to the console. 
Client timeout is set to 3 seconds, 2 seconds causes a timeout on GET requests. Unsure if it's the network or potential inefficiency. 

Server has all base features. There is code for threading within the .cs file however threading runs into errors (null object exception).
"Update Viewer" within the server UI not functional
loading users from a saved file upon loading the UI currently not functional
Save button saves user data into "UserData.txt" in the debug folder

Client will load with user interface if no arguments are given. Otherwise it can be ran without
Server will run with a user interface with ran with the argument "-w". Otherwise it will run in command prompt.