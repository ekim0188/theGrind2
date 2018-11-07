# -*- coding: utf-8 -*-
"""
Created on Sat Nov  3 23:15:27 2018
Script to enter user info into the mysql database
@author: xu-744
"""
import pymysql

def insert(uname, email, pw, achiev):
    db = pymysql.connect('localhost', 'root', '[removed for security]', 'thegrind', autocommit=True)
    cursor = db.cursor()
    print(uname, '\n', email, '\n', pw, '\n', achiev)
    sql = "insert into userinfo(username, email, password, achiev) values('"+uname+"','"+ email+"','"+pw+"', '00000000')"
    cursor.execute(sql)
    db.close()