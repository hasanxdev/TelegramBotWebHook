using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TelegramBotWebHook.Domain;

namespace TelegramBotWebHook.Dto
{
    public class CallBackDto
    {
        public string DataType { get; set; }
        public string Data { get; set; }

        public string CommandQueryName { get; set; }

        //public Type CommandQueryType
        //{
        //    get
        //    {
        //        var assembly = Assembly.GetExecutingAssembly();

        //        var type = assembly.GetTypes()
        //            .First(t => t.Name == CommandQueryTarget);

        //        return type;
        //    }
        //    set { CommandQueryTarget = value.Name; }
        //}

    }
}
