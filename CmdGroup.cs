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
}
