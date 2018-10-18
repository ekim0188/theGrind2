#!/usr/bin/env python3
"""
Created on Sun Oct 14 22:57:31 2018

@author: Mike Blake

Script to constantly run and await receiving data from Unity to interact with the database within the server
"""

import socket, sys, os, time, cleanDBaccess #TODO: implement threading

connections = []

serverPort = 31000

rcvSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)       #UDP based
rcvSock.bind((socket.gethostname(), serverPort))              #bind socket to hostname tuple (localMachine, selectedPort)  
print('Receiver is waiting for contact....\n')


###############SERVER MAIN LOOP################### 
while True:
    data = None
    try:  #to get msg from socket
        (data, addr) = rcvSock.recvfrom(4096, socket.MSG_DONTWAIT)   #non-blocking, continues whileLoop if no msg
        if data:
            print('Received message')
            msg = data.decode().split('.')
#            print(msg)
            check = cleanDBaccess.readDB(msg)
            if check == True:
                print("Logged In")
                rcvSock.sendto("You have been logged in!".encode(), addr)
                break
            else:
                print("Login unsuccessful.")
                rcvSock.sendto("Login unsuccessful. Please try again.".encode(), addr)
                break
            
    except socket.error as e:
        pass
    time.sleep(1)
