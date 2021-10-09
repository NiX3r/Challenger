using Challenger.Instances;
using Challenger.Utils;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Listeners
{
    class AddReactionHandler
    {

        public static async Task AddReaction(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel originChannel, SocketReaction reaction)
        {
            if (reaction.Emote.Name.Equals("✅") && ProgramVariables.Data.GetGuild(((SocketGuildChannel)reaction.Channel).Guild.Id).InfoChannel == originChannel.Id)
            {

                if (!ProgramVariables.Data.IsChallengerExists(reaction.UserId))
                {

                    Console.WriteLine("Adding challenger");
                    ProgramVariables.Data.Challengers.Add(new ChallengerInstance(reaction.UserId, reaction.User.Value.Username, DateTime.Now, ((SocketGuildChannel)reaction.Channel).Guild.Id, ((SocketGuildChannel)reaction.Channel).Guild.Name));

                }

            }
        }

    }
}
