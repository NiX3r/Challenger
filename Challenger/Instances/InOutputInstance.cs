using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class InOutputInstance
    {

        public int ID { get; }
        public ulong ChallengerID { get; }
        public int TaskID { get; }
        public DateTime CreateDate { get; }
        public string Input { get; }
        public string CorrectOutput { get; }
        public string Output { get; set; }
        public double EarnedPoints { get; set; }

        public InOutputInstance(int ID, ulong ChallengerID, int TaskID, DateTime CreateDate, string Input, string CorrectOutput)
        {
            this.ID = ID;
            this.ChallengerID = ChallengerID;
            this.TaskID = TaskID;
            this.CreateDate = CreateDate;
            this.Input = Input;
            this.CorrectOutput = CorrectOutput;
            this.Output = "";
            this.EarnedPoints = 0;
        }

    }
}
