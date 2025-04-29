using Application.Interfaces;
using Application.Models.BaseResponse;
using Application.Models.SubRequestModel;
using Application.Models.SubResponseModel;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

         public UserService(IUserRepository userRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            _mapper = mapper;
          
        }
        public async Task<Response<UserVM>> Get(int id, CancellationToken cancellationToken)
        {
            var result = new Response<UserVM>();
 
                var user = await _userRepository.Get(id, cancellationToken);

                if (user == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Kullanıcı bulunamadı!";
                    return result;
                }

                var userVm = _mapper.Map<UserVM>(user);
                result.IsSuccess = true;
                result.Data = userVm;
 
                return result;
 
        }
        public async Task<Response<UserVM>> Update(RequestUser request, CancellationToken cancellationToken)
        {
            var result = new Response<UserVM>();
 
                var user = await _userRepository.Get(request.Id, cancellationToken);

                if (user == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Kullanıcı bulunamadı!";
                    return result;
                }

                _mapper.Map(request, user);

                await _userRepository.Update(user, cancellationToken);

                var userVm = _mapper.Map<UserVM>(user);
                result.IsSuccess = true;
                result.Data = userVm;
                result.MessageTitle = "Kullanıcı başarıyla güncellendi.";

                return result;             
        }
 
    }
}
