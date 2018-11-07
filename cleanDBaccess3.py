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
                del idnum, username, email, password
                print('SUCCESS: msg[0] is : ', msg[0], '\n', 'msg[1] is: ', msg[1])
                return True
            else:
                print('FAIL: msg[0] is : ', msg[0], '\n', 'msg[1] is: ', msg[1])
                continue
    except:
        pass
#        print("Error: Unable to fetch data, sorry.")

#disconnect from server
    db.close()
    