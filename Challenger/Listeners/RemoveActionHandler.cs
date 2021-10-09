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
    class RemoveActionHandler
    {

        public static async Task RemoveReaction(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel originChannel, SocketReaction reaction)
        {

            if (reaction.Emote.Name.Equals("✅") && ProgramVariables.Data.GetGuild(((SocketGuildChannel)reaction.Channel).Guild.Id).InfoChannel == originChannel.Id)
            {

                if (ProgramVariables.Data.IsChallengerExists(reaction.UserId))
                {

                    ProgramVariables.Data.GetChallenger(reaction.UserId).IsActive = false;

                }

            }

        }

    }
}