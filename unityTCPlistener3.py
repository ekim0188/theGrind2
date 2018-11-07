# -*- coding: utf-8 -*-
"""
TCP listener for unity. 'TheGrind'.
"""
import socket, sys, os, threading, cleanDBaccess3, newUserReg

#ACTIVATE THESE LINES FOR TESTING
serverPort = 10011    

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)       #can handle I-net IPV4/V6, and is TCP based
server.bind(('0.0.0.0', serverPort))              #bind socket to hostname tuple (localMachine, selectedPort)socket.gethostname()
server.listen(50)    
connections = []                                             #numConnections allowed before server stop accepting new requests
print('Server is waiting for contact...\n')
print(socket.gethostname(), serverPort)

#Function to handle a connection once its made
def handler(c, a):
    print("in handler")
    global connections                                                   #make the global variable the one used inside the function
    print('The connection is {0}, and the address is {1}'.format(c, a))  #to display that portNums are different
    string = c.recv(1024).decode()
    string = string.lower()
    string = string.split('.')
    if string[-1] == '<EOF>':
        string = string[:-1]
    print(string)
    if string == ['']:
        print('here')
    if len(string) == 2:
        #checkDB(string)                #TODO: possibly remove this, double checking 
        user = string[0]
        pw = string[1]
        string = [user, pw]
        check = cleanDBaccess3.readDB(string)  
        print(check)                     
        if check == True:
            c.send("1".encode())
        if check == False:
            c.send("0".encode())
    elif len(string) == 6:
        uname = string[0]
        confirmUname = string[1]
        pw = string[2]
        confirmPW = string[3]
        email = string[4]
        confirmEmail = string[5]
        string = [uname, confirmUname, pw, confirmPW, email, confirmEmail]
        response = newUserReg.newUser(string)
        print("Response is: " + str(response))
        c.send(str(response).encode())
        accept()
    else:
        pass

def checkDB(creds):        #TODO: remove double check
    print("in checkDB")
    user = creds[0]
    pw = creds[1]
    creds = [user, pw]
    check = cleanDBaccess2.readDB(creds)                       
    if check == True:
        c.send("1".encode())
    if check == False:
        c.send("0".encode())
    pass

def accept():    
    while True:
        (c, a) = server.accept()                                       #c = connection, a = address   THIS ACCEPTS OUTSIDE CONNECTIONS
        cThread = threading.Thread(target=handler, args=(c, a))      #sets which function is passed into the thread, with arg tuple (c, a)
        cThread.daemon = True                                        #makes it so program can be killed whether theres a thread open or not
        cThread.start()                                              #start the thread
        connections.append(c)

if __name__ == '__main__':
    accept()