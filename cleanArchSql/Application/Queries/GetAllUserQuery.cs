using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Queries
{
    public class GetAllUserQuery : IRequest<List<User>>
    {

    }

}
