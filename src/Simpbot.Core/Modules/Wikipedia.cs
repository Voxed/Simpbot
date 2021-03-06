﻿using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using Simpbot.Service.Wikipedia;

namespace Simpbot.Core.Modules
{
    public class Wikipedia : ModuleBase
    {
        private readonly IWikipediaService _wikipediaService;
        private readonly ICustomLogger _customLogger;

        public Wikipedia(IWikipediaService wikipediaService, ICustomLogger customLogger)
        {
            _wikipediaService = wikipediaService;
            _customLogger = customLogger;
        }

        [Command("wiki", RunMode = RunMode.Async), Summary("Gets a wiki page")]
        public async Task GetWikiPage([Remainder] string query)
        {
            var result = await _wikipediaService.SearchForPageAsync(query)
                .ConfigureAwait(false);

            var embed = new EmbedBuilder()
                .WithTitle(result.Title)
                .WithDescription(result.SelfLink)
                .Build();

            await ReplyAsync(Context.User.Mention, false, embed)
                .ConfigureAwait(false);
        }
    }
}