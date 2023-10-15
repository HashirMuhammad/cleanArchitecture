using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Commands
{
    public class UpdateFormByIdCommand : IRequest<bool>
    {
        public int FormId { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Active { get; set; }
        public string PageType { get; set; }
        public List<AssignedUser> AssignedUsers { get; set; }
        public string PageDesignFile { get; set; }
    }
}
