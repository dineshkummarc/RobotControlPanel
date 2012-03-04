using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Cmdstring
    {
        //Multi-request, this sql-commands returns multiple values
        public const string groupboxes = "SELECT * FROM groupboxes";
        public const string normalgroupboxes = "SELECT DISTINCT groupboxID FROM groupboxes_manifest";        
        public const string groupboxes_manifest = "SELECT * FROM groupboxes_manifest";        
        public const string manifest = "SELECT * FROM manifest";        
        public const string cmds = "SELECT * FROM cmds";
        public const string manifestid = "SELECT manifestID FROM groupboxes_manifest WHERE groupboxID=";
        public const string parameters_cmds = "SELECT * FROM parameters_cmds";
        public const string parameters_cmdsid = "SELECT parameters_cmdsID FROM parameters_cmds WHERE cmdID=";
        
        //Single-request, this sql-commands returns single values
        public const string groupboxname = "SELECT groupboxName FROM groupboxes WHERE groupboxID=";        
        public const string cmdid = "SELECT cmdID FROM manifest WHERE manifestID=";
        public const string manifesttype = "SELECT manifestType FROM manifest WHERE manifestID=";
        public const string cmdname = "SELECT cmdName FROM cmds WHERE cmdID=";
        public const string cmdbyte = "SELECT cmdByte FROM cmds WHERE cmdID=";
        public const string parameterid = "SELECT parameterID FROM parameters_cmds WHERE parameters_cmdsID=";
        public const string parameters_cmdsorder = "SELECT parameters_cmdsOrder FROM parameters_cmds WHERE parameters_cmdsID=";
        public const string parametername = "SELECT parameterName FROM parameters WHERE parameterID=";
        public const string parametermin = "SELECT parameterMin FROM parameters WHERE parameterID=";
        public const string parametermax = "SELECT parameterMax FROM parameters WHERE parameterID=";
        public const string parameterdefault = "SELECT parameterDefault FROM parameters WHERE parameterID=";
        public const string manifest_parametersvalue = "SELECT manifest_parametersValue FROM manifest_parameters WHERE manifestID=";
        public const string manifest_parameterstype = "SELECT manifest_parametersType FROM manifest_parameters WHERE manifestID=";
    }
}
