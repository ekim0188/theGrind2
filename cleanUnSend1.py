#!/usr/bin/env python3 
"""
Created on Sun Oct 14 22:57:31 2018

@author: Mike Blake

Script to run when called, will take the data from unity's login screen and send to the receiver program in the server so it can access the database and return whether the user credentials are valid or not
"""

import socket, sys, os, time # TODO: implement threading

serverName = socket.gethostname()      #change to ip address of server machine for testing directly to a given machine
serverPort = 31000
serverAddr = (serverName, serverPort)

sendSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)    #create socket
sendSock.settimeout(10)  #TESTING THIS, NOT 100% YET

info = input("Enter your username, password, and store number as username.password: ")
#sendSock.sendto(info.encode(), serverAddr)
#print('login sent')



def transmitData(info = 'string'):
#    print('printing input info: ', info)
    sendSock.sendto(info.encode(), serverAddr)
    print('sent')
    (data, addr) = sendSock.recvfrom(4096)
    msg = data.decode()
    print(msg)

if __name__ == '__main__':
    transmitData(info)
