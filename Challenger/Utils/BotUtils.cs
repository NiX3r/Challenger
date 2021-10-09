using Challenger.Listeners;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Utils
{
    class BotUtils
    {

        public static Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public static async Task RegisterHandlers()
        {
            ProgramVariables._client.MessageReceived += PrivateMessageHandler.PrivateMessage;
            ProgramVariables._client.GuildAvailable += GuildAvaibleHandler.GuildAvaible;
            ProgramVariables._client.ReactionAdded += AddReactionHandler.AddReaction;
            ProgramVariables._client.ReactionRemoved += RemoveActionHandler.RemoveReaction;
            //ProgramVariables._client.Disconnected += HandleDisconnetConnectEvent.HandleDisconnect;
            //ProgramVariables._client.Connected += HandleDisconnetConnectEvent.HandleConnect;
            
        }

        public static async Task RegisterCommands()
        {
            ProgramVariables._client.MessageReceived += CommandAsyncHandler.CommandAsync;
            await ProgramVariables._commands.AddModulesAsync(Assembly.GetEntryAssembly(), ProgramVariables._services);
        }

    }
}
