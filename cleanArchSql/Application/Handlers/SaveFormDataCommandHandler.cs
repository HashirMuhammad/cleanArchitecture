using cleanArchSql.Application.Commands;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Handlers
{
    public class SaveFormDataCommandHandler : IRequestHandler<SaveFormDataCommand, FormData>
    {
        private readonly ApplicationDbContext _db;

        public SaveFormDataCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<FormData> Handle(SaveFormDataCommand request, CancellationToken cancellationToken)
        {

            _db.FormDatas.Add(request.FormData);
            await _db.SaveChangesAsync();
            return request.FormData;
        }
    }
}
/* public class SaveFormDataDtoCommandHandler : IRequestHandler<SaveFormDataDtoCommand, PageInputDto>
    {
        private readonly ApplicationDbContext _db;

        public SaveFormDataDtoCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PageInputDto> Handle(SaveFormDataDtoCommand request, CancellationToken cancellationToken)
        {
           
           
             await  _db.FormDatas.AddAsync(new FormData()
            {
                Active=request.FormData.Active,
                PageDescription=request.FormData.PageDescription,
                PageDesignFile=request.FormData.PageDesignFile,
                PageName=request.FormData.PageName,
                PageType=request.FormData.PageType,
            });
            await _db.SaveChangesAsync();
          var data=await  _db.FormDatas.LastOrDefaultAsync();
           
            foreach (var user in request.FormData.UserIdList)
            {
                _db.AssignedUsers.Add(new AssignedUser()
                {
                    FormDataId= data.Id,
                    IsActive =true,
                    UserId=user,
                    
                });
            }

            await _db.SaveChangesAsync(); // Save changes after updating assignedUsers

            return request.FormData;
        }

    }*/