using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<Response<EmployeeVM>> Get(int id, CancellationToken cancellationToken);
        Task<Response<List<EmployeeVM>>> GetAll(CancellationToken cancellationToken);
        Task<Response<EmployeeVM>> Insert(RequestEmployee request, CancellationToken cancellationToken);
        Task<Response<EmployeeVM>> Update(RequestEmployee request, CancellationToken cancellationToken);
        Task<Response<bool>> Delete(int id, CancellationToken cancellationToken);
    }
}
