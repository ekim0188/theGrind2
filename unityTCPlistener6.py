# -*- coding: utf-8 -*-
"""
TCP listener for unity. 'TheGrind'.
TODO: Add length and keyword checking
"""
import socket, sys, os, threading, cleanDBaccess3, newUserReg

#ACTIVATE THESE LINES FOR TESTING
serverPort = 10013    

#none of these mysql or python keywords should be in user input
pyKeywords = 'falsenonetrueandasassertbreakclasscontinuedefdelelifelseexceptfinallyforfromglobalifimportinislambdanonlocalnotorpassraisereturntrywhilewithyield'
mysqlKeywords = 'accessibleaccountactionaddafteragainstaggregatealgorithmallalteralwaysanalyseanalyzeandanyasascasciiasensitiveatautoextend_sizeauto_incrementavgavg_row_lengthbackupbeforebeginbetweenbigintbinarybinlogbitblobblockboolbooleanbothbtreebybytecachecallcascadecascadedcasecatalog_namechainchangechangedchannelcharcharactercharsetcheckchecksumcipherclassoriginclientclosecoalescecodecollatecollationcolumncolumnscolumn_formatcolumn_namecommentcommitcommittedcompactcompletioncompressedcompressionconcurrentconditionconnectionconsistentconstraintconstraint_catalogconstraint_nameconstraint_schemacontainscontextcontinueconvertcpucreatecrosscubecurrentcurrent_datecurrent_timecurrent_timestampcurrent_usercursorcursor_namedatadatabasedatabasesdatafilefatedatetimedayday_hourday_microsecondday_minuteday_seconddeallocatedecdecimaldeclaredefaultdefault_authdefinerdelayeddelay_key_writedeletedescdescribedes_key_filedeterministicdiagnosticsdirectorydisablediscarddiskdistinctdistinctrowdivdodoubledropdualdumpfileduplicatedynamiceachelseelseifenableenclosedencryptionendendeengineenginesenumerrorerrorsescapeescapedeventeventseveryexchangeexecuteexistsexitexpansionexpireexplainexportextendedextent_sizefalsefastfaultsfetchfieldsfilefile_block_sizefilterfirstfixedfloatfloat4float8flushfollowsforforceforeignformatfoundfromfullfulltextfunctiongeneralgeneratedgeometrygeometrycollectiongetget_formatglobalgrantgrantsgroupgroup_replicationhandlerhashhavinghelphigh_priorityhosthostshourhour_microsoundhour_minutehour_secondidentifiedifignoreignore_server_idsimportinindexindexesinfileinitial_sizeinnerinoutinsensitiveinsertinsert_methodinstallinstanceintint1int2int3int4int8integerintervalintoinvokerioio_after_gtidsio_before_gtidsio_threadipcisisolationissueriteratejoinjsonkeykeyskey_block_sizekilllanguagelastleadingleaveleavesleftlesslevellikelimitlinearlineslinestringlistloadlocallocaltimelocaltimestamplocklockslogfilelogslonglongbloblongtextlooplow_prioritymastermaster_auto_positionmaster_bindmaster_connect_retrymaster_delaymaster_heartbeat_periodmaster_hostmaster_log_filemaster_log_posmaster_passwordmaster_portmaster_retry_countmaster_server_idmaster_sslmaster_ssl_camaster_ssl_capathmaster_ssl_certmaster_ssl_ciphermaster_ssl_crlmaster_ssl_crlpathmaster_ssl_keymaster_ssl_verify_server_certmaster_tls_versionmaster_usermatchmaxvaluemax_connections_per_hourmax_queries_per_hourmax_rowsmax_sizemax_statement_timemax_updates_per_hourmax_user_connectionsmediummediumblobmediumintmemorymergemessage_textmicrosecondmiddleintmigrateminuteminute_microsecondminute_secondmin_rowsmodmodemodifiesmodifymonthmultilinestringmultipointmultipolygonmutexmysql_errnonamenamesnationalnaturalncharndbndbclusternevernewnextnonodegroupnonblockingnonenotno_waitno_write_to_binlognullnumbernumericnvarcharoffsetold_passwordononeonlyopenoptimizeoptimizer_costsoptionoptionallyoptionsororderoutouteroutfileownerpack_keyspageparserparse_gcol_exprpartialpartitionpartitioningpartitionspasswordphrasepluginpluginsplugin_dirpointpolygonportprecedesprecisionprepareprevprimaryprivilegesprocedureprocesslistprofileprofilesproxypurgequarterqueryquickrangereadreadsread_onlyread_writerealrebuildrecoverredofileredo_buffer_sizeredundantreferencesregexprelayrelaylogrelay_log_filerelay_log_posrelay_log_threadreleasereloadremoverenamereorganizerepairrepeatrepeatablereplacereplicate_do_dbreplicate_do_tablereplicate_ignore_dbreplicate_ignore_tablereplicate_rewrite_dbreplicate_wild_do_tablereplicate_wild_ignore_tablereplicationrequireresetresignalrestorerestrictresumereturnreturned_sqlstatereturnsreverserevokerightrlikerollbackrolluprotaterowrowsrow_countrow_formatrtreesavepointscheduleschemaschemasschema_namesecondsecond_microsecondsecurityselectsensitiveseparatorserialserializableserversessionsetshareshowshutdownsignalsignedsimpleslaveslowsmallintsnapshotsocketsomesonamesoundssourcespatialspecificsqlsqlexceptionsqlstatesqlwarningsql_after_gtidssql_after_mts_gapssql_before_gtidssql_big_resultssql_buffer_resultsql_cachesql_calc_found_rowssql_no_cachesql_small_resultsql_threadsql_tsi_daysql_tsi_hoursql_tsi_minutesql_tsi_monthsql_tsi_quartersql_tsi_secondsql_tsi_weeksql_tsi_yearsslstackedstartstartingstartsstats_auto_calcstats_persistentstats_sample_pagesstatusstopstoragestoredstraight_joinstringsubclass_originsubjectsubpartitionsubpartitionssupersuspendswapsswitchestabletablestablespacetable_checksumtable_nametemporarytemptableterminatedtextthanthentimetimestamptimestampaddtimestampdifftinyblobtinyinttinytexttotrailingtransactiontriggertriggerstruetruncatetypetypesuncommittedundefinedundoundofileundo_buffer_sizeunicodeuninstallunionuniqueunknownunlockunsigneduntilupdateupgradeusageuseuseruser_resourcesuse_frmusingutc_dateutc_timeutc_timestampvalidationvaluevaluesvarbinaryvarcharvarcharactervariablesvaryingviewvirtualwaitwarningsweekweight_stringwhenwherewhilewithwithoutworkwrapperwritex509xaxidxmlxoryearyear_monthzerofillaccountalwayschannelcompressionencryptionfile_block_sizefilterfollowsgeneratedgroup_replicationinstancejsonmaster_tls_versionneveroprimizer_costsparse_gcol_exprprecedesreplicate_do_dbrotatestackedstoredvalidationvirtualwithoutxid'

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)       #can handle I-net IPV4/V6, and is TCP based
server.bind(('0.0.0.0', serverPort))              #bind socket to hostname tuple (localMachine, selectedPort)socket.gethostname()
server.listen(50)    
connections = []                                             #numConnections allowed before server stop accepting new requests
print('Server is waiting for contact...\n')
print(socket.gethostname(), serverPort)

