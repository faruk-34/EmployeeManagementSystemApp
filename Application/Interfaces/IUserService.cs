using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Response<UserVM>> Get(int id, CancellationToken cancellationToken);
        Task<Response<UserVM>> Update(RequestUser request, CancellationToken cancellationToken);
     }
}
