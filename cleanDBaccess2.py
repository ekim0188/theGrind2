#!/usr/bin/env python3
"""
Created on Sun Oct 14 22:57:31 2018

@author: Mike Blake

Script to interact with the database itself
"""

#
import pymysql

def readDB(msg = []):
    print(msg)
##READ INFO FROM A DATABASE###    
    db = pymysql.connect('localhost', 'root', '[removed for security]', 'thegrind')
    cursor = db.cursor()
#prepare sql query to retrieve a record from the db
    sql = "SELECT * FROM userinfo"
    
    try:
#        execute the sql command
        cursor.execute(sql)
#        fetch all rows in a list of lists
        results = cursor.fetchall()
        print(results)
        for row in results:
            idnum = row[0]
            username = row[1]
            email = row[2]
            password = row[3]
            achiev = row[4]
            if (msg[0] == username) and (msg[1] == password):
                print("MATCH")
                return True
            else:
                return False
#        print fetched list
#            print("idnum: {0}, username: {1}, email: {2}, password: {3}, achiev: {4}".format(idnum, username,email, password, achiev))
    except:
        pass
#        print("Error: Unable to fetch data, sorry.")
#disconnect from server
    db.close()
    