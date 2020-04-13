using Microsoft.AspNetCore.Mvc.ModelBinding;
using Telegram.Bot.Types;

namespace TelegramBotWebHook.Binder
{
    public class TelegramBotBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Update))
                return new TelegramBotBinder();

            return null;
        }
    }
}
