using Challenger.Instances;
using Challenger.Utils;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
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

            if (type.Equals("fame"))
            {
                ProgramVariables.Data.GetGuild(this.Context.Guild.Id).FameChannel = channel.Id;
                await ReplyAsync("You successfully set fame channel!");
            }

            if (type.Equals("task"))
            {
                ProgramVariables.Data.GetGuild(this.Context.Guild.Id).TasksChannel = channel.Id;
                await ReplyAsync("You successfully set task channel!");
            }

        }

        [Command("task"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task CreateTask(IChannel channel, ulong messageId)
        {

            if(this.Context.Guild.Id == 611985124023730185 /*nCodes*/ || this.Context.Guild.Id == 826413102957723719 /*nCodes Test*/)
            {


                string name = "", messageText = "", script = "";
                DateTime startDate = DateTime.Now, endDate = DateTime.Now;
                double maxPoints = 0.0;
                foreach (SocketTextChannel socket in this.Context.Guild.TextChannels)
                {
                    if (socket.Id == channel.Id)
                    {
                        string text = socket.GetMessageAsync(messageId).Result.Content;
                        string[] splitter = text.Split('\n');
                        if (splitter.Length < 6)
                        {
                            await ReplyAsync("Input message is in incorrect format!");
                            return;
                        }
                        try
                        {
                            name = splitter[0];
                            startDate = Convert.ToDateTime(splitter[1]);
                            endDate = Convert.ToDateTime(splitter[2]);
                            maxPoints = Convert.ToDouble(splitter[3]);
                            script = splitter[4];
                            messageText = splitter[5];
                        }
                        catch(Exception ex)
                        {
                            await ReplyAsync("Error while converting inputs");
                        }
                    }
                }

                if (ProgramVariables.Data.IsTaskExists(name))
                {
                    await ReplyAsync("Task with that name already exists!");
                    return;
                }

                TaskInstance task = new TaskInstance(name, maxPoints, this.Context.User.Id, this.Context.User.Username, DateTime.Now, startDate, endDate, messageText, script);
                ProgramVariables.Data.Tasks.Add(task);
                await ReplyAsync("You successfully added task!");

            }

        }

        [Command("json"), RequireUserPermission(GuildPermission.Administrator)]
        public async Task SendJson()
        {

            FileUtils.CreateTempJson();
            await this.Context.Channel.SendFileAsync("temp.json", "Here is your json file!");

        }

    }
}
