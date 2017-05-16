using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class WorkTime
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime WorkDate { get; set; }
        public int JobId { get; set; }
        public int Id { get; set; }


        public WorkTime(TimeSpan startTime, TimeSpan endTime, DateTime workDate)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;        
        }


        public WorkTime(TimeSpan startTime, TimeSpan endTime, DateTime workDate, int jobId)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;
            this.JobId = jobId;
        }


    }
}
