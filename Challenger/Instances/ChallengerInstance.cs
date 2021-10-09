using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class ChallengerInstance
    {

        public ulong ID { get; }
        public string Name { get; set; }
        public DateTime JoinedDate { get; }
        public ulong JoinedServerID { get; }
        public string JoinedServerName { get; set; }
        public bool IsActive { get; set; }
        public double Points { get; set; }

        public ChallengerInstance(ulong ID, string Name, DateTime JoinedDate, ulong JoinedServerID, string JoinedServerName, bool IsActive = true, double Points = 0.0)
        {
            this.ID = ID;
            this.Name = Name;
            this.JoinedDate = JoinedDate;
            this.JoinedServerID = JoinedServerID;
            this.JoinedServerName = JoinedServerName;
            this.IsActive = IsActive;
            this.Points = Points;
        }

        public double Increment(double value)
        {
            this.Points += value;
            return this.Points;
        }

        public double Decrement(double value)
        {
            this.Points -= value;
            if (this.Points < 0)
                this.Points = 0.0;
            return this.Points;
        }

    }
}
