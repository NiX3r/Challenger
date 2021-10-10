using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class TaskInstance
    {

        public string Name { get; set; }
        public double MaxPoints { get; set; }
        public ulong CreatorID { get; }
        public string CreatorName { get; }
        public DateTime CreateDate { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Message { get; set; }
        public string Script { get; set; }

        public TaskInstance(string Name, double MaxPoints, ulong CreatorID, string CreatorName, DateTime CreateDate, DateTime StartDate, DateTime EndDate, string Message, string Script)
        {
            this.Name = Name;
            this.MaxPoints = MaxPoints;
            this.CreatorID = CreatorID;
            this.CreatorName = CreatorName;
            this.CreateDate = CreateDate;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Message = Message;
            this.Script = Script;
        }

    }
}
