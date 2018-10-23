# -*- coding: utf-8 -*-
"""
Michael Blake
9/21/18 Started
10/2/18 Finished
File monitoring program to detect and report changes in files of a filesystem.
"""

import sys, os, time

PATHLIST = []
FILESTATS = {}
cmpPATHLIST = []
cmpFILESTATS = {}

def detectCommand():
    '''Determine the user's input'''
    command = input("Please enter the command you wish to run if known, otherwise enter 'help'.\n")    
    if command == 'help':
        print("The available commands are:\nRun-Check the file directory for changes against the initial log, or create a log if this is the first run\nConstantRun-Run every [SET A TIME] to monitor for changes\nDisplayLog-Print out the logged file data along with a key to understand which stat is which for files \n")
    elif command == 'run':
        run()
    elif command == 'constantrun':
        constantRun()
    elif command == 'displaylog':
        displayLog()            
    elif command == 'exit':
        sys.exit()
    else:
        print("\nUnrecognized command. Please enter 'help' for available options.\n")

def run():
    '''Run one time. Mainly for the initial run to create the first log'''
    global FILESTATS
    global cmpFILESTATS
    if len(FILESTATS) == 0:
        files2watch()
        getStats()
        createLog()
        logFile()
        print('\nContents log has been created\n')
    else:
        check = input('Log already exists. \nWould you like to run an integrity check? (y)es/(n)o: ')
        if check == 'y':
            files2watchnow()
            getStatsCmp()
            logCmp()
            changes(FILESTATS, cmpFILESTATS, PATHLIST, cmpPATHLIST)
            pass
        elif check == 'n':
            pass
        else:
            print("Invalid choice, please attempt the 'run' command again.\n")

def constantRun():
    files2watch()
    getStats()
    createLog()
    logFile()
    print('\nContents log has been created\n')
    while True:
        files2watchnow()
        getStatsCmp()
        logCmp()
        changes(FILESTATS, cmpFILESTATS, PATHLIST, cmpPATHLIST)
        time.sleep(10)

def files2watch():
    '''Creates list of full-path of contents of current directory and every subdirectory to use 
    with initial log'''
    global PATHLIST
    list_dirs = os.walk('.')
    breakdown = []
    for i in list_dirs:
        breakdown.append(i)      
    polished = []
    for i in breakdown: 
        polished.append([i[0],i[2]])
    pathlist = []
    for i in polished:
        for file in i[1]:
            pathlist.append(i[0]+'/'+file)
    for i in pathlist:
        PATHLIST.append(i)       
              
def createLog():
    '''Check for initial log file for admin to read, create if doesn't exist'''
    global PATHLIST
    for file in PATHLIST:
        getStats()

def displayLog():
    '''Print the file names and statistics from the logged data for the user to read'''
    global FILESTATS
    print('\nFile stats are: Full path [type & permissions, inode num, device, number of hard links, \nuser ID of the file owner, group ID of the file owner, size in bytes, last access time in sec, last modification time in sec, last metadata change]\n')
    if len(FILESTATS) > 0:
        for k in FILESTATS.keys():
            print(k, FILESTATS[k])
    else:
        print("\nNo log exists yet. Please perform the initial 'run' command\n")
    
def getStats():  #TODO modify to accept any pathlist and any stats dictionary
    '''Enter lstat command for every file in list of paths into the stat dict'''
    global FILESTATS
    global PATHLIST
    for file in PATHLIST:
        a = os.lstat(file)
        statList = [a[0],a[1],a[2],a[3],a[4],a[5],a[6],a[7],a[8], a[9]]
        FILESTATS[file] = statList

def getStatsCmp():
    global cmpFILESTATS
    global cmpPATHLIST
    for file in cmpPATHLIST:
        a = os.lstat(file)
        statList = [a[0],a[1],a[2],a[3],a[4],a[5],a[6],a[7],a[8], a[9]]
        cmpFILESTATS[file] = statList

def files2watchnow():#TODO modify to accept any pathlist
    '''Create the list of current sub/directories to compare to the initial log'''
    global cmpPATHLIST
    list_dirs = os.walk('.')
    breakdown = []
    for i in list_dirs:
        breakdown.append(i)      
    polished = []
    for i in breakdown: 
        polished.append([i[0],i[2]])
    pathlist = []
    for i in polished:
        for file in i[1]:
            pathlist.append(i[0]+'/'+file)
    for i in pathlist:
        cmpPATHLIST.append(i)  
   
def logFile():
    with open('initLog.txt', 'w') as initLog:
        initLog.write(str(FILESTATS))
    initLog.close()

def logCmp():
    with open('newLog.txt','w') as newLog:
        newLog.write(str(cmpFILESTATS))
    newLog.close()

def changes(statlist1, statlist2, pathlist1, pathlist2):
    diff = 0
    diffList = []
    
    for key in statlist1.keys():
        if key == './initLog.txt':
            continue
        if statlist1[key] == statlist2[key]:
            continue
        elif statlist1[key] != statlist2[key]:
            diff += 1
            diffList.append(key)
    if (diff != 0) and (len(diffList) > 1):
        print('\nThe file(s) that changed include: ', diffList, '\n')
        print('list1:\n', statlist1)
        print('\n\nlist2:\n',statlist2)
    else:
        print('\nNo changes to report.\n')
#    if len(pathlist1) == len(pathlist2):
#        pass
#    elif len(pathlist1) < len(pathlist2):
#        print("A file or directory has been added!")
#    elif len(pathlist1) > len(pathlist2): 
#        print("A file or directory has been removed!")
     
    
if __name__ == '__main__':
    while True:
        detectCommand()
#    pass
     #https://docs.python.org/3/library/os.html#os.stat_result
#    print('a[0], st_mode = ', a[0])    #file type and mode bits(permissions)
#    print('a[1], inode num = ', a[1])  #Platform dependent, if non-zero, IDs file for a given value of st_dev
#    print('a[2], st_dev = ', a[2])     #device file resides on
#    print('a[3], st_nlink = ', a[3])   #num hard links
#    print('a[4], st_uid = ', a[4])     #user id of file owner
#    print('a[5], st_gid = ', a[5])     #group id of the file owner
#    print('a[6], st_size = ', a[6])    #file size in bytes; if regular file ot symLink
#    print('a[7], st_atime = ', a[7])   #last time accesses in seconds
#    print('a[8], st_mtime = ', a[8])   #last time modified in seconds
#    print('a[9], st_ctime = ', a[9])   #Platform dependent, last metadata change on unix, creation time on windows
   