using cleanArchSql.Application.Queries;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cleanArchSql.Application.Handlers
{
    public class GetFormDataQueryHandler : IRequestHandler<GetFormDataQuery, FormDataDto>
    {
        private readonly ApplicationDbContext _db;

        public GetFormDataQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<FormDataDto> Handle(GetFormDataQuery request, CancellationToken cancellationToken)
        {
            // Retrieve form data from the database
            var formData = await _db.FormDatas
                .Include(fd => fd.AssignedUsers)
                .FirstOrDefaultAsync(fd => fd.Id == request.FormDataId, cancellationToken);

            if (formData == null)
            {
                return null; // Or throw an exception if not found
            }

            // Map the FormData entity to FormDataDto
            var formDataDto = new FormDataDto
            {
                Id = formData.Id, // Assuming Id is a property in FormDataDto
                PageName = formData.PageName,
                PageDescription = formData.PageDescription,
                Active = formData.Active,
                PageType = formData.PageType,
                AssignedUsers = formData.AssignedUsers.ToList(), // Convert to list if not already
                PageDesignFile = formData.PageDesignFile
            };

            // This line will print the assigned users to the console
            // Assuming AssignedUsers is a List of AssignedUser objects
            Console.WriteLine(string.Join(", ", formDataDto.AssignedUsers.Select(user => user.UserName)));

            return formDataDto;
        }

    }


    // Helper method to retrieve assigned usernames
    /*private async Task<List<string>> GetAssignedUsernames(int formDataId)
    {
        // Assuming AssignedUsers is a collection of User entities associated with the FormData
        var assignedUsers = await _db.FormDatas
            .Where(fd => fd.Id == formDataId)
            .SelectMany(fd => fd.AssignedUsers)
            .Select(user => user.UserName) // Assuming User has a property called Username
            .ToListAsync();

        return assignedUsers;
    }*/




    /*public async Task<List<string>> Handle(GetFormDataQueryHandler request, CancellationToken cancellationToken)
    {
        var names = await _db.FormDatas
                            .Where(fd => fd.Id == request.FormDataId)
                            .SelectMany(fd => fd.AssignedUsers.Select(u => u.UserName))
                            .ToListAsync();

        return names;
    }



    public async Task<List<FormData>> Handle(GetFormDataQuery request, CancellationToken cancellationToken)
    {
        var user = await _db.FormDatas
                            .Include(fd => fd.AssignedUsers)
                            .FirstOrDefaultAsync(fd => fd.Id == request.formDataId);

        if (user == null)
        {
            return new List<FormData>(); // Return an empty list
        }

        return new List<FormData> { user };
    }*/
}
/*
public async Task<List<FormDataWithNamesDto>> Handle(GetFormDataWithNamesQuery request, CancellationToken cancellationToken)
{

    var formDataWithNames = await _db.FormDatas
        .Where(fd => fd.Id == request.FormDataId)
        .Select(fd => new FormDataWithNamesDto
        {
            Id = fd.Id,
            PageName = fd.PageName,
            PageDescription = fd.PageDescription,
            Active = fd.Active,
            PageType = fd.PageType,
            PageDesignFile = fd.PageDesignFile
        })
        .ToListAsync(cancellationToken);
    foreach (var item in formDataWithNames)
    {
        var userList = await _db.AssignedUsers.Where(s => s.FormData.Id == item.Id).ToListAsync();
        item.AssignedUsers = userList;
    }
    return formDataWithNames;
}*/