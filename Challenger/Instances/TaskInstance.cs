using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class TaskInstance
    {

        public int ID { get; }
        public string Name { get; set; }
        public double MaxPoints { get; set; }
        public ulong CreatorID { get; }
        public string CreatorName { get; }
        public DateTime CreateDate { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ulong TextChannelID { get; set; }
        public ulong TextMessageID { get; set; }

        public TaskInstance(int ID, string Name, double MaxPoints, ulong CreatorID, string CreatorName, DateTime CreateDate, DateTime StartDate, DateTime EndDate, ulong TextChannelID, ulong TextMessageID)
        {
            this.ID = ID;
            this.Name = Name;
            this.MaxPoints = MaxPoints;
            this.CreatorID = CreatorID;
            this.CreatorName = CreatorName;
            this.CreateDate = CreateDate;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.TextChannelID = TextChannelID;
            this.TextMessageID = TextMessageID;
        }

    }
}
