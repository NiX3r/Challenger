using Challenger.Timers;
using Challenger.Utils;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Challenger
{
    class Program
    {
        static void Main(string[] args)
        {

            // Setup program version
            ProgramVariables.Version = "0.1";
            ProgramVariables.Data = new Instances.DataInstance();
            ProgramVariables._client = new DiscordSocketClient();
            ProgramVariables._commands = new CommandService();
            ProgramVariables._services = new ServiceCollection().AddSingleton(ProgramVariables._client).AddSingleton(ProgramVariables._commands).BuildServiceProvider();
            ProgramVariables._client.Log += BotUtils._client_Log;

            SetGameTimer.Setup();
            SetGameTimer.Start();

        }

        private static async Task RunBotAsync()
        {

            await BotUtils.RegisterHandlers();

        }

    }
}
