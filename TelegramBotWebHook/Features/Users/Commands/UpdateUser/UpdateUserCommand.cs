using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBotWebHook.Domain;
using TelegramBotWebHook.Dto;

namespace TelegramBotWebHook.Features.Users.Commands.CreateUser
{
    public class UpdateUserCommand : IRequest<long>
    {
        public UpdateUserCommand(UserDto userDto)
        {
            Id = userDto.Id;
            FirstName = userDto.FirstName;
            LastName = userDto.LastName;
            UserName = userDto.UserName;
            Sex = userDto.Sex;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public SexType? Sex { get; set; }

    }
}
