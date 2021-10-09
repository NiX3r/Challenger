using Challenger.Utils;
using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenger.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        [Command("ping"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task Ping()
        {

            EmbedFieldBuilder close = new EmbedFieldBuilder();
            close.Name = "Processor";
            close.Value = HardwareUsage.getCurrentCpuUsage();
            close.IsInline = true;

            EmbedFieldBuilder log = new EmbedFieldBuilder();
            log.Name = "RAM";
            log.Value = HardwareUsage.getAvailableRAM();
            log.IsInline = true;

            EmbedFieldBuilder guilds = new EmbedFieldBuilder();
            guilds.Name = "Guilds";
            guilds.Value = ProgramVariables.Data.Guilds.Count;
            guilds.IsInline = false;

            EmbedFieldBuilder latency = new EmbedFieldBuilder();
            latency.Name = "Latency";
            latency.Value = ProgramVariables._client.Latency;
            latency.IsInline = true;

            float cpu = (float)Convert.ToDecimal(close.Value.ToString().Replace("%", ""));

            var EmbedBuilder = new EmbedBuilder()
                .WithTitle($"Server response")
                .WithColor(cpu < 50.0 ? Color.Green : Color.Red)
                .WithThumbnailUrl(cpu < 50.0 ? "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FgTrvi5MI9NY%2Fmaxresdefault.jpg&f=1&nofb=1" : "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.imgflip.com%2F4qbswj.jpg&f=1&nofb=1")
                .WithTimestamp(DateTime.Now)
                .WithFields(close, log, guilds, latency);
            Embed embed = EmbedBuilder.Build();
            await Context.Channel.SendMessageAsync(embed: embed);
            return;
        }

        [Command("set"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task SetChannel(string type, IChannel channel)
        {

            if (type.Equals("info"))
            {

                ProgramVariables.Data.GetGuild(this.Context.Guild.Id).InfoChannel = channel.Id;
                await ReplyAsync("You successfully set info channel!");

            }

        }

    }
}
