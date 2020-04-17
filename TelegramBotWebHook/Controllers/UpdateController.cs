using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotWebHook.Data;
using TelegramBotWebHook.Domain;
using TelegramBotWebHook.Dto;
using TelegramBotWebHook.Features.Users.Commands.CreateUser;
using TelegramBotWebHook.Utilities;

namespace TelegramBotWebHook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TelegramBotClient _botClient;

        public UpdateController(TelegramBotClient botClient, IMediator mediator)
        {
            this._mediator = mediator;
            this._botClient = botClient;
        }

        [HttpPost]
        public async Task Post(Update update)
        {
            if (update?.Message?.Text == "/stttart")
            {
                var chat = update.Message.Chat;

                var userDto = new UserDto()
                {
                    Id = chat.Id,
                    FirstName = chat.FirstName,
                    LastName = chat.LastName,
                    UserName = chat.Username,
                    Sex = 0
                };

                var result = _mediator.Send(new CreateUserCommand(userDto));

                var inlineKeyboardInfo = new List<(string text, string callBackValue)>();

                userDto.Sex = SexType.Female;
                var femaleDto = new CallBackDto()
                {
                    CommandQueryName = typeof(CreateUserCommand).Name,
                    Data = JsonSerializer.Serialize(userDto),
                    DataType = typeof(UserDto).Name
                };

                userDto.Sex = SexType.Male;
                var maleDto = new CallBackDto()
                {
                    CommandQueryName = typeof(CreateUserCommand).Name,
                    Data = JsonSerializer.Serialize(userDto),
                    DataType = typeof(UserDto).Name
                };

                string txt = JsonSerializer.Serialize(femaleDto);

                inlineKeyboardInfo.Add(("دختر 🚶🏻‍", JsonSerializer.Serialize(femaleDto)));
                inlineKeyboardInfo.Add(("پسر 🚶‍", JsonSerializer.Serialize(maleDto)));

                var keyboardMarkup = new InlineKeyboardMarkup(TelegramBotExtentions.GetInlineKeyboard(inlineKeyboardInfo));

                long Chat_id = _botClient.SendTextMessageAsync(update.Message.Chat.Id, StaticProvider.ChooseGender, replyMarkup: keyboardMarkup).Result.Chat.Id;

                await Task.CompletedTask;
            }
            //start 

            var callBack = JsonSerializer.Deserialize<CallBackDto>(update.CallbackQuery.Data); ;

            //if (!string.IsNullOrWhiteSpace(callBack.CommandQueryName))
            //{
            //    var assembly = Assembly.GetExecutingAssembly();

            //    var type = assembly.GetTypes()
            //        .First(t => t.Name == callBack.CommandQueryName);

            //    object parameter = JsonSerializer.Deserialize<object>(callBack.Data);

            //    var instance = Activator.CreateInstance(type, parameter);

            //    var result = _mediator.Send(instance);
            //}

            //TODO: set hear

        }
    }
}
