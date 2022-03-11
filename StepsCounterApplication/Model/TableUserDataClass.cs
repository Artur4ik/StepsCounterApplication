using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsCounterApplication.Model
{
    internal class TableUserDataClass
    {
        public string User { get; set; }
        public int Rank { get; set; }
        public string Status { get; set; }
        public int StepsAvg { get; set; }
        public int StepsBest { get; set; }
        public int StepsWorse { get; set; }

    }
}
