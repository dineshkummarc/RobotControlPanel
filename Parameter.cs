using System;
using System.Collections.Generic;
using System.Text;

namespace RobotControlPanel
{
    class Parameter
    {
        public string paramName { get; set; }
        public int? paramMin { get; set; }
        public int? paramMax { get; set; }
        public int? paramDefault { get; set; }
        public string paramComment { get; set; }
    }
}
