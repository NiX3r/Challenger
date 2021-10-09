using Challenger.Timers;
using Challenger.Utils;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
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

            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            SetGameTimer.Setup();
            SetGameTimer.Start();

            var task = RunBotAsync();

            Console.ReadLine();

        }

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler();
        static EventHandler _handler;

        private static bool Handler()
        {
            FileUtils.SaveData();
            return true;
        }

        private static async Task RunBotAsync()
        {

            // Load data
            if(FileUtils.CheckDataJsonExists())
                FileUtils.LoadData();

            Console.WriteLine(ProgramVariables.Data.Guilds[0].InfoChannel);

            await BotUtils.RegisterHandlers();
            await BotUtils.RegisterCommands();
            await ProgramVariables._client.LoginAsync(TokenType.Bot, SecretClass.GetToken());
            await ProgramVariables._client.StartAsync();
            await Task.Delay(-1);

        }

    }
}
