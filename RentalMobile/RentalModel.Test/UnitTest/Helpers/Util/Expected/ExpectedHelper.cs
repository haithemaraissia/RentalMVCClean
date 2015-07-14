using System.Linq;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.UnitofWork;

namespace TestProject.UnitTest.Helpers.Util.Expected
{
    public  class ExpectedHelper
    {
        private readonly UnitofWork _unitofWork;

        public ExpectedHelper(UnitofWork uow)
        {
            _unitofWork = uow;
        }

        public Agent GetExpectedAgent()
        {
            return _unitofWork.AgentRepository.FindBy(x => x.AgentId == 1).FirstOrDefault();
        }

        public Owner GetExpectedOwner()
        {
            return _unitofWork.OwnerRepository.FindBy(x => x.OwnerId == 1).FirstOrDefault();
        }

        public Tenant GetExpectedTenant()
        {
            return _unitofWork.TenantRepository.FindBy(x => x.TenantId == 5).FirstOrDefault();
        }

        public Specialist GetExpectedSpecialist()
        {
            return _unitofWork.SpecialistRepository.FindBy(x => x.SpecialistId == 1).FirstOrDefault();
        }

        public MaintenanceProvider GetExpectedProvider()
        {
            return _unitofWork.MaintenanceProviderRepository.FindBy(x => x.MaintenanceProviderId == 1).FirstOrDefault();
        }

    }
}
