using Application.Interfaces;
using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;

namespace Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IWorkContext _workContext;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, AppDbContext context, IWorkContext workContext)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _context = context;
            _workContext = workContext;
        }

        public async Task<Response<DepartmentVM>> Get(int id, CancellationToken cancellationToken)
        {
            var result = new Response<DepartmentVM>();

            try
            {
                var eventExist = await _departmentRepository.Get(id, cancellationToken);
                if (eventExist == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Departman bulunamadı.";
                    return result;
                }

                result.IsSuccess = true;
                result.Data = _mapper.Map<DepartmentVM>(eventExist);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<Response<List<DepartmentVM>>> GetAll(CancellationToken cancellationToken)
        {
            var result = new Response<List<DepartmentVM>>();

            var events = await _departmentRepository.GetAll(cancellationToken);
            result.IsSuccess = true;
            result.Data = _mapper.Map<List<DepartmentVM>>(events);
            return result;
        }

        public async Task<Response<DepartmentVM>> Insert(RequestDepartment request, CancellationToken cancellationToken)
        {
            var result = new Response<DepartmentVM>();

            var eventEntity = _mapper.Map<Department>(request);
            await _departmentRepository.Insert(eventEntity, cancellationToken);

            result.IsSuccess = true;
            result.Data = _mapper.Map<DepartmentVM>(eventEntity);
            result.MessageTitle = "Departman başarıyla oluşturuldu.";
            return result;
        }

        public async Task<Response<DepartmentVM>> Update(RequestDepartment request, CancellationToken cancellationToken)
        {
            var result = new Response<DepartmentVM>();

            var eventExist = await _departmentRepository.Get(request.Id, cancellationToken);
            if (eventExist == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Departman bulunamadı.";
                return result;
            }

            _mapper.Map(request, eventExist);
            await _departmentRepository.Update(eventExist, cancellationToken);

            result.IsSuccess = true;
            result.Data = _mapper.Map<DepartmentVM>(eventExist);
            result.MessageTitle = "Departman başarıyla güncellendi.";

            return result;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var result = new Response<bool>();

            var eventExist = await _departmentRepository.Get(id, cancellationToken);
            if (eventExist == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Departman bulunamadı.";
                return result;
            }

            eventExist.IsDeleted = true;
            await _departmentRepository.Update(eventExist, cancellationToken);
            result.IsSuccess = true;
            result.Data = true;
            result.MessageTitle = "Departman başarıyla silindi.";

            return result;
        }
    }
}
