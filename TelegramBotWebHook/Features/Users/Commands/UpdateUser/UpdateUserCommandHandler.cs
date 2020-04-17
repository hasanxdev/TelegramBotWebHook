using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TelegramBotWebHook.Data;
using TelegramBotWebHook.Dto;

namespace TelegramBotWebHook.Features.Users.Commands.CreateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, long>
    {
        public Task<long> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            if (StaticDatabase.DB_Users.All(user => user.Id != request.Id))
            {
                // use AutoMapper || use mongoDB
                StaticDatabase.DB_Users.FirstOrDefault(g => g.Id == request.Id).Sex = request.Sex;
            }

            return null;
        }
    }
}
