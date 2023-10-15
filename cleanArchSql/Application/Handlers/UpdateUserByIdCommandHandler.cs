using cleanArchSql.Application.Commands;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cleanArchSql.Application.Handlers
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, bool>
    {
        private readonly ApplicationDbContext _db;

        public UpdateUserByIdCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FindAsync(request.UserId);

            if (user == null)
            {
                return false;
            }

            // Update the properties of the product
            // For example:
            // product.Name = request.NewName;
            user.Name = request.Name;
            user.Address = request.Address;
            user.Phone = request.Phone;

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
