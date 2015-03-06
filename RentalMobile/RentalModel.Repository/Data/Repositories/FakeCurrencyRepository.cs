using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalModel.Repository.Data.Fake;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Data.Repositories
{
    public class FakeCurrencyRepository : FakeGenericRepository<Currency>
    {
        public FakeCurrencyRepository() : base(new FakeCurrencys().MyCurrencys)
        {
        }
        public FakeCurrencyRepository(List<Currency> myCurrency): base(myCurrency)
        {
        }

    }
}
       