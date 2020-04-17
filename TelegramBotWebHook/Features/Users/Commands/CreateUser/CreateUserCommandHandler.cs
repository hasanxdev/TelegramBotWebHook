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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        public Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (StaticDatabase.DB_Users.All(user => user.Id != request.Id))
            {
                // use AutoMapper || use mongoDB
                StaticDatabase.DB_Users.Add(new UserDto()
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Sex = request.Sex
                });
            }

            return Task.FromResult<long>(request.Id);

        }
    }
}
