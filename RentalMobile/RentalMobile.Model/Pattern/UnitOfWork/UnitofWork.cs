using RentalMobile.Model.Models;
using RentalMobile.Model.Pattern.CommonPattern;

namespace RentalMobile.Model.Pattern.UnitOfWork
{
    public class UnitOfWork
    {
        public readonly RentalContext Context;

        public UnitOfWork()
        {
            Context = new RentalContext();
            UnitRepository = new UnitRepository(Context);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors

        //Over here to simply , we have passed the repository , for our case we passed the unit of work

        public UnitOfWork(IUnitRepository unitRepository)
        {
            UnitRepository = unitRepository;
        }

        public IUnitRepository UnitRepository { get; private set; }
    }
}