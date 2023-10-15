using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Queries
{
    public class GetAllFormData : IRequest<List<FormData>>
    {
    }
}
