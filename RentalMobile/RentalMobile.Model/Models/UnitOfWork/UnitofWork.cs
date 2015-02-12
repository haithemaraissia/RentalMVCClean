using RentalMobile.Model.Models;
using RentalMobile.Models.CommonPattern;

namespace RentalMobile.Models.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly RentalContext _context;

        public UnitOfWork()
        {
            _context = new RentalContext();
            UnitRepository = new UnitRepository(_context);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors

        public UnitOfWork(IUnitRepository unitRepository)
        {
            UnitRepository = unitRepository;
        }

        public IUnitRepository UnitRepository
        {
            get;
            private set;
        }
    }
}
