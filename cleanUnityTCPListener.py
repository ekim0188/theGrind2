# -*- coding: utf-8 -*-
"""
Created on Wed Oct 24 02:32:46 2018

@author: Mike Blake

Script to interact with the database itself
"""
import socket, sys, os, threading, cleanDBaccess2

#ACTIVATE THESE LINES FOR TESTING
serverPort = 8686

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)       #can handle I-net IPV4/V6, and is TCP based
server.bind(('0.0.0.0', serverPort))              #bind socket to hostname tuple (localMachine, selectedPort)
server.listen(5)    
connections = []                                             #numConnections allowed before server stop accepting new requests
print('Server is waiting for contact...\n')
print(socket.gethostname(), serverPort)

#Function to handle a connection once its made
def handler(c, a):
    global connections                                                   #make the global variable the one used inside the function
    print('The connection is {0}, and the address is {1}'.format(c, a))  #to display that portNums are different
    while True:                                                          #when handler is called, continuously
        string = c.recv(1024).decode()
        print(string)  #string is username.password, will be username.password.storeNum in the final version
        creds = string.split('.')
        user = creds[0]
        pw = creds[1]
#        storeNum = creds[2]
        creds = [user, pw]
        check = cleanDBaccess2.readDB(creds)                       
        if check == True:
            c.send("1".encode())
        if check == False:
            c.send("0".encode())
        break
        
while True:
    (c, a) = server.accept()                                       #c = connection, a = address   THIS ACCEPTS OUTSIDE CONNECTIONS
    cThread = threading.Thread(target=handler, args=(c, a))      #sets which function is passed into the thread, with arg tuple (c, a)
    cThread.daemon = True                                        #makes it so program can be killed whether theres a thread open or not
    cThread.start()                                              #start the thread
    connections.append(c)
