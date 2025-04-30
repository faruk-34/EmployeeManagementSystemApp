using Application.Interfaces;
using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using StackExchange.Redis;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IWorkContext _workContext;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, AppDbContext context, IWorkContext workContext)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _context = context;
            _workContext = workContext;
        }

        public async Task<Response<EmployeeVM>> Get(int id, CancellationToken cancellationToken)
        {
            var result = new Response<EmployeeVM>();

            try
            {
                var eventExist = await _employeeRepository.Get(id, cancellationToken);
                if (eventExist == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Employee bulunamadı.";
                    return result;
                }

                result.IsSuccess = true;
                result.Data = _mapper.Map<EmployeeVM>(eventExist);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<Response<List<EmployeeVM>>> GetAll(CancellationToken cancellationToken)
        {
            var result = new Response<List<EmployeeVM>>();

            var events = await _employeeRepository.GetAll(cancellationToken);
            result.IsSuccess = true;
            result.Data = _mapper.Map<List<EmployeeVM>>(events);
            return result;
        }

        public async Task<Response<EmployeeVM>> Insert(RequestEmployee request, CancellationToken cancellationToken)
        {
            var result = new Response<EmployeeVM>();

            var eventEntity = _mapper.Map<Employee>(request);
            await _employeeRepository.Insert(eventEntity, cancellationToken);

            result.IsSuccess = true;
            result.Data = _mapper.Map<EmployeeVM>(eventEntity);
            result.MessageTitle = "Employee başarıyla oluşturuldu.";
            return result;
        }

        public async Task<Response<EmployeeVM>> Update(RequestEmployee request, CancellationToken cancellationToken)
        {
            var result = new Response<EmployeeVM>();

            var eventExist = await _employeeRepository.Get(request.Id, cancellationToken);
            if (eventExist == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Etkinlik bulunamadı.";
                return result;
            }

            _mapper.Map(request, eventExist);
            await _employeeRepository.Update(eventExist, cancellationToken);

            result.IsSuccess = true;
            result.Data = _mapper.Map<EmployeeVM>(eventExist);
            result.MessageTitle = "Employee başarıyla güncellendi.";

            return result;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var result = new Response<bool>();

            var eventExist = await _employeeRepository.Get(id, cancellationToken);
            if (eventExist == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Employee bulunamadı.";
                return result;
            }

            eventExist.IsDeleted = true;
            await _employeeRepository.Update(eventExist, cancellationToken);
            result.IsSuccess = true;
            result.Data = true;
            result.MessageTitle = "Employee başarıyla silindi.";

            return result;
        }
    }
}
