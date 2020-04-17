using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBotWebHook.Dto;

namespace TelegramBotWebHook.Data
{
    public static class StaticDatabase
    {
        public static List<UserDto> DB_Users { get; set; } = new List<UserDto>();
        public static List<string> DB_Texts { get; set; } = new List<string>();
    }
}
