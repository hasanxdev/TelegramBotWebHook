using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBotWebHook.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public SexType Sex { get; set; }
    }

    public enum SexType
    {
        Male = 1,
        Female = 2
    }


}
