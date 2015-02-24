using System;
using System.Data.Entity;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.CommonPattern;
using RentalModel.Repository.Generic.Repositories.Base;
using RentalModel.Repository.ToDelete.CommonPattern;

namespace RentalModel.Repository.Generic.UnitofWork
{
    public partial class UnitofWork : IGenericUnitofWork
    {
       




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
