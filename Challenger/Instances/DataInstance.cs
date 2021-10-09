using Challenger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Instances
{
    class DataInstance
    {

        public string Version { get; }
        public int GuildsCount { get; set; }
        public int TasksCount { get; set; }
        public int ChallengersCount { get; set; }
        public int InOutputsCount { get; set; }
        public List<GuildInstance> Guilds { get; }
        public List<TaskInstance> Tasks { get; set; }
        public List<ChallengerInstance> Challengers { get; set; }
        public List<InOutputInstance> InOutputs { get; set; }

        public DataInstance(List<GuildInstance> Guilds = null, List<TaskInstance> Tasks = null, List<ChallengerInstance> Challengers = null, List<InOutputInstance> InOutputs = null)
        {
            this.Version = ProgramVariables.Version;

            if (Guilds == null)
                this.Guilds = new List<GuildInstance>();
            else
                this.Guilds = Guilds;
            if (Tasks == null)
                this.Tasks = new List<TaskInstance>();
            else
                this.Tasks = Tasks;
            if (Challengers == null)
                this.Challengers = new List<ChallengerInstance>();
            else
                this.Challengers = Challengers;
            if (InOutputs == null)
                this.InOutputs = new List<InOutputInstance>();
            else
                this.InOutputs = InOutputs;

            this.GuildsCount = this.Guilds.Count;
            this.TasksCount = this.Tasks.Count;
            this.ChallengersCount = this.Challengers.Count;
            this.InOutputsCount = this.InOutputs.Count;

        }

        public GuildInstance GetGuild(ulong ID)
        {
            foreach(GuildInstance guild in this.Guilds)
            {
                if (guild.ID == ID)
                    return guild;
            }
            return null;
        }

        public ChallengerInstance GetChallenger(ulong ID)
        {
            foreach(ChallengerInstance challenger in this.Challengers)
            {
                if (challenger.ID == ID)
                    return challenger;
            }
            return null;
        }

        public bool IsChallengerExists(ulong ID)
        {
            foreach(ChallengerInstance challenger in this.Challengers)
            {
                if (challenger.ID == ID)
                    return true;
            }
            return false;
        }

        public bool IsGuildExists(ulong ID)
        {
            foreach (GuildInstance guild in this.Guilds)
            {
                if (guild.ID == ID)
                    return true;
            }
            return false;
        }

    }
}
