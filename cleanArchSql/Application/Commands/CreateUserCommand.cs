using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User NewUser { get; set; }
    }
}
