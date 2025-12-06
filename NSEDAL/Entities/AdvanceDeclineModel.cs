using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEDAL.Entities
{
    public class AdvanceDeclineModel
    {
        public string PeriodType { get; set; }

        public string TimeStamp { get; set; }

        public string DateFormatted { get; set; }

        public string Sector { get; set; }

        public int Advanced { get; set; }

        public int Declined { get; set; }

        public int NoChange { get; set; }
    }
}
