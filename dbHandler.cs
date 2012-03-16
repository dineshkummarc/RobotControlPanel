using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RobotControlPanel
{
    interface IdbHandler
    {
        void SetdbPath(string dbPath);
        List<CmdGroup> readGroupboxList();
        List<Controlbox> readControlBoxList();
        Settings readSettings();
        List<Syntax> readSyntaxList();
        List<Metadata> readMetadataList();
    }
    class dbHandler : IdbHandler
    {
        private string dbPath;
        
        //SetdbPath: Set path of actually used database
        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }
        //readGroupboxList: return lists of groupboxes, 
        //every groupbox contains buttons or comboboxes, its linked to a command and that command's parameters
        public List<CmdGroup> readGroupboxList()
        {
            List<CmdGroup> groupboxlist = new List<CmdGroup>();
            int i = 0;
            foreach (object groupboxID in dbReader(Cmdstring.groupboxid, Cmdstring.groupboxid_fieldlist))
            {
                groupboxlist.Add(readGroupbox(groupboxID.ToString()));
                groupboxlist[i].cmdList = new List<Cmd>();
                int j = 0;
                foreach (object manifestID in dbReader(Cmdstring.manifestid(groupboxID.ToString()), Cmdstring.manifestid_fieldlist))
                {
                    groupboxlist[i].cmdList.Add(readCmd(manifestID.ToString()));
                    groupboxlist[i].cmdList[j].parameterList = new List<Parameter>();
                    foreach (object parameters_cmdsID in dbReader(Cmdstring.parameters_cmdsid(groupboxlist[i].cmdList[j].cmdID.ToString()), Cmdstring.parameters_cmdsid_fieldlist))
                    {
                        groupboxlist[i].cmdList[j].parameterList.Add(readParameter(parameters_cmdsID.ToString(), manifestID.ToString()));
                    }
                    j++;
                }
                i++;
            }
            return groupboxlist;
        }
        //readControBox: Return lists of controlboxes, which are special groupboxes contains five buttons (up, down, left, right, stop) 
        //and these buttons can have several commands (modes)
        public List<Controlbox> readControlBoxList()
        {
            List<Controlbox> controlboxList = new List<Controlbox>();
            int i = 0;
            foreach (object controlboxID in dbReader(Cmdstring.controlboxid, Cmdstring.groupboxid_fieldlist))
            {
                controlboxList.Add(readControlbox(controlboxID.ToString()));
                controlboxList[i].Modes = new List<ControlboxMode>();
                int j = 0;
                foreach (object controlmodeID in dbReader(Cmdstring.controlmodeid(controlboxID.ToString()), Cmdstring.controlmodeid_fieldlist))
                {
                    controlboxList[i].Modes.Add(readControlboxMode(controlmodeID.ToString()));
                    List<Cmd> cmdlist = readControlboxcmds(controlmodeID.ToString());
                    controlboxList[i].Modes[j].Up = cmdlist[0];
                    controlboxList[i].Modes[j].Down = cmdlist[1];
                    controlboxList[i].Modes[j].Left = cmdlist[2];
                    controlboxList[i].Modes[j].Right = cmdlist[3];
                    controlboxList[i].Modes[j].Stop = cmdlist[4];
                    j++;
                }
                i++;
            }
            return controlboxList;
        }
        //readSettings: return a property that define behavior of the connection
        public Settings readSettings()
        {
            Settings settings = new Settings();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.settings, Cmdstring.settings_fieldlist);
            if (values[0].GetType().ToString() != "System.DBNull") settings.baudRate = Convert.ToInt32(values[0]);
            if (values[1].GetType().ToString() != "System.DBNull") settings.dataBits = Convert.ToInt32(values[1]);
            if (values[2].GetType().ToString() != "System.DBNull") settings.discardNull = Convert.ToBoolean(values[2]);
            if (values[3].GetType().ToString() != "System.DBNull") settings.dtrEnable = Convert.ToBoolean(values[3]);
            if (values[4].GetType().ToString() != "System.DBNull") settings.handShake = Convert.ToInt32(values[4]);
            if (values[5].GetType().ToString() != "System.DBNull") settings.Parity = Convert.ToInt32(values[5]);
            if (values[6].GetType().ToString() != "System.DBNull") settings.parityReplace = Convert.ToInt32(values[6]);
            if (values[7].GetType().ToString() != "System.DBNull") settings.portName = values[7].ToString();
            if (values[8].GetType().ToString() != "System.DBNull") settings.readBufferSize = Convert.ToInt32(values[8]);
            if (values[9].GetType().ToString() != "System.DBNull") settings.readTimeOut = Convert.ToInt32(values[9]);
            if (values[10].GetType().ToString() != "System.DBNull") settings.receivedBytesThreshold = Convert.ToInt32(values[10]);
            if (values[11].GetType().ToString() != "System.DBNull") settings.rtsEnable = Convert.ToBoolean(values[11]);
            if (values[12].GetType().ToString() != "System.DBNull") settings.stopBits = Convert.ToInt32(values[12]);
            if (values[13].GetType().ToString() != "System.DBNull") settings.writeBufferSize = Convert.ToInt32(values[13]);
            if (values[14].GetType().ToString() != "System.DBNull") settings.writeTimeout = Convert.ToInt32(values[14]);
            return settings;
        }
        //readSyntaxList: read the command's syntax, 
        //and return the full list if it would send a sign, it initializate and read it too
        public List<Syntax> readSyntaxList()
        {
            List<Syntax> syntaxlist = new List<Syntax>();
            int i = 0;
            foreach (object syntaxID in dbReader(Cmdstring.syntaxid, Cmdstring.syntaxid_fieldlist))
            {
                syntaxlist.Add(readSyntax(syntaxID.ToString()));
                if (syntaxlist[i].syntaxType == "sign")
                {
                    syntaxlist[i].Sign = readSign(syntaxID.ToString());
                }
                i++;

            }
            return syntaxlist;
        }
        //readMetadataList: return lists of metadata.
        //Metadata table contains two column, one contain the name of metadata, another contain the value
        public List<Metadata> readMetadataList()
        {
            List<Metadata> metadatalist = new List<Metadata>();
            foreach (object metadataID in dbReader(Cmdstring.metadataid, Cmdstring.metadataid_fieldlist))
            {
                metadatalist.Add(readMetadata(metadataID.ToString()));
            }
            return metadatalist;
        }
        
        //dbReader: Read from database, it need a cmdstring and a fieldlist which belongs to that actually used cmdstring
        //Return lists of the queried object, which uncasted, following use you must cast to usable datatypes.
        private List<object> dbReader(string cmdstring, string[] fieldlist)
        {
            List<object> r = new List<object>();            
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = @"Data Source=" + dbPath;
                db.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = db;
            cmd.CommandText = cmdstring;
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach(string field in fieldlist)
                {
                    r.Add(dr[field]);
                }
            }
            db.Close();
            return r;
        }    
        //readSyntax: read one of the command's syntax, which will send to port
        //it need syntaxID of the finded syntax
        private Syntax readSyntax(string syntaxID)
        {
            Syntax syntax = new Syntax();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.syntax(syntaxID), Cmdstring.syntax_fieldlist);
            syntax.syntaxID = Convert.ToInt32(values[0]);
            syntax.syntaxOrder = Convert.ToInt32(values[1]);
            syntax.syntaxType = values[2].ToString();
            return syntax;
        }
        //readSign: when send to port a command, often it contain controlsigns, which signing where the commands starts or ended (or others)
        //this method return a sign, which belongs to a syntax, it need actual syntaxID
        private Sign readSign(string syntaxID)
        {
            Sign sign = new Sign();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.sign(syntaxID), Cmdstring.sign_fieldlist);
            sign.signID = Convert.ToInt32(values[0]);
            sign.signName = values[1].ToString();
            sign.singByte = Convert.ToInt32(values[2]);
            sign.signComment = values[3].ToString();
            return sign;
        }
        //ControlboxMode: read one of the modes of a controlbox
        //One mode contain five buttons, and its commands
        private ControlboxMode readControlboxMode(string controlmodeID)
        {
            ControlboxMode controlboxmode = new ControlboxMode();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.controlmode(controlmodeID), Cmdstring.controlmode_fieldlist);
            controlboxmode.controlboxModeID=Convert.ToInt32(values[0]);
            controlboxmode.controlboxModeName=values[1].ToString();
            controlboxmode.controlboxModeOrder=Convert.ToInt32(values[2]);
            controlboxmode.Up=readCmd(values[3].ToString());        
            controlboxmode.Down=readCmd(values[4].ToString());
            controlboxmode.Left=readCmd(values[5].ToString());
            controlboxmode.Right=readCmd(values[6].ToString());
            controlboxmode.Stop=readCmd(values[7].ToString());
            controlboxmode.controlBoxModeComment = values[8].ToString();
            return controlboxmode;
        }
        //readMetadata: read one metadatafield and its value, it need ID of the finded metadata
        private Metadata readMetadata(string metadataID)
        {
            Metadata meta = new Metadata();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.metadata(metadataID), Cmdstring.metadata_fieldlist);
            meta.metadataID = Convert.ToInt32(values[0]);
            meta.metadataField = values[1].ToString();
            meta.metadataValue = values[2].ToString();
            return meta;
        }
        //readControlbox: read a controlbox, its name, and its order
        private Controlbox readControlbox(string controlboxID)
        {
            Controlbox controlbox = new Controlbox();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.groupbox(controlboxID), Cmdstring.groupbox_fieldlist);
            controlbox.groupboxID = Convert.ToInt32(values[0]);
            controlbox.groupboxName = values[1].ToString();
            controlbox.groupboxOrder = Convert.ToInt32(values[2]);
            return controlbox;
        }
        //readControlboxcmds: read a cmdlist and its parameterlist which is belong to a controlbox
        private List<Cmd> readControlboxcmds(string controlmodeID)
        {
            List<Cmd> cmdlist = new List<Cmd>();
            int i = 0;
            foreach (object manifestID in dbReader(Cmdstring.controlmode_cmds(controlmodeID), Cmdstring.controlmode_cmds_fieldlist))
            {
                cmdlist.Add(readCmd(manifestID.ToString()));
                cmdlist[i].parameterList = new List<Parameter>();
                foreach (object parameters_cmdsID in dbReader(Cmdstring.parameters_cmdsid(cmdlist[i].cmdID.ToString()), Cmdstring.parameters_cmdsid_fieldlist))
                {
                    cmdlist[i].parameterList.Add(readParameter(parameters_cmdsID.ToString(), manifestID.ToString()));
                }
                i++;
            }
            return cmdlist;
        }
        //readGroupbox: read a groupbox, its name, and its order
        private CmdGroup readGroupbox(string groupboxID)
        {
            CmdGroup groupbox = new CmdGroup();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.groupbox(groupboxID), Cmdstring.groupbox_fieldlist);
            groupbox.groupboxID = Convert.ToInt32(values[0]);
            groupbox.groupboxName = values[1].ToString();
            groupbox.groupboxOrder = Convert.ToInt32(values[2]);
            return groupbox;
        }
        //readCmd: read a cmd which bleongs to a button, or combobox
        private Cmd readCmd(string manifestID)
        {
            Cmd cmd = new Cmd();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.cmd(manifestID), Cmdstring.cmd_fieldlist);
            cmd.cmdID = Convert.ToInt32(values[0]);
            cmd.cmdName = values[1].ToString();
            cmd.cmdByte = Convert.ToInt32(values[2]);
            cmd.cmdType = values[3].ToString();
            cmd.manifestComment = values[4].ToString();
            return cmd;

        }
        //readParameter: read a parameter, which belongs to a cmd, 
        //it need the actual cmd and its parameter's connection ID, and the actual manifestID
        //if parameter isn't in manifest_parameters table, parameterValue and Type will NULL
        //(except if parameter haven't got default value, because this time Type will a textbox)
        private Parameter readParameter(string parameters_cmdsID, string manifestID)
        {
            Parameter parameter = new Parameter();
            List<object> values = new List<object>();           
            values=dbReader(Cmdstring.parameter(parameters_cmdsID, manifestID), Cmdstring.parameter_fieldlist);
            if (values.Count != 0)
            {
                parameter.parameterID = Convert.ToInt32(values[0]);
                parameter.parameterName = values[1].ToString();
                parameter.parameterOrder = Convert.ToInt32(values[2]);
                if (values[3].GetType().ToString() != "System.DBNull") parameter.parameterMin = Convert.ToInt32(values[3]); else parameter.parameterMin = null;
                if (values[4].GetType().ToString() != "System.DBNull") parameter.parameterMax = Convert.ToInt32(values[4]); else parameter.parameterMax = null;
                if (values[5].GetType().ToString() != "System.DBNull") parameter.parameterDefault = Convert.ToInt32(values[5]); else parameter.parameterDefault = null;
                if (values[6].GetType().ToString() != "System.DBNull") parameter.parameterValue = Convert.ToInt32(values[6]); else parameter.parameterValue = null;
                parameter.parameterType = values[7].ToString();
                parameter.manifest_parameterComment = values[8].ToString();
            }
            else
            {
                values = dbReader(Cmdstring.parameter_fix(parameters_cmdsID), Cmdstring.parameter_fix_fieldlist);
                parameter.parameterID = Convert.ToInt32(values[0]);
                parameter.parameterName = values[1].ToString();
                parameter.parameterOrder = Convert.ToInt32(values[2]);
                if (values[3].GetType().ToString() != "System.DBNull") parameter.parameterMin = Convert.ToInt32(values[3]); else parameter.parameterMin = null;
                if (values[4].GetType().ToString() != "System.DBNull") parameter.parameterMax = Convert.ToInt32(values[4]); else parameter.parameterMax = null;
                if (values[5].GetType().ToString() != "System.DBNull") parameter.parameterDefault = Convert.ToInt32(values[5]); else parameter.parameterDefault = null;
                parameter.parameterValue = null;
                if (parameter.parameterDefault != null) parameter.parameterType = null; else parameter.parameterType = "textbox";
                parameter.manifest_parameterComment = null;
            }
            return parameter;
        }
    }
}