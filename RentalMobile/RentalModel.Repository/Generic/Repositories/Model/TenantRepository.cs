using System.Data.Entity;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Generic.Repositories.Model
{
    public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
    {
        public void test()
        {
            
        }
    }
}
