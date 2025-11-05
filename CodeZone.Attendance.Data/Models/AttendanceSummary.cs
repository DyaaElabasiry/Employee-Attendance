using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Data.Models
{
    public class AttendanceSummary
    {
        public int Presents { get; set; }
        public int Absents { get; set; }
        public double AttendancePercentage { get; set; }
    }
}