#Function to handle a connection once its made
def handler(c, a):
    global connections                                                   #make the global variable the one used inside the function
    print('The connection is {0}, and the address is {1}'.format(c, a))  #to display that portNums are different
    string = c.recv(1024).decode()
    string = string.lower()
    string = string.split('.')
    if string[-1] == '<eof>':
        string = string[:-1]
    #DEBUGGING, FIXED
    if string == ['']:
        print('here')
    if len(string) == 2:
        user = string[0]
        pw = string[1]
        string = [user, pw]
        check = cleanDBaccess3.readDB(string) #determine if user credentials are valid
        #IF CREDENTIALS NOT IN DATABASE, NONE BROKE THE LISTENER,
        #SET TO FALSE TO RETURN PROPER INVALID LOGIN SCENE
        if check == None:
            check = False
        if check == True:
            c.send("1".encode())
        if check == False:
            c.send("0".encode())
    #if 6, new user registration is called
    elif len(string) == 6: 
        uname = string[0]
        confirmUname = string[1]
        pw = string[2]
        confirmPW = string[3]
        email = string[4]
        confirmEmail = string[5]
        string = [uname, confirmUname, pw, confirmPW, email, confirmEmail]
        response = newUserReg.newUser(string)
        c.send(str(response).encode())
        accept()
    else:
        pass


def accept():    
    while True:
        (c, a) = server.accept()                                     #c = connection, a = address   THIS ACCEPTS OUTSIDE CONNECTIONS
        cThread = threading.Thread(target=handler, args=(c, a))      #sets which function is passed into the thread, with arg tuple (c, a)
        cThread.daemon = True                                        #makes it so program can be killed whether theres a thread open or not
        cThread.start()                                              #start the thread
        connections.append(c)

if __name__ == '__main__':
    accept()
