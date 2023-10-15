using cleanArchSql.Application.Commands;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace cleanArchSql.Application.Handlers
{
    public class UpdateFormByIdCommandHandler : IRequestHandler<UpdateFormByIdCommand, bool>
    {
        private readonly ApplicationDbContext _db;

        public UpdateFormByIdCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateFormByIdCommand request, CancellationToken cancellationToken)
        {
            var form = await _db.FormDatas.FindAsync(request.FormId);

            if (form == null)
            {
                return false;
            }

            // Update the properties of the product
            // For example:
            // product.Name = request.NewName;
            
            form.PageName = request.PageName;
            form.PageDescription = request.PageDescription;
            form.Active = request.Active;
            form.PageType = request.PageType;
            //form.AssignedUsers = request.AssignedUsers;
            var formData = await _db.FormDatas
        .Include(f => f.AssignedUsers)
        .FirstOrDefaultAsync(f => f.Id == request.FormId);
            formData.AssignedUsers.Clear();  // Remove existing assigned users

            // Add new assigned users
            form.AssignedUsers = request.AssignedUsers;


            // Save changes to the database
            await _db.SaveChangesAsync();


            form.PageDesignFile = request.PageDesignFile;



            await _db.SaveChangesAsync();

            return true;
        }
    }
}
