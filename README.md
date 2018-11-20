# theGrind2

10/24/18 MB
 -Uploaded cleanDBaccess2.py, cleanUnityTCPListener.py, loginScene-Scene1.unity, loggedIn-Scene2.unity, and saveCredentials-2.cs. 
 cleanDBaccess2.py queries the database to determine if login credentials are correct.
 cleanUnityTCPListener is a tcp socket to accept a connection from Unity, which sends a string of login credentials.
 loginScene-Scene1.unity takes username and password from user to be sent to the server and database for verification.
 loggedIn-Scene2.unity will be the beginning point for gameplay.
 saveCredentials-2.cs saves the users login information then opens a socket and sends the information to the server socket. The function to advance the scene based on credentials is embedded here. 

10/25/18 MB
-Uploaded the login scene with the proper background which will be used in the final version, loginSceneWithProperBG-Scene1.unity.

11/19/18 MB
-Uploaded:
failedLogin.unity -error screen informing user that their login credentials are invalid
newReg.untiy -registration screen for new users, user info is checked against the database and input parameters, then inserted into the database if valid
registrationScreen.unity -initial entry screen, needs to be renamed to entry screen, and graphics need to be improved on unless a status text is included on the
        login screen, or a different method of user notification is used

unityTCPlistener6.py -functions properly, allowing a new user to register and an existing user to log in. Redirects user to invalid login screen if
        user login credentials are invalid; this is just a clean, uncommented version of 5
cleanDBaccess4.py -funcions properly, accepting user credentials and checking them against the database to determine if credentials are valid entries
        in the database; clean uncommented version of 3
newUserReg2.py -receives data from the user registration screen, checks the database to determine if the new registration information is already
        contained within the database, and ensures all the proposed information matches its confirmation counterpart;clean uncommented version of 1
insert2.py -function to insert the users new information into the database;clean uncommented version of 1
fileMonitor9.py -retrieves all filenames in a directory, retrieves conplete inode information about the list, processes all subdirectories' contents, writes the
        information into a file, detecting changes in the files and storing the information in a way that is useful to the user
goToReg.cs -C# script to take the user to the registration page

