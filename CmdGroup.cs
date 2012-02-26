using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class CmdGroup
    {
        private string cmdgroupname;
        private List<Cmd> cmdlist;

        public string cmdGroupName { get { return this.cmdgroupname; } set { this.cmdgroupname = value; } }
        public List<Cmd> cmdList { get { return this.cmdlist; } set { this.cmdlist = value; } }

    }
    class Controlbox
    {
        private string controlboxname;
        private List<ControlboxMode> modes;

        public string controlboxName { get { return this.controlboxname; } set { this.controlboxname = value; } }
        public List<ControlboxMode> Modes { get { return this.modes; } set { this.modes = value; } }
    }
    class ControlboxMode
    {
        private string conttrolboxmodename;
        private int controlboxmodeorder;
        private Cmd up, down, left, right, stop;

        public string controlboxModeName { get { return this.conttrolboxmodename; } set { this.conttrolboxmodename = value; } }
        public int controlboxModeOrder { get { return this.controlboxmodeorder; } set { this.controlboxmodeorder = value; } }
        public Cmd Up { get { return this.up; } set { this.up = value; } }
        public Cmd Down { get { return this.down; } set { this.down = value; } }
        public Cmd Left { get { return this.left; } set { this.left = value; } }
        public Cmd Right { get { return this.right; } set { this.right = value; } }
        public Cmd Stop { get { return this.stop; } set { this.stop = value; } }
    }
    class Cmd
    {
        //private int cmdid;
        private string cmdname, cmdtype;
        private int cmdbyte;
        private List<Parameter> parameterlist;
        //protected string cmdcomment;

        //public int cmdID { get { return this.cmdid; } set{this.cmdid=value;} }
        public string cmdName { get { return this.cmdname; } set { this.cmdname = value; } }
        public string cmdType { get { return this.cmdtype; } set { this.cmdtype = value; } }
        public int cmdByte { get { return this.cmdbyte; } set { this.cmdbyte = value; } }
        public List<Parameter> parameterList { get { return this.parameterlist; } set { this.parameterlist = value; } }
        //public string cmdComment { get { return this.cmdcomment; } set { this.cmdcomment = value; } }


    }
    class Parameter
    {

        private string parametername, parametertype;
        private int parameterorder;
        private int? parametermin, parametermax, parameterdefault, parametervalue;
        //protected string paramcomment;

        public string parameterName { get { return this.parametername; } set { this.parametername = value; } }
        public int parameterOrder { get { return this.parameterorder; } set { this.parameterorder = value; } }
        public int? parameterMin { get { return this.parametermin; } set { this.parametermin = value; } }
        public int? parameterMax { get { return this.parametermax; } set { this.parametermax = value; } }
        public int? parameterDefault { get { return this.parameterdefault; } set { this.parameterdefault = value; } }
        //public string paramComment { get { return this.paramcomment; } set { this.paramcomment = value; } }
        public int? parameterValue { get { return this.parametervalue; } set { this.parametervalue = value; } }
        public string parameterType { get { return this.parametertype; } set { this.parametertype = value; } }
    }
}
