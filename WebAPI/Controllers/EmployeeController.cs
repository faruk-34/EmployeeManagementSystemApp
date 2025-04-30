using Application.Interfaces;
using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService userService)
        {
            _employeeService = userService;
        }

        [HttpGet("{id}")]
        public async Task<Response<EmployeeVM>> Get(int id, CancellationToken cancellationToken) => await _employeeService.Get(id, cancellationToken);

        [HttpGet()]  
        public async Task<Response<List<EmployeeVM>>> GetAll( CancellationToken cancellationToken) => await _employeeService.GetAll(cancellationToken);

        [HttpPut]
        public async Task<Response<EmployeeVM>> Update(RequestEmployee request, CancellationToken cancellationToken) => await _employeeService.Update(request, cancellationToken);

        [HttpPost]
        public async Task<Response<EmployeeVM>> Insert(RequestEmployee request, CancellationToken cancellationToken) => await _employeeService.Insert(request, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var response = await _employeeService.Delete(id, cancellationToken);
            return response;
        }
    }
}
