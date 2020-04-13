using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBotWebHook.Binder
{
    public class TelegramBotBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            using (var sr = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                var serializeResult = await sr.ReadToEndAsync();
                var result = JsonConvert.DeserializeObject<Update>(serializeResult);
                bindingContext.Result = ModelBindingResult.Success(result);
            }
        }
    }
}
