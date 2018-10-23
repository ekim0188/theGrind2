using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

/*
 * Sends the username and password to listener which interacts with the database to verify login info
 * */

public class saveCredentials : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void submitCredentials()
	{
		string name = GameObject.Find("usernameInput").GetComponent<InputField> ().text;
		string password = GameObject.Find ("passwordInput").GetComponent<InputField> ().text;
		string storeNum = GameObject.Find ("storeNumInput").GetComponent<InputField> ().text;
		string creds = name + "." + password + "." + storeNum;
		//print ("Saving credentials-  name: " + name + ", password: " + password + ", store number: " + storeNum);
		//print (creds);	
		StartClient (creds);
		//StartServer ();
		}

	public static void StartClient(string toSend)  
	{  
		byte[] bytes = new byte[1024];  

		try  
		{  
			// Connect to a Remote server  
			// Get Host IP Address that is used to establish a connection  
			// In this case, we get one IP address of localhot that is IP : 127.0.0.1  
			// If a host has multiple addresses, you will get a list of addresses  
			IPHostEntry host = Dns.GetHostEntry("localhost");  
			IPAddress ipAddress = host.AddressList[0];  
			IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);  

			// Create a TCP/IP  socket.    
			Socket sender = new Socket(ipAddress.AddressFamily,  
				SocketType.Stream, ProtocolType.Tcp);  

			// Connect the socket to the remote endpoint. Catch any errors.    
			try  
			{  
				// Connect to Remote EndPoint  
				sender.Connect(remoteEP);  

				//replacement of print("Socket connected to {0}",sender.RemoteEndPoint.ToString());
				string conn = sender.RemoteEndPoint.ToString();
				print("Socket connected to " + conn);
				//print("Socket connected to {0}",                //CHANGING ALL CONSOLE.WRITELINE->PRINT SINCE
				//	sender.RemoteEndPoint.ToString());                     //INSIDE UNITY

				// Encode the data string into a byte array.    
				byte[] msg = Encoding.ASCII.GetBytes(toSend + "<EOF>");  

				// Send the data through the socket.    
				int bytesSent = sender.Send(msg);  

				// Receive the response from the remote device.    
				int bytesRec = sender.Receive(bytes);  

				//replacement of print("Echoed test = {0}",Encoding.ASCII.GetString(bytes, 0, bytesRec));
				string message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
				print("Echoed test = " + message);  

				// Release the socket.    
				sender.Shutdown(SocketShutdown.Both);  
				sender.Close();  

			}  
			catch (ArgumentNullException ane)  
			{  
				var anestr = ane.ToString();
				print("ArgumentNullException : " + anestr);
				//print("ArgumentNullException : {0}", ane.ToString());  
			}  
			catch (SocketException se)  
			{  
				var sestr = se.ToString();
				print("ArgumentNullException : " + sestr);
				//print("SocketException : {0}", se.ToString());  
			}  
			catch (Exception e)  
			{  
				var estr = e.ToString();
				print("ArgumentNullException : " + estr);
				//print("Unexpected exception : {0}", e.ToString());  
			}  

		}  
		catch (Exception e)  
		{  
			print(e.ToString());  
		}  
	}  
	/*
	public static void StartServer()
	{
		//Get Host IP addr that is used to establish a connection
		//In this case, we get one IP Addr of localhost that is IP: 127.0.0.1
		//If host has multiple addresses, you will get a list of addresses
		IPHostEntry host = Dns.GetHostEntry("localhost");
		IPAddress ipAddress = host.AddressList [0];
		IPEndPoint localEndPoint = new IPEndPoint (ipAddress, 12000);

		try{
			//Create socket that will use tcp protocol
			Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			//Sockets must be associated with an endpoint using the Bind method
			listener.Bind(localEndPoint);
			//specify how many requests a socket can listen for before it gives Server busy response
			//10 at a time
			listener.Listen(10);

			print("Waiting for a connection.....");
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
			print("Text received : "+ data);

			byte[] msg = Encoding.ASCII.GetBytes(data);
			handler.Send(msg);
			//handler.Shutdown(SocketShutdown.Both);
			//handler.Close();
		}
		catch (Exception e) 
		{
			print (e.ToString ());
		}
		print ("\n Press any key to continue.....");
		//Console.ReadKey ();

	}
*/
}  