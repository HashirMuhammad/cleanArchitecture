using cleanArchSql.Models;
using MediatR;

namespace cleanArchSql.Application.Commands
{
    public class SaveFormDataCommand : IRequest<FormData>
    {
        public FormData FormData { get; set; }
    }
}
/*public class SaveFormDataDtoCommand : IRequest<PageInputDto>
{
    public PageInputDto FormData { get; set; }
}*/