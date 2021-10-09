using Challenger.Instances;
using Challenger.Utils;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Listeners
{
    class GuildAvaibleHandler
    {

        public static async Task GuildAvaible(SocketGuild arg)
        {

            if (!arg.Name.Contains("nCodes"))
            {
                await arg.LeaveAsync();
                return;
            }

            ProgramVariables.Data.Guilds.Add(new GuildInstance(arg.Id, arg.Name, arg.OwnerId, arg.Owner.Nickname));

        }

    }
}
