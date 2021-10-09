using Challenger.Instances;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Utils
{
    class ProgramVariables
    {

        public static string Version { get; set; }
        public static DataInstance Data { get; set; }
        public static DiscordSocketClient _client { get; set; }
        public static CommandService _commands { get; set; }
        public static IServiceProvider _services { get; set; }

    }
}
