using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Commands
{
    public class UpdateUserByIdCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
