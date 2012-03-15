using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Cmdstring
    {
        //Groupboxes with cmds
        public static string[] groupboxid_fieldlist = { "groupboxID" };
        public const string groupboxid = "SELECT DISTINCT groupboxID FROM groupboxes_manifest";
        //Controlboxes
        public const string controlboxid = "SELECT DISTINCT groupboxID FROM controlmode";        
        //Manifests, which belongs to a groupbox
        public static string[] manifestid_fieldlist = {"manifestID" };
        private const string manifestid1 = "SELECT manifestID FROM groupboxes_manifest WHERE groupboxID=";
        public static string manifestid(string c1)
        {
            return manifestid1 + c1;
        }
        //Groupboxes (and controlboxes) - this return a cmdstring, which query every groupboxes
        public static string[] groupbox_fieldlist = { "groupboxID", "groupboxname" };
        private const string groupbox1 = "SELECT groupboxID, groupboxname "+
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
        public static string[] controlmode_fieldlist = { "controlmodeID", "controlmodeName", "controlmodeOrder", "controlmodeUp", "controlmodeDown", "controlmodeLeft", "controlmodeRight", "controlmodeStop" };
        private const string controlmode1 = "SELECT controlmodeID, controlmodeName, controlmodeOrder, controlmodeUp, controlmodeDown, controlmodeLeft, controlmodeRight, controlmodeStop " +
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
        public static string[] cmd_fieldlist = {"cmdID", "cmdName", "cmdByte", "manifestType" };
        private const string cmd1 = "SELECT cmds.[cmdID], cmdName, cmdByte, manifestType "+
                                    "FROM cmds, manifest "+
                                    "WHERE manifest.[cmdID]=cmds.[cmdID] AND manifest.[manifestID]=";
        public static string cmd(string c1)
        {
            return cmd1 + c1;
        }
        //Parameters which are belong to a cmd
        public static string[] parameters_cmdsid_fieldlist = {"parameters_cmdsID"};
        private const string parameters_cmdsid1 = "SELECT parameters_cmdsID FROM parameters_cmds WHERE cmdID=";
        public static string parameters_cmdsid(string c1)
        {
            return parameters_cmdsid1+c1;
            
        }
        //Parameter - this return a cmdstring, which query one parameter
        public static string[] parameter_fieldlist = { "parameterID", "parameterName", "parameters_cmdsOrder", "parameterMin", "parameterMax", "parameterDefault", "manifest_parametersValue", "manifest_parametersType" };
        private const string parameter1 = "SELECT parameters.[parameterID], parameterName, parameters_cmdsOrder, parameterMin, parameterMax, parameterDefault, manifest_parametersValue, manifest_parametersType " +
                                        "FROM parameters_cmds, parameters, manifest_parameters " +
                                        "WHERE parameters_cmds.[parameterID]=parameters.[parameterID] " +
                                        "AND manifest_parameters.[parameter_cmdsID]=parameters_cmds.[parameters_cmdsID] " +
                                        "AND parameters_cmds.[parameters_cmdsID]=";
        private const string parameter2 = " AND manifest_parameters.[manifestID]=";
        public static string parameter(string c1, string c2)
        {
            return parameter1 + c1 + parameter2 + c2;
        }
        //Parameter2 - if parameter couldn't add to manifest_parameters table
        public static string[] parameter_fix_fieldlist = { "parameterID", "parameterName", "parameters_cmdsOrder", "parameterMin", "parameterMax", "parameterDefault" };
        private const string parameter_fix1 = "SELECT parameters.[parameterID], parameterName, parameters_cmdsOrder, parameterMin, parameterMax, parameterDefault " +
                                              "FROM parameters_cmds, parameters " +
                                              "WHERE parameters_cmds.[parameterID]=parameters.[parameterID] " +
                                              "AND parameters_cmds.[parameters_cmdsID]=";
        public static string parameter_fix(string c1)
        {
            return parameter_fix1 + c1;
        }

        ////OLD SQL COMMANDS
        ////Multi-request, this sql-commands returns multiple values
        //public const string groupboxes = "SELECT * FROM groupboxes";
        //public const string normalgroupboxes = "SELECT DISTINCT groupboxID FROM groupboxes_manifest";
        //public const string controlboxes = "SELECT DISTINCT groupboxID FROM controlmode";
        //public const string groupboxes_manifest = "SELECT * FROM groupboxes_manifest";        
        //public const string manifest = "SELECT * FROM manifest";        
        //public const string cmds = "SELECT * FROM cmds";
        //public const string manifestid = "SELECT manifestID FROM groupboxes_manifest WHERE groupboxID=";
        //public const string parameters_cmds = "SELECT * FROM parameters_cmds";
        //public const string parameters_cmdsid = "SELECT parameters_cmdsID FROM parameters_cmds WHERE cmdID=";
        //public const string controlmodeid = "SELECT controlmodeID FROM controlmode WHERE groupboxID=";
        
        ////Single-request, this sql-commands returns single values
        //public const string groupboxname = "SELECT groupboxName FROM groupboxes WHERE groupboxID=";        
        //public const string cmdid = "SELECT cmdID FROM manifest WHERE manifestID=";
        //public const string manifesttype = "SELECT manifestType FROM manifest WHERE manifestID=";
        //public const string cmdname = "SELECT cmdName FROM cmds WHERE cmdID=";
        //public const string cmdbyte = "SELECT cmdByte FROM cmds WHERE cmdID=";
        //public const string parameterid = "SELECT parameterID FROM parameters_cmds WHERE parameters_cmdsID=";
        //public const string parameters_cmdsorder = "SELECT parameters_cmdsOrder FROM parameters_cmds WHERE parameters_cmdsID=";
        //public const string parametername = "SELECT parameterName FROM parameters WHERE parameterID=";
        //public const string parametermin = "SELECT parameterMin FROM parameters WHERE parameterID=";
        //public const string parametermax = "SELECT parameterMax FROM parameters WHERE parameterID=";
        //public const string parameterdefault = "SELECT parameterDefault FROM parameters WHERE parameterID=";
        //public const string manifest_parametersvalue = "SELECT manifest_parametersValue FROM manifest_parameters WHERE manifestID=";
        //public const string manifest_parameterstype = "SELECT manifest_parametersType FROM manifest_parameters WHERE manifestID=";
        //public const string controlmodename = "SELECT controlmodeName FROM controlmode WHERE controlmodeID=";
        //public const string controlmodeorder = "SELECT controlmodeOrder FROM controlmode WHERE controlmodeID=";
        //public const string controlmodeup = "SELECT controlmodeUp FROM controlmode WHERE controlmodeID=";
        //public const string controlmodedown = "SELECT controlmodeDown FROM controlmode WHERE controlmodeID=";
        //public const string controlmodeleft = "SELECT controlmodeLeft FROM controlmode WHERE controlmodeID=";
        //public const string controlmoderight = "SELECT controlmodeRight FROM controlmode WHERE controlmodeID=";
        //public const string controlmodeStop = "SELECT controlmodeStop FROM controlmode WHERE controlmodeID=";
    }
}
