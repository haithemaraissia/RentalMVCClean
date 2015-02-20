using System;
using System.Data.Entity;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.CommonPattern;
using RentalModel.Repository.Generic.Repositories.Base;
using RentalModel.Repository.ToDelete.CommonPattern;

namespace RentalModel.Repository.Generic.UnitofWork
{
    public class UnitofWork : IGenericUnitofWork
    {
        public  DbContext Context;
      

        public UnitofWork()
        {
            Context = new RentalContext();
        }

        public UnitofWork(DbContext context)
        {
            Context = context;
        }


        private IGenericRepository<Tenant> _tenantRepository;
        private IGenericRepository<Unit> _unitRepository;

        public IGenericRepository<Tenant> TenantRepository
        {
            get { return _tenantRepository ?? (_tenantRepository = new GenericRepository<Tenant>(Context)); }
            set { _tenantRepository = value; }
        }
        public IGenericRepository<Unit> UnitRepository
        {
            get { return _unitRepository ?? (_unitRepository = new GenericRepository<Unit>(Context)); }
            set { _unitRepository = value; }
        }


        public void Save()
        {
            Context.SaveChanges();
        }

        private bool _disposed;



        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
        
        
        




        ////////////////////////TO BE DELETED////////////////////////////////
        //to be deleted after all the cleanning , necessary for the build and its reference
        private readonly RentalContext _rentalContext;
        public void UnitOfWork2()
        {
           // _context = new RentalContext();
            UnitRepository2 = new UnitRepository(_rentalContext);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors

        public UnitofWork(IUnitRepository unitRepository)
        {
            UnitRepository2 = unitRepository;
        }

        public IUnitRepository UnitRepository2
        {
            get;
            private set;
        }
        ////////////////////////TO BE DELETED////////////////////////////////
    }
}
