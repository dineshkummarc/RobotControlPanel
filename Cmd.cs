using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Cmd
    {
        public int cmdID { get; set; }
        public string cmdName { get; set; }
        public int cmdByte { get; set; }
        public string cmdComment { get; set; }
        public List<Parameter> parameterList { get; set; }

    }
}
