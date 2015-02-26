using RentalMobile.Model.Models;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;

namespace RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly
{
    ////////////////////////TO BE DELETED////////////////////////////////
    //to be deleted after all the cleanning , necessary for the build and its reference
    public class RepositroyTest
    {
        private readonly RentalContext _context;
        public RepositroyTest()
        {
            // _context = new RentalContext();
            UnitRepository2 = new UnitRepository(_context);
        }
        public RepositroyTest(RentalContext context)
        {
            _context = context;
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        //Over here to simply , we have passed the repository , for our case we passed the unit of work
        public RepositroyTest(IUnitRepository unitRepository)
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
