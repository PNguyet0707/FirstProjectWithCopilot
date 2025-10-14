using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    //[Table("Schedule")] Atribute
    public class Schedule : Entity<string>
    {
        public string PlanId { get; set; }
        public string Plan {  get; set; }
        public string Cron {  get; set; }
        public long CreateTime { get; set; }
        public long Offset { get; set; }
        public long NextTime { get; set; }
        public int RepeatCount { get; set; }
        public long RepeatInterval { get; set; }
        public int RunCount { get; set; }
    }
}
