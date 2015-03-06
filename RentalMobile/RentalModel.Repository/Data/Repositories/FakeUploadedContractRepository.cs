using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeUploadedContractRepository : FakeGenericRepository<UploadedContract>
    {
        public FakeUploadedContractRepository() : base(new FakeUploadedContracts().MyUploadedContracts)
        {
        }
        public FakeUploadedContractRepository(List<UploadedContract> myUploadedContract): base(myUploadedContract)
        {
        }

    }
}
       