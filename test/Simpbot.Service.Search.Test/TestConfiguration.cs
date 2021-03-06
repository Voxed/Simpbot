﻿using Microsoft.Extensions.Configuration;

namespace Simpbot.Service.Search.Test
{
    public static class TestConfiguration
    {
        public static string BotToken { get; }
        public static ulong TestGuild { get; }
        public static string WeatherServiceKey { get; }
        public static string ImageServiceKey { get; }
        public static string ImageServiceCustomEngineKey { get; }

        static TestConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("secret.secrets.json")
                .Build();

            BotToken = configuration.GetSection("Secret:BotToken").Value;
            TestGuild = ulong.Parse(configuration.GetSection("Secret:TestGuild").Value);
            WeatherServiceKey = configuration.GetSection("Secret:WeatherServiceKey").Value;
            ImageServiceKey = configuration.GetSection("Secret:ImageServiceKey").Value;
            ImageServiceCustomEngineKey = configuration.GetSection("Secret:ImageServiceCustomEngineKey").Value;
        }
    }
}

