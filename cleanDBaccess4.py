#!/usr/bin/env python3
"""
Created on Sun Oct 14 22:57:31 2018

@author: Mike Blake

Script to interact with the database itself
"""

import pymysql

def readDB(msg = []):
    print(msg)
    db = pymysql.connect('localhost', 'server', '[removed for security]', 'thegrind')
    cursor = db.cursor()
    sql = "SELECT * FROM userinfo"
    try:
        cursor.execute(sql)
        results = cursor.fetchall()
        print(results)
        for row in results:
            idnum = row[0]
            username = row[1]
            email = row[2]
            password = row[3]
            achiev = row[4]
            if (msg[0] == username) and (msg[1] == password):
                print('SUCCESS: msg[0] is : ', msg[0], '\n', 'msg[1] is: ', msg[1])
                return True
            elif (msg[0] != username) or (msg[1] != password):
                print('FAIL: msg[0] is : ', msg[0], '\n', 'msg[1] is: ', msg[1])
                continue
            else:
                print("User not in database!")
                return False
    except:
        pass
    db.close()

