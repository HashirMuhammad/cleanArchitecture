using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Queries
{
    public class GetFormDataQuery : IRequest<FormDataDto>
    {
        public int FormDataId { get; set; }
    }

    public class FormDataDto
    {
        public int Id { get; set; }
        public string PageName { get; internal set; }
        public string PageDescription { get; internal set; }
        public string Active { get; internal set; }
        public string PageType { get; internal set; }
        public List<AssignedUser> AssignedUsers { get; internal set; }
        public string PageDesignFile { get; internal set; }

        // Add other properties as needed
    }
    /* public class GetFormDataQuery : IRequest<List<FormData>>
     {
         internal readonly int formDataId;
     }*/
}
/*public class FormDataWithNamesDto
{
    public int Id { get; set; }
    public string PageName { get; set; }
    public string PageDescription { get; set; }
    public string Active { get; set; }
    public string PageType { get; set; }
    public List<AssignedUser> AssignedUsers { get; set; }
    public string PageDesignFile { get; set; }
}*/