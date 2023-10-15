using cleanArchSql.Application.Commands;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace cleanArchSql.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ApplicationDbContext _db;

        public CreateUserCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request.NewUser == null) 
            {
                return null;
                    }
            _db.Users.Add(request.NewUser);
            await _db.SaveChangesAsync();
            return request.NewUser;
        }
    }
}
