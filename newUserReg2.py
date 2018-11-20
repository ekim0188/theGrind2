# -*- coding: utf-8 -*-
"""
Created on Sat Nov  3 22:08:51 2018
Script to sanitize and insert a new user into the database
@author: xu-744
"""

import pymysql, insert

def newUser(msg = []):
    print(msg)
    db = pymysql.connect('localhost', 'server', '[removed for security]', 'thegrind')
    cursor = db.cursor()
    sql = "SELECT * FROM userinfo"
    try:
        cursor.execute(sql)
        results = cursor.fetchall()
        print(results)
        idnum = 0
        uname = 1
        email = 2
        pw = 3
        achiev = '00000000'
        users = []
        emails = []
        pws = []
        for idx in results:
            print(idx[idnum])
        for idx in results:
            users.append(idx[uname])
        for idx in results:
            emails.append(idx[email])
        for idx in results:
            pws.append(idx[pw])
        print(users, '\n', emails, '\n', pws)
        if msg[0]!=msg[1]:  #if uname and confirmUname dont match
            print('Uname error')
            return 1
        if msg[2]!=msg[3]:  #if emails dont match
            print('Email error')
            return 2
        if msg[4]!=msg[5]:   #is passwords dont match
            print('Password error')
            return 3
        if msg[0] in users:    #if user in table
            print('Invalid Uname')
            return 4
        if msg[2] in emails:   #if email in table
            print('Invalid Email')
            return 5
        if msg[4] in pws:      #if password in table
            print('Invalid Pass')
            return 6
        insert.insert(msg[0], msg[2], msg[4], achiev)
    except:
        pass
    db.close()
    return 0  #successful entry into table
