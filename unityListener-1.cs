﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

//Socket listener acts as a server and listens to the incoming
//messages on the specified port and protocol

public class SocketListener

{
	public static int Main(String[] args)
	{
		StartServer ();
		return 0;
	}

	public static void StartServer()
	{
		//Get Host IP addr that is used to establish a connection
		//In this case, we get one IP Addr of localhost that is IP: 127.0.0.1
		//If host has multiple addresses, you will get a list of addresses
		IPHostEntry host = Dns.GetHostEntry("localhost");
		IPAddress ipAddress = host.AddressList [0];
		IPEndPoint localEndPoint = new IPEndPoint (ipAddress, 11000);

		try{
			//Create socket that will use tcp protocol
			Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			//Sockets must be associated with an endpoint using the Bind method
			listener.Bind(localEndPoint);
			//specify how many requests a socket can listen for before it gives Server busy response
			//10 at a time
			listener.Listen(10);

			Console.WriteLine("Waiting for a connection.....");
			Socket handler = listener.Accept();

			//Incoming data from the client
			string data = null;
			byte[] bytes = null;

			while(true)
			{
				bytes = new byte[1024];
				int bytesRec = handler.Receive(bytes);
				data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
				if(data.IndexOf("<EOF>") > -1)
				{
					break;
				}

			}

			Console.WriteLine("Text received : {0}", data);

			//Call function to check database, returns 1 or 0
			string answer = CheckDatabase(data);

			byte[] msg = Encoding.ASCII.GetBytes(answer);
			handler.Send(msg);
			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
		}
		catch (Exception e) 
		{
			Console.WriteLine (e.ToString ());
		}

		//Console.WriteLine ("\n Press any key to continue.....");
		//Console.ReadKey ();   //removed so no button must be pressed to continue on the server end
	}



	public static string CheckDatabase(string credentials)
	{
		string positive = "YES";
		string negative = "NO";


		return positive;
	}

}