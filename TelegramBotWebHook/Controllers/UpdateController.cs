using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBotWebHook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly TelegramBotClient botClient;

        public UpdateController(TelegramBotClient botClient)
        {
            this.botClient = botClient;
        }
        [HttpPost]
        public async Task Post(Update update)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "پیام شما دریافت شد :).");

            //TODO: set hear
        }
    }
}
