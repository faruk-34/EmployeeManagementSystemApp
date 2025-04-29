using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<Response<DepartmentVM>> Get(int id, CancellationToken cancellationToken);
        Task<Response<DepartmentVM>> Insert(RequestDepartment request, CancellationToken cancellationToken);
        Task<Response<DepartmentVM>> Update(RequestDepartment request, CancellationToken cancellationToken);
        Task<Response<bool>> Delete(int id, CancellationToken cancellationToken);
    }
}
