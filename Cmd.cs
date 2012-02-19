using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Cmd
    {
        protected int cmdid;
        protected string cmdname;
        protected int cmdbyte;
        protected string cmdcomment;
        protected List<Parameter> parameterlist;

        public int cmdID { get { return this.cmdid; } set{this.cmdid=value;} }
        public string cmdName { get { return this.cmdname; } set { this.cmdname = value; } }
        public int cmdByte { get { return this.cmdbyte; } set { this.cmdbyte = value; } }
        public string cmdComment { get { return this.cmdcomment; } set { this.cmdcomment = value; } }
        public List<Parameter> parameterList { get { return this.parameterlist; } set { this.parameterlist = value; } }

    }
}
