using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeGeneratedRentalContractRepository : FakeGenericRepository<GeneratedRentalContract>
    {
        public FakeGeneratedRentalContractRepository() : base(new FakeGeneratedRentalContracts().MyGeneratedRentalContracts)
        {
        }
        public FakeGeneratedRentalContractRepository(List<GeneratedRentalContract> myGeneratedRentalContract): base(myGeneratedRentalContract)
        {
        }

    }
}
       