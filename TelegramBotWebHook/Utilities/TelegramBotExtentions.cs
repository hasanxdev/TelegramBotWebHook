using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotWebHook.Utilities
{
    public static class TelegramBotExtentions
    {

        public static InlineKeyboardButton[][] GetInlineKeyboard(List<(string text, string callBackData)> inlineKeyboardInfo)
        {
            var keyboardInline = new InlineKeyboardButton[1][];
            var keyboardButtons = new InlineKeyboardButton[inlineKeyboardInfo.Count];
            for (var index = 0; index < inlineKeyboardInfo.Count; index++)
            {
                keyboardButtons[index] = new InlineKeyboardButton
                {
                    Text = inlineKeyboardInfo[index].text ?? "",
                    CallbackData = inlineKeyboardInfo[index].callBackData ?? ""
                };
            }
            keyboardInline[0] = keyboardButtons;
            return keyboardInline;
        }

    }
}
