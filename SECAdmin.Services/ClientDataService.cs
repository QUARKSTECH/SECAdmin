using AutoMapper;
using SECAdmin.Data.Infrastructure;
using SECAdmin.Data.Repositories;
using SECAdmin.Entity;
using SECAdmin.Services.Abstract;
using SECAdmin.ViewModel;


namespace SECAdmin.Services
{
    public class ClientDataService :IClientDataService
    {
        private readonly IEntityBaseRepository<ClientDetail> _clientDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientDataService(IEntityBaseRepository<ClientDetail> clientDetailRepository
            , IUnitOfWork unitOfWork)
        {
            _clientDetailRepository = clientDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public void AddUpdateStudentRecords(ClientDetailViewModel clientDataVm)
        {
            var ClientData = Mapper.Map<ClientDetailViewModel, ClientDetail>(clientDataVm);
            _clientDetailRepository.Add(ClientData);
            _unitOfWork.Commit();

        }
    }
}
