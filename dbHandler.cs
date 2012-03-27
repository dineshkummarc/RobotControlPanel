using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace RobotControlPanel
{
    //interface IdbHandler
    //{
    //    void SetdbPath(string dbPath);
    //    List<Groupbox> readGroupboxList();
    //    Settings readSettings();
    //    List<Syntax> readSyntaxList();
    //    List<Metadata> readMetadataList();
    //}
    class dbHandler// : IdbHandler
    {
        private string dbPath;
        
        //SetdbPath: Set path of actually used database
        public void SetdbPath(string dbPath)
        {
            this.dbPath = dbPath;
        }
        //dbCheck: checking selected database for inconsistency and incompatibility issues
        public bool dbCheck(string tempPath)
        {
            if (dbReader(tempPath, Cmdstring.dbcheck_integrity, Cmdstring.dbcheck_integrity_fieldlist).ToString() == "ok")
            {
                string st;
                int i = 0;
                foreach (string table in Cmdstring.dbcheck_tablelist)
                {
                    if (Convert.ToBoolean(dbReader(tempPath, Cmdstring.dbcheck(table), Cmdstring.dbcheck_fieldlist)))
                    {
                        st = (dbReader(tempPath, Cmdstring.dbcheck_checktable(table), Cmdstring.dbcheck_checktable_fieldlist).ToString());
                        if (st != Cmdstring.dbcheck_sql[i])
                        {
                            MessageBox.Show("Selected database isn't usable. It is probably damaged or made not for this software. Try another database!", "Database error");
                            return false;
                        }
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("Database isn't contain neccessary data. It is probably damaged or made not for this software. Try another database!", "Database error");
                        return false;
                    }
                }
                if (dbReader(tempPath, Cmdstring.dbcheck_software, Cmdstring.dbcheck_software_fieldlist).ToString() != "Robot Control Panel v0.12")
                {
                    MessageBox.Show("Database seems to be usable, but it made not for this software, or made with earlier version of this software. Use it own risk!", "Database warning");
                    return true;
                }
                else return true;
            }
            else
            {
                MessageBox.Show("Database damaged. Try another database!", "Database error");
                return false;
            }
        }
        ////DO NOT DELETE THIS
        ////sqlReader: this method use only debugging. It is read normal db's sql-syntax and write to a txt file.
        //public void sqlReader(string tempPath)
        //{
        //    MessageBox.Show("Press OK to start SQLReader!");
        //    FileStream fs = new FileStream(@"sql.txt",FileMode.Create, FileAccess.Write, FileShare.None);
        //    StreamWriter sw = new StreamWriter(fs);
        //    string st;
        //    foreach (object table in dbReader(tempPath, Cmdstring.tbl_name, Cmdstring.tbl_name_fieldlist))
        //    {
        //        st = dbReader(tempPath, Cmdstring.sqlread(table.ToString()), Cmdstring.sqlread_fieldlist)[0].ToString();
        //        sw.WriteLine(st);
        //    }
        //    sw.Close();
        //    fs.Close();
        //    MessageBox.Show("Operation success!");
        //}

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
                foreach (string field in fieldlist)
                {
                    r.Add(dr[field]);
                }
            }
            db.Close();
            return r;
        }
        //DO NOT DELETE THIS
        //private List<object> dbReader(string tempPath, string cmdstring, string[] fieldlist)
        //{
        //    List<object> r = new List<object>();
        private object dbReader(string tempPath, string cmdstring, string[] fieldlist)
        {
            object r = new object();
            SQLiteConnection db = new SQLiteConnection();
            try
            {
                db.ConnectionString = @"Data Source=" + tempPath;
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
                foreach (string field in fieldlist)
                {
                    r=dr[field];
                }
            }
            db.Close();
            return r;
        }
        //readGroupboxList
        public List<Groupbox> readGroupboxList()
        {
            List<Groupbox> groupboxlist = new List<Groupbox>();
            int i=0;
            foreach (object groupboxid in dbReader(Cmdstring.groupboxid, Cmdstring.groupboxid_filedlist))
            {
                groupboxlist.Add(readGroupbox(groupboxid.ToString()));
                groupboxlist[i].Mode=new List<Mode>();
                int j = 0;
                foreach (object modeid in dbReader(Cmdstring.modeid(groupboxid.ToString()), Cmdstring.modeid_fieldlist))
                {
                    groupboxlist[i].Mode.Add(readMode(modeid.ToString()));
                    groupboxlist[i].Mode[j].CmdItem = new List<CmdItem>();
                    int k = 0;
                    foreach(object cmditemid in dbReader(Cmdstring.cmditemid(modeid.ToString()), Cmdstring.cmditemid_fieldlist))
                    {
                        groupboxlist[i].Mode[j].CmdItem.Add(readCmdItem(cmditemid.ToString()));
                        groupboxlist[i].Mode[j].CmdItem[k].Cmd = readCmd(dbReader(Cmdstring.cmdid(cmditemid.ToString()),Cmdstring.cmdid_fieldlist)[0].ToString());
                        groupboxlist[i].Mode[j].CmdItem[k].Cmd.parameterList = new List<Parameter>();
                        string cmdID=groupboxlist[i].Mode[j].CmdItem[k].Cmd.cmdID.ToString();
                        int l = 0;
                        foreach (object parameterid in dbReader(Cmdstring.parameterid(cmdID), Cmdstring.parameterid_fieldlist))
                        {
                            groupboxlist[i].Mode[j].CmdItem[k].Cmd.parameterList.Add(readParameter(parameterid.ToString(),cmdID));
                            groupboxlist[i].Mode[j].CmdItem[k].Cmd.parameterList[l].parameterValue = readParameterValue(cmditemid.ToString(), parameterid.ToString());
                            //if (parameterValue != null) groupboxlist[i].Mode[j].CmdItem[k].Cmd.parameterList[l].parameterValue = parameterValue;
                            l++;   
                        }
                        k++;
                    }
                    groupboxlist[i].Mode[j].ParameterItem = new List<ParameterItem>();
                    foreach (object parameteritemid in dbReader(Cmdstring.parameteritemid(modeid.ToString()),Cmdstring.parameteritemid_fieldlist))
                    {
                        groupboxlist[i].Mode[j].ParameterItem.Add(readParameteritem(parameteritemid.ToString()));
                    }
                    j++;
                }
                i++;
            }
            return groupboxlist;
        }
        //readGroupbox
        private Groupbox readGroupbox(string groupboxID)
        {
            Groupbox groupbox = new Groupbox();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.groupbox(groupboxID), Cmdstring.groupbox_fieldlist);
            groupbox.groupboxID = Convert.ToInt32(values[0]);
            groupbox.groupboxName = values[1].ToString();
            groupbox.groupboxOrder = Convert.ToInt32(values[2]);
            groupbox.groupboxType = values[3].ToString();
            groupbox.groupboxComment = values[4].ToString();
            return groupbox;
        }
        //readMode
        private Mode readMode(string modeID)
        {
            Mode mode = new Mode();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.mode(modeID), Cmdstring.mode_fieldlist);
            mode.modeID = Convert.ToInt32(values[0]);
            mode.modeName = values[1].ToString();
            mode.modeOrder = Convert.ToInt32(values[2]);
            mode.modeComment = values[3].ToString();
            return mode;
        }

        //readCmditem
        private CmdItem readCmdItem(string cmditemID)
        {
            CmdItem cmditem = new CmdItem();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.cmditem(cmditemID), Cmdstring.cmditem_fieldlist);
            cmditem.cmditemID=Convert.ToInt32(values[0]);
            cmditem.cmditemName=values[1].ToString();
            cmditem.cmditemOrder=Convert.ToInt32(values[2]);
            cmditem.cmditemType=values[3].ToString();
            cmditem.cmditemComment=values[4].ToString();
            return cmditem;
        }
        //readParameteritem
        private ParameterItem readParameteritem(string parameteritemID)
        {
            ParameterItem parameteritem = new ParameterItem();
            parameteritem.Parameter = new Parameter();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.parameteritem(parameteritemID), Cmdstring.parameteritem_fieldlist);
            parameteritem.parameteritemID = Convert.ToInt32(values[0]);
            parameteritem.parameteritemName = values[1].ToString();
            parameteritem.parameteritemOrder = Convert.ToInt32(values[2]);
            parameteritem.parameteritemType = values[3].ToString();
            parameteritem.parameteritemComment = values[4].ToString();
            parameteritem.Parameter.parameterID=Convert.ToInt32(values[5]);
            parameteritem.Parameter.parameterName=values[6].ToString();
            if (values[7].GetType().ToString() != "System.DBNull") parameteritem.Parameter.parameterMin = Convert.ToInt32(values[7]); else  parameteritem.Parameter.parameterMin= null;
            if (values[8].GetType().ToString() != "System.DBNull") parameteritem.Parameter.parameterMax = Convert.ToInt32(values[8]); else parameteritem.Parameter.parameterMax = null;
            if (values[9].GetType().ToString() != "System.DBNull") parameteritem.Parameter.parameterDefault = Convert.ToInt32(values[9]); else parameteritem.Parameter.parameterDefault = null;
            parameteritem.Parameter.parameterComment=values[10].ToString();
            return parameteritem;
        }
        //readCmd: read a cmd which bleongs to a button, or combobox
        private Cmd readCmd(string cmdID)
        {
            Cmd cmd = new Cmd();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.cmd(cmdID), Cmdstring.cmd_fieldlist);
            cmd.cmdID = Convert.ToInt32(values[0]);
            cmd.cmdName = values[1].ToString();
            cmd.cmdByte = Convert.ToInt32(values[2]);
            cmd.cmdComment = values[3].ToString();
            return cmd;

        }
        //readParameter: read a parameter, which belongs to a cmd, 
        //it need the actual cmd and its parameter's connection ID, and the actual manifestID
        //if parameter isn't in manifest_parameters table, parameterValue and Type will NULL
        //(except if parameter haven't got default value, because this time Type will a textbox)
        private Parameter readParameter(string parameterID, string cmdID)
        {
            Parameter parameter = new Parameter();
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.parameter(parameterID, cmdID), Cmdstring.parameter_fieldlist);
            //if (values.Count != 0)
            //{
                parameter.parameterID = Convert.ToInt32(values[0]);
                parameter.parameterName = values[1].ToString();               
                if (values[2].GetType().ToString() != "System.DBNull") parameter.parameterMin = Convert.ToInt32(values[2]); else parameter.parameterMin = null;
                if (values[3].GetType().ToString() != "System.DBNull") parameter.parameterMax = Convert.ToInt32(values[3]); else parameter.parameterMax = null;
                if (values[4].GetType().ToString() != "System.DBNull") parameter.parameterDefault = Convert.ToInt32(values[4]); else parameter.parameterDefault = null;
                parameter.parameterComment = values[5].ToString();
                parameter.parameterOrder = Convert.ToInt32(values[6]);

            //}
            //else
            //{
            //    values = dbReader(Cmdstring.parameter_fix(parameters_cmdsID), Cmdstring.parameter_fix_fieldlist);
            //    parameter.parameterID = Convert.ToInt32(values[0]);
            //    parameter.parameterName = values[1].ToString();
            //    parameter.parameterOrder = Convert.ToInt32(values[2]);
            //    if (values[3].GetType().ToString() != "System.DBNull") parameter.parameterMin = Convert.ToInt32(values[3]); else parameter.parameterMin = null;
            //    if (values[4].GetType().ToString() != "System.DBNull") parameter.parameterMax = Convert.ToInt32(values[4]); else parameter.parameterMax = null;
            //    if (values[5].GetType().ToString() != "System.DBNull") parameter.parameterDefault = Convert.ToInt32(values[5]); else parameter.parameterDefault = null;
            //    parameter.parameterValue = null;
            //    if (parameter.parameterDefault != null) parameter.parameterType = null; else parameter.parameterType = "textbox";
            //    parameter.manifest_parameterComment = null;
            //}
            return parameter;
        }
        private int? readParameterValue(string cmditemID, string parameterID)
        {
            List<object> values = new List<object>();
            values = dbReader(Cmdstring.parametervalue(cmditemID, parameterID), Cmdstring.parametervalue_fieldlist);
            int? parameterValue=null;
            if (values.Count != 0) parameterValue = Convert.ToInt32(values[0]);
            return parameterValue;
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

    }
}