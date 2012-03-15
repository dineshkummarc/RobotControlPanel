using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RobotControlPanel
{
    class newdbHandler
    {
        private string dbPath;
        //SetdbPath: Set path of actually used database
        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }
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
        public List<CmdGroup> readGroupboxList()
        {
            List<CmdGroup> groupboxlist = new List<CmdGroup>();
            int i=0;
            foreach (object groupboxID in dbReader(Cmdstring.groupboxid, Cmdstring.groupboxid_fieldlist))
            {
                groupboxlist.Add(readGroupbox(Convert.ToInt32(groupboxID)));
                groupboxlist[i].cmdList = new List<Cmd>();
                int j = 0;
                foreach (object manifestID in dbReader(Cmdstring.manifestid(groupboxID.ToString()), Cmdstring.manifestid_fieldlist))
                {
                    groupboxlist[i].cmdList.Add(readCmd(Convert.ToInt32(manifestID)));
                    groupboxlist[i].cmdList[j].parameterList = new List<Parameter>();
                    foreach (object parameters_cmdsID in dbReader(Cmdstring.parameters_cmdsid(groupboxlist[i].cmdList[j].cmdID.ToString()), Cmdstring.parameters_cmdsid_fieldlist))
                    {
                        groupboxlist[i].cmdList[j].parameterList.Add(readParameter(Convert.ToInt32(parameters_cmdsID), Convert.ToInt32(manifestID)));
                    }
                    j++;
                }
                i++;
            }
            return groupboxlist;                 
        }
        public List<Controlbox> readControlBox()
        {
            List<Controlbox> controlboxList = new List<Controlbox>();
            int i=0;
            foreach (object controlboxID in dbReader(Cmdstring.controlboxid, Cmdstring.groupboxid_fieldlist))
            {
                controlboxList.Add(readControlbox(Convert.ToInt32(controlboxID)));
                controlboxList[i].Modes = new List<ControlboxMode>();
                int j = 0;
                foreach (object controlmodeID in dbReader(Cmdstring.controlmodeid(controlboxID.ToString()), Cmdstring.controlmodeid_fieldlist))
                {
                    controlboxList[i].Modes.Add(readControlboxMode(Convert.ToInt32(controlmodeID)));
                    List<Cmd> cmdlist = readControlboxcmds(Convert.ToInt32(controlmodeID));
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
        private ControlboxMode readControlboxMode(int controlmodeID)
        {
            ControlboxMode controlboxmode = new ControlboxMode();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.controlmode(controlmodeID.ToString()), Cmdstring.controlmode_fieldlist);
            controlboxmode.controlboxModeID=Convert.ToInt32(values[0]);
            controlboxmode.controlboxModeName=values[1].ToString();
            controlboxmode.controlboxModeOrder=Convert.ToInt32(values[2]);
            controlboxmode.Up=readCmd(Convert.ToInt32(values[3]));        
            controlboxmode.Down=readCmd(Convert.ToInt32(values[4]));
            controlboxmode.Left=readCmd(Convert.ToInt32(values[5]));
            controlboxmode.Right=readCmd(Convert.ToInt32(values[6]));
            controlboxmode.Stop = readCmd(Convert.ToInt32(values[7]));
            return controlboxmode;
        }
        private Controlbox readControlbox(int controlboxID)
        {
            Controlbox controlbox = new Controlbox();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.groupbox(controlboxID.ToString()), Cmdstring.groupbox_fieldlist);
            controlbox.controlboxID = Convert.ToInt32(values[0]);
            controlbox.controlboxName = values[1].ToString();
            return controlbox;
        }
        private List<Cmd> readControlboxcmds(int controlmodeID)
        {
            List<Cmd> cmdlist = new List<Cmd>();
            int i = 0;
            foreach (object manifestID in dbReader(Cmdstring.controlmode_cmds(controlmodeID.ToString()), Cmdstring.controlmode_cmds_fieldlist))
            {
                cmdlist.Add(readCmd(Convert.ToInt32(manifestID)));
                cmdlist[i].parameterList = new List<Parameter>();
                foreach (object parameters_cmdsID in dbReader(Cmdstring.parameters_cmdsid(cmdlist[i].cmdID.ToString()), Cmdstring.parameters_cmdsid_fieldlist))
                {
                    cmdlist[i].parameterList.Add(readParameter(Convert.ToInt32(parameters_cmdsID), Convert.ToInt32(manifestID)));
                }
                i++;
            }
            return cmdlist;
        }
        private CmdGroup readGroupbox(int groupboxID)
        {
            CmdGroup groupbox = new CmdGroup();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.groupbox(groupboxID.ToString()), Cmdstring.groupbox_fieldlist);
            groupbox.groupboxID = Convert.ToInt32(values[0]);
            groupbox.groupboxName = values[1].ToString();
            return groupbox;
        }
        private Cmd readCmd(int manifestID)
        {
            Cmd cmd = new Cmd();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.cmd(manifestID.ToString()), Cmdstring.cmd_fieldlist);
            cmd.cmdID = Convert.ToInt32(values[0]);
            cmd.cmdName = values[1].ToString();
            cmd.cmdByte = Convert.ToInt32(values[2]);
            cmd.cmdType = values[3].ToString();
            return cmd;

        }
        private Parameter readParameter(int parameters_cmdsID, int manifestID)
        {
            Parameter parameter = new Parameter();
            List<object> values = new List<object>();           
            values=dbReader(Cmdstring.parameter(parameters_cmdsID.ToString(), manifestID.ToString()), Cmdstring.parameter_fieldlist);
            if (values.Count != 0)
            {
                parameter.parameterID = Convert.ToInt32(values[0]);
                parameter.parameterName = values[1].ToString();
                parameter.parameterOrder = Convert.ToInt32(values[2]);
                try { parameter.parameterMin = Convert.ToInt32(values[3]); }
                catch (InvalidCastException) { parameter.parameterMin = null; }
                try { parameter.parameterMax = Convert.ToInt32(values[4]); }
                catch (InvalidCastException) { parameter.parameterMax = null; }
                try { parameter.parameterDefault = Convert.ToInt32(values[5]); }
                catch (InvalidCastException) { parameter.parameterDefault = null; }
                try { parameter.parameterValue = Convert.ToInt32(values[6]); }
                catch (InvalidCastException) { parameter.parameterValue = null; }
                parameter.parameterType = values[7].ToString();
            }
            else
            {
                values = dbReader(Cmdstring.parameter_fix(parameters_cmdsID.ToString()), Cmdstring.parameter_fix_fieldlist);
                parameter.parameterID = Convert.ToInt32(values[0]);
                parameter.parameterName = values[1].ToString();
                parameter.parameterOrder = Convert.ToInt32(values[2]);
                try { parameter.parameterMin = Convert.ToInt32(values[3]); }
                catch (InvalidCastException) { parameter.parameterMin = null; }
                try { parameter.parameterMax = Convert.ToInt32(values[4]); }
                catch (InvalidCastException) { parameter.parameterMax = null; }
                try { parameter.parameterDefault = Convert.ToInt32(values[5]); }
                catch (InvalidCastException) { parameter.parameterDefault = null; }
                parameter.parameterValue = null;
                if (parameter.parameterDefault == null) parameter.parameterType = "textbox";
                else parameter.parameterType = null;
            }
            return parameter;
        }

    }
}