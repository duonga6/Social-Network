using AutoMapper;
using Microsoft.Extensions.Logging;
using SocialNetwork.DataAccess.Repositories.Interfaces;

namespace SocialNetwork.Business.Services.Implements.Base
{
    public class BaseServices<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        public BaseServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
