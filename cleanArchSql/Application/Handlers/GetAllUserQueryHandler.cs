using cleanArchSql.Application.Queries;
using cleanArchSql.Data;
using cleanArchSql.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cleanArchSql.Application.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly ApplicationDbContext _db;

        public GetAllUserQueryHandler(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _db.Users.ToListAsync();
        }

    }
}
