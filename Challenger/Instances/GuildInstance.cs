using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class GuildInstance
    {

        public ulong ID { get; }
        public string Name { get; set; }
        public ulong OwnerID { get; set; }
        public string OwnerName { get; set; }
        public ulong TasksChannel { get; set; }
        public ulong InfoChannel { get; set; }
        public ulong FameChannel { get; set; }

        public GuildInstance(ulong ID, string Name, ulong OwnerID, string OwnerName, ulong TasksChannel = 0, ulong InfoChannel = 0, ulong FameChannel = 0)
        {
            this.ID = ID;
            this.Name = Name;
            this.OwnerID = OwnerID;
            this.OwnerName = OwnerName;
            this.TasksChannel = TasksChannel;
            this.InfoChannel = InfoChannel;
            this.FameChannel = FameChannel;
        }

    }
}
