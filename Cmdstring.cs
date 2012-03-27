using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    //Cmdstring class contains the cmdstring which usable for database queries.
    //Usually a query stand for the cmdstring and a fieldlist which contain the names of field which will processing.
    //If cmdstring needs one or more conditional information, it will concatenate.
    //We will specify every field in strings, instead of "*"-like queries, for safety reasons.
    //All string constant or static, because this way made possible call these strings without initialization.
    class Cmdstring
    {
        ////Groupboxes with cmds
        //public static string[] groupboxid_fieldlist = { "groupboxID" };
        //public const string groupboxid = "SELECT DISTINCT groupboxID FROM groupboxes_manifest";
        ////Controlboxes
        //public const string controlboxid = "SELECT DISTINCT groupboxID FROM controlmode";        
        ////Manifests, which belongs to a groupbox
        //public static string[] manifestid_fieldlist = { "manifestID" };
        //private const string manifestid1 = "SELECT manifestID FROM groupboxes_manifest WHERE groupboxID=";
        //public static string manifestid(string c1)
        //{
        //    return manifestid1 + c1;
        //}
        ////Groupboxes (and controlboxes) - this return a cmdstring, which query every groupboxes
        //public static string[] groupbox_fieldlist = { "groupboxID", "groupboxName", "groupboxOrder" };
        //private const string groupbox1 = "SELECT groupboxID, groupboxName, groupboxOrder "+
        //                                 "FROM groupboxes "+
        //                                 "WHERE groupboxID=";
        //public static string groupbox(string c1)
        //{
        //    return groupbox1+c1;
        //}
        ////ControlmodeID
        //public static string[] controlmodeid_fieldlist = { "controlmodeID" };
        //private const string controlmodeid1 = "SELECT controlmodeID FROM controlmode WHERE groupboxID=";
        //public static string controlmodeid(string c1)
        //{
        //    return controlmodeid1 + c1;
        //}

        ////Controlmode
        //public static string[] controlmode_fieldlist = { "controlmodeID", "controlmodeName", "controlmodeOrder", "controlmodeUp", "controlmodeDown", "controlmodeLeft", "controlmodeRight", "controlmodeStop", "controlmodeComment" };
        //private const string controlmode1 = "SELECT controlmodeID, controlmodeName, controlmodeOrder, controlmodeUp, controlmodeDown, controlmodeLeft, controlmodeRight, controlmodeStop, controlmodeComment " +
        //                                    "FROM controlmode " +
        //                                    "WHERE controlmodeID=";
        //public static string controlmode(string c1)
        //{
        //    return controlmode1 + c1;
        //}
        ////Cmds of a controlmode
        //public static string[] controlmode_cmds_fieldlist = { "controlmodeUp", "controlmodeDown", "controlmodeLeft", "controlmodeRight", "controlmodeStop" };
        //private const string controlmode_cmds1 = "SELECT controlmodeUp, controlmodeDown, controlmodeLeft, controlmodeRight, controlmodeStop "+
        //                                         "FROM controlmode "+
        //                                         "WHERE controlmodeID=";
        //public static string controlmode_cmds(string c1)
        //{
        //    return controlmode_cmds1+c1;
        //}
        //groupboxid
        public static string[] groupboxid_filedlist = {"groupboxID"};
        public static string groupboxid = "SELECT groupboxID FROM groupbox";
        //modeid
        public static string[] modeid_fieldlist = {"modeID" };
        private const string modeid1 = "SELECT modeID FROM mode WHERE groupboxID=";
        public static string modeid(string c1)
        {
            return modeid1+c1;
        }
        //cmditemid
        public static string[] cmditemid_fieldlist = { "cmditemID"};
        private const string cmditemid1 = "SELECT cmditemID FROM cmditem WHERE modeID=";
        public static string cmditemid(string c1)
        {
            return cmditemid1 + c1;
        }
        //cmdid
        public static string[] cmdid_fieldlist = { "cmdID" };
        private const string cmdid1 ="SELECT cmdID FROM cmditem WHERE cmditemID=";
        public static string cmdid(string c1)
        {
            return cmdid1 + c1;
        }
        //parameterid
        public static string[] parameterid_fieldlist = { "parameterID" };
        private const string parameterid1="SELECT parameterID FROM cmd_parameter WHERE cmdID=";
        public static string parameterid(string c1)
        {
            return parameterid1 + c1;
        }
        //parametervalue
        public static string[] parametervalue_fieldlist = { "parameterValue" };
        private const string parametervalue1="SELECT parameterValue "+
                                             "FROM cmditem_parameter "+
                                             "WHERE cmditemID= ";
        private const string parametervalue2=" AND parameterID=";
        public static string parametervalue(string c1, string c2)
        {
            return parametervalue1 + c1 + parametervalue2 + c2;
        }
        //parameteritemid
        public static string[] parameteritemid_fieldlist = { "parameteritemID" };
        private const string parameteritemid1 = "SELECT parameteritemID FROM parameteritem WHERE modeID=";
        public static string parameteritemid(string c1)
        {
            return parameteritemid1 + c1;
        }
        //Groupbox
        public static string[] groupbox_fieldlist = { "groupboxID", "groupboxName", "groupboxOrder", "groupboxType", "groupboxComment" };
        private const string groupbox1 = "SELECT groupboxID, groupboxName, groupboxOrder, groupboxType, groupboxComment " +
                                         "FROM groupbox "+
                                         "WHERE groupboxID=";
        public static string groupbox(string c1)
        {
            return groupbox1 + c1;
        }
        //Mode
        public static string[] mode_fieldlist = { "modeID", "modeName", "modeOrder", "modeComment" };
        private const string mode1 = "SELECT modeID, modeName, modeOrder, modeComment "+
                                     "FROM mode "+
                                     "WHERE modeID=";
        public static string mode(string c1)
        {
            return mode1 + c1;
        }
        //CmdItem
        public static string[] cmditem_fieldlist = { "cmditemID", "cmditemName", "cmditemOrder", "cmditemType", "cmditemComment" };
        private const string cmditem1 = "SELECT cmditemID, cmditemName, cmditemOrder, cmditemType, cmditemComment "+
                                       "FROM cmditem "+
                                       "WHERE cmditemID=";
        public static string cmditem(string c1)
        {
            return cmditem1 + c1;
        }
        //ParamItem
        public static string[] parameteritem_fieldlist = { "parameteritemID", "parameteritemName", "parameteritemOrder", "parameteritemType", "parameteritemComment", "parameterID", "parameterName", "parameterMin", "parameterMax", "parameterDefault", "parameterComment" };
        private const string parameteritem1 ="SELECT parameteritemID, parameteritemName, parameteritemOrder, parameteritemType, parameteritemComment, parameter.[parameterID], parameterName, parameterMin, parameterMax, parameterDefault, parameterComment "+
                                            "FROM parameteritem, parameter "+
                                            "WHERE parameteritem.[parameterID]=parameter.[parameterID] AND parameteritemID=";
        //private const string parameteritem1 = "SELECT parameteritemID, parameteritemName, parameteritemOrder, parameteritemType, parameteritemComment"+
        //                                      "FROM parameteritem"+
        //                                      "WHERE parameteritemID=";
        public static string parameteritem(string c1)
        {
            return parameteritem1 + c1; 
        }
        //Cmd - this return a cmdstring, which query one cmd
        public static string[] cmd_fieldlist = {"cmdID", "cmdName", "cmdByte", "cmdComment" };
        private const string cmd1 = "SELECT cmdID, cmdName, cmdByte,cmdComment " +
                                    "FROM cmd " +
                                    "WHERE cmdID=";
        public static string cmd(string c1)
        {
            return cmd1 + c1;
        }
        //Parameters which are belong to a cmd
        public static string[] parameters_cmdsid_fieldlist = { "parameter_cmdID" };
        private const string parameters_cmdsid1 = "SELECT parameter_cmdID FROM parameter_cmd WHERE cmdID=";
        public static string parameters_cmdsid(string c1)
        {
            return parameters_cmdsid1+c1;
            
        }
        //Parameter - this return a cmdstring, which query one parameter
        public static string[] parameter_fieldlist = { "parameterID", "parameterName", "parameterMin", "parameterMax", "parameterDefault", "parameterComment", "parameterOrder" };
        private const string parameter1 = "SELECT parameter.[parameterID], parameterName, parameterMin, parameterMax, parameterDefault, parameterComment, parameterOrder "+
                                          "FROM parameter, cmd_parameter "+
                                          "WHERE cmd_parameter.[parameterID]=parameter.[parameterID] AND "+
                                          "parameter.[parameterID]= ";
        private const string parameter2 = " AND cmdID=";
        public static string parameter(string c1, string c2)
        {
            return parameter1 + c1 + parameter2 + c2;
        }
        //Parameter2 - if parameter couldn't add to manifest_parameters table
        public static string[] parameter_fix_fieldlist = { "parameterID", "parameterName", "parameter_cmdOrder", "parameterMin", "parameterMax", "parameterDefault" };
        private const string parameter_fix1 = "SELECT parameters.[parameterID], parameterName, parameter_cmdOrder, parameterMin, parameterMax, parameterDefault " +
                                              "FROM parameter_cmd, parameters " +
                                              "WHERE parameter_cmd.[parameterID]=parameters.[parameterID] " +
                                              "AND parameter_cmd.[parameter_cmdID]=";
        public static string parameter_fix(string c1)
        {
            return parameter_fix1 + c1;
        }
        //Settings
        public static string[] settings_fieldlist = { "baudRate", "dataBits", "discardNull", "dtrEnable", "handShake", "parity", "parityReplace", "portName", "readBufferSize", "readTimeOut", "receivedBytesThreshold", "rtsEnable", "stopBits", "writeBufferSize", "writeTimeOut" };
        public static string settings ="SELECT baudRate, dataBits, discardNull, dtrEnable, handShake, parity, parityReplace, portName, readBufferSize, readTimeOut, receivedBytesThreshold, rtsEnable, stopBits, writeBufferSize, writeTimeOut " +
                                       "FROM settings";
        //SyntaxID
        public static string[] syntaxid_fieldlist = { "syntaxID" };
        public static string syntaxid = "SELECT syntaxID FROM syntax";
        //Syntax
        public static string[] syntax_fieldlist = { "syntaxID","syntaxOrder","syntaxType" };
        private const string syntax1 = "SELECT syntaxID, syntaxOrder, syntaxType FROM syntax WHERE syntaxID=";
        public static string syntax(string c1)
        {
            return syntax1 + c1;
        }
        //Sign
        public static string[] sign_fieldlist = { "signID", "signName", "signByte", "signComment" };
        private const string sign1 = "SELECT sign.[signID], signName, signByte, signComment "+
                                     "FROM sign, sign_syntax "+
                                     "WHERE sign.[signID]=sign_syntax.[signID] "+
                                     "AND syntaxID=";
        public static string sign(string c1)
        {
            return sign1 + c1;
        }
        //MetadataID
        public static string[] metadataid_fieldlist = { "metadataID" };
        public static string metadataid = "SELECT metadataID FROM metadata";
        //Metadata
        public static string[] metadata_fieldlist = { "metadataID", "metadataField", "metadataValue" };
        private const string metadata1 = "SELECT metadataID, metadataField, metadataValue "+
                                         "FROM metadata "+
                                         "WHERE metadataID=";
        public static string metadata(string c1)
        {
            return metadata1 + c1;
        }
        //dbCheck: this cmdstrings and fieldlist needed to chechking database integrity and compatibility
        public static string[] dbcheck_fieldlist = { "count(*)" };
        public static string[] dbcheck_tablelist = { "groupbox", "sqlite_sequence", "mode", "cmd", "parameter", "cmd_parameter", "cmditem", "cmditem_parameter", "parameteritem", "sign", "syntax", "sign_syntax", "settings", "metadata" };       
        public static string[] dbcheck_sql = 
        {
            "CREATE TABLE [groupbox] ([groupboxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [groupboxName] TEXT NOT NULL, [groupboxOrder] INTEGER NOT NULL, [groupboxType] TEXT NOT NULL, [groupboxComment] TEXT)",
            "CREATE TABLE sqlite_sequence(name,seq)",
            "CREATE TABLE [mode] ([modeID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [groupboxID] INTEGER NOT NULL CONSTRAINT [groupboxID] REFERENCES [groupbox]([groupboxID]), [modeName] TEXT NOT NULL, [modeOrder] INTEGER, [modeComment] TEXT)",
            "CREATE TABLE [cmd] ([cmdID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdName] TEXT NOT NULL, [cmdByte] INTEGER NOT NULL, [cmdComment] TEXT)",
            "CREATE TABLE [parameter] ([parameterID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [parameterName] TEXT NOT NULL, [parameterMin] INTEGER, [parameterMax] INTEGER, [parameterDefault] INTEGER, [parameterComment] TEXT)",
            "CREATE TABLE [cmd_parameter] ([cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmd]([cmdID]), [parameterID] INTEGER NOT NULL CONSTRAINT [parameterID] REFERENCES [parameter]([parameterID]), [parameterOrder] INTEGER NOT NULL, PRIMARY KEY ([cmdID],[parameterID]))",
            "CREATE TABLE [cmditem] ([cmditemID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmd]([cmdID]), [modeID] INTEGER NOT NULL CONSTRAINT [modeID] REFERENCES [mode]([modeID]), [cmditemName] TEXT, [cmditemOrder] INTEGER NOT NULL, [cmditemType] TEXT NOT NULL, [cmditemComment] TEXT)",
            "CREATE TABLE [cmditem_parameter] ([cmditemID] INTEGER NOT NULL CONSTRAINT [cmditemID] REFERENCES [cmditem]([cmditemID]), [parameterID] INTEGER NOT NULL CONSTRAINT [parameterID] REFERENCES [parameter]([parameterID]), [parameterValue] INTEGER NOT NULL, PRIMARY KEY([cmditemID],[parameterID]))",
            "CREATE TABLE [parameteritem] ([parameteritemID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [parameterID] INTEGER NOT NULL CONSTRAINT [parameterID] REFERENCES [parameter]([parameterID]), [modeID] INTEGER NOT NULL CONSTRAINT [modeID] REFERENCES [mode]([modeID]), [parameteritemName] TEXT, [parameteritemOrder] INTEGER NOT NULL, [parameteritemType] TEXT NOT NULL, [parameteritemComment] TEXT)",
            "CREATE TABLE [sign] ([signID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [signName] TEXT NOT NULL, [signByte] INTEGER NOT NULL, [signComment] TEXT)",
            "CREATE TABLE [syntax] ([syntaxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [syntaxOrder] INTEGER NOT NULL UNIQUE, [syntaxType] TEXT NOT NULL)",
            "CREATE TABLE [sign_syntax] ([signID] INTEGER NOT NULL CONSTRAINT [signID] REFERENCES [sign]([signID]), [syntaxID] INTEGER NOT NULL CONSTRAINT [syntaxID] REFERENCES [syntax]([syntaxID]), PRIMARY KEY ([signID],[syntaxID]))",
            "CREATE TABLE [settings] ([settingsID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [baudRate] INTEGER, [dataBits] INTEGER, [discardNull] BOOLEAN, [dtrEnable] BOOLEAN, [handShake] INTEGER, [parity] INTEGER, [parityReplace] INTEGER, [portName] TEXT, [readBufferSize] INTEGER, [readTimeOut] INTEGER, [receivedBytesThreshold] INTEGER, [rtsEnable] BOOLEAN, [stopBits] INTEGER, [writeBufferSize] INTEGER, [writeTimeout] INTEGER)",
            "CREATE TABLE [metadata] ([metadataID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [metadataField] TEXT NOT NULL, [metadataValue] TEXT)"
        };
        private const string dbcheck1 = "SELECT count(*) "+
                                        "FROM sqlite_master "+
                                        "WHERE type='table' AND name='";
        public static string dbcheck(string c1)
        {
            return dbcheck1 + c1+"'";
        }
        public static string[] dbcheck_checktable_fieldlist = { "sql" };
        private const string dbcheck_checktable1 = "SELECT sql " +
                                                   "FROM sqlite_master " +
                                                   "WHERE type='table' AND name='";
        public static string dbcheck_checktable(string c1)
        {
            return dbcheck_checktable1 + c1+"'";
        }
        public static string[] dbcheck_integrity_fieldlist = { "integrity_check" };
        public static string dbcheck_integrity = "pragma integrity_check";
        public static string[] dbcheck_software_fieldlist = { "metadataValue" };
        public static string dbcheck_software = "SELECT metadataValue FROM metadata WHERE metadataID=1 AND metadataField='software';";
        //tbl_name
        public static string[] tbl_name_fieldlist = { "tbl_name" };
        public static string tbl_name = "SELECT tbl_name FROM sqlite_master WHERE type='table';";
        //sqlReader
        public static string[] sqlread_fieldlist = {"sql"};
        private const string sqlread1 = "SELECT sql FROM sqlite_master WHERE type='table' AND tbl_name='";
        public static string sqlread(string c1)
        {
            return sqlread1+c1+"'";
        }
    }
}
