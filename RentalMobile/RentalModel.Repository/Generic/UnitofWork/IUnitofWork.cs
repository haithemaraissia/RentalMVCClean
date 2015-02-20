using System;
using RentalMobile.Models;
using RentalModel.Repository.Generic.Repositories.Base;

namespace RentalModel.Repository.Generic.UnitofWork
{
    public interface IGenericUnitofWork :IDisposable
    {
        IGenericRepository<Unit> UnitRepository { get; }
        IGenericRepository<Tenant> TenantRepository { get; }
        void Save();
    }
}
