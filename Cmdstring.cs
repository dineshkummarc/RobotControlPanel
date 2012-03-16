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
        //Groupboxes with cmds
        public static string[] groupboxid_fieldlist = { "groupboxID" };
        public const string groupboxid = "SELECT DISTINCT groupboxID FROM groupboxes_manifest";
        //Controlboxes
        public const string controlboxid = "SELECT DISTINCT groupboxID FROM controlmode";        
        //Manifests, which belongs to a groupbox
        public static string[] manifestid_fieldlist = { "manifestID" };
        private const string manifestid1 = "SELECT manifestID FROM groupboxes_manifest WHERE groupboxID=";
        public static string manifestid(string c1)
        {
            return manifestid1 + c1;
        }
        //Groupboxes (and controlboxes) - this return a cmdstring, which query every groupboxes
        public static string[] groupbox_fieldlist = { "groupboxID", "groupboxName", "groupboxOrder" };
        private const string groupbox1 = "SELECT groupboxID, groupboxName, groupboxOrder "+
                                         "FROM groupboxes "+
                                         "WHERE groupboxID=";
        public static string groupbox(string c1)
        {
            return groupbox1+c1;
        }
        //ControlmodeID
        public static string[] controlmodeid_fieldlist = { "controlmodeID" };
        private const string controlmodeid1 = "SELECT controlmodeID FROM controlmode WHERE groupboxID=";
        public static string controlmodeid(string c1)
        {
            return controlmodeid1 + c1;
        }

        //Controlmode
        public static string[] controlmode_fieldlist = { "controlmodeID", "controlmodeName", "controlmodeOrder", "controlmodeUp", "controlmodeDown", "controlmodeLeft", "controlmodeRight", "controlmodeStop", "controlmodeComment" };
        private const string controlmode1 = "SELECT controlmodeID, controlmodeName, controlmodeOrder, controlmodeUp, controlmodeDown, controlmodeLeft, controlmodeRight, controlmodeStop, controlmodeComment " +
                                            "FROM controlmode " +
                                            "WHERE controlmodeID=";
        public static string controlmode(string c1)
        {
            return controlmode1 + c1;
        }
        //Cmds of a controlmode
        public static string[] controlmode_cmds_fieldlist = { "controlmodeUp", "controlmodeDown", "controlmodeLeft", "controlmodeRight", "controlmodeStop" };
        private const string controlmode_cmds1 = "SELECT controlmodeUp, controlmodeDown, controlmodeLeft, controlmodeRight, controlmodeStop "+
                                                 "FROM controlmode "+
                                                 "WHERE controlmodeID=";
        public static string controlmode_cmds(string c1)
        {
            return controlmode_cmds1+c1;
        }
        //Cmd - this return a cmdstring, which query one cmd
        public static string[] cmd_fieldlist = {"cmdID", "cmdName", "cmdByte", "manifestType", "manifestComment" };
        private const string cmd1 = "SELECT cmds.[cmdID], cmdName, cmdByte, manifestType, manifestComment "+
                                    "FROM cmds, manifest "+
                                    "WHERE manifest.[cmdID]=cmds.[cmdID] AND manifest.[manifestID]=";
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
        public static string[] parameter_fieldlist = { "parameterID", "parameterName", "parameter_cmdOrder", "parameterMin", "parameterMax", "parameterDefault", "manifest_parameterValue", "manifest_parameterType", "manifest_parameterComment" };
        private const string parameter1 = "SELECT parameters.[parameterID], parameterName, parameter_cmdOrder, parameterMin, parameterMax, parameterDefault, manifest_parameterValue, manifest_parameterType, manifest_parameterComment " +
                                        "FROM parameter_cmd, parameters, manifest_parameter " +
                                        "WHERE parameter_cmd.[parameterID]=parameters.[parameterID] " +
                                        "AND manifest_parameter.[parameter_cmdID]=parameter_cmd.[parameter_cmdID] " +
                                        "AND parameter_cmd.[parameter_cmdID]=";
        private const string parameter2 = " AND manifest_parameter.[manifestID]=";
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
        private const string sign1 = "SELECT signs.[signID], signName, signByte, signComment "+
                                     "FROM signs, sign_syntax "+
                                     "WHERE signs.[signID]=sign_syntax.[signID] "+
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
    }
}
