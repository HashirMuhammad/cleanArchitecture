using cleanArchSql.Application.Queries;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cleanArchSql.Application.Handlers
{
    public class GetAllFormDataHandler : IRequestHandler<GetAllFormData, List<FormData>>
    {
        private readonly ApplicationDbContext _db;

        public GetAllFormDataHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<FormData>> Handle(GetAllFormData request, CancellationToken cancellationToken)
        {

            return await _db.FormDatas.ToListAsync();
        }
    }
}
