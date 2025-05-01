using Application.Interfaces;
using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public async Task<Response<DepartmentVM>> Get(int id, CancellationToken cancellationToken) => await _departmentService.Get(id, cancellationToken);

        [HttpGet()]
        public async Task<Response<List<DepartmentVM>>> GetAll(CancellationToken cancellationToken) => await _departmentService.GetAll(cancellationToken);


        [HttpPut]
        public async Task<Response<DepartmentVM>> Update(RequestDepartment request, CancellationToken cancellationToken) => await _departmentService.Update(request, cancellationToken);

        [HttpPost]
        public async Task<Response<DepartmentVM>> Insert(RequestDepartment request, CancellationToken cancellationToken) => await _departmentService.Insert(request, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var response = await _departmentService.Delete(id, cancellationToken);
            return response;
        }
    }
}
