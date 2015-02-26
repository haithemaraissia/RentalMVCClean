using System;
using System.Collections.Generic;
using System.Linq;
using RentalMobile.Model.Models;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;

namespace TestProject.Before.UnitOfWork
{
    public class DummyRentalRepositoryTest : IUnitRepository
    {
        public List<Unit> MyUnits;

        public DummyRentalRepositoryTest(List<Unit> myUnits)
        {
            MyUnits = myUnits;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return MyUnits;
        }

        public Unit GetUnitByID(int unitId)
        {
            return MyUnits.SingleOrDefault(x => x.UnitId == unitId);
        }

        public void InsertUnit(Unit unit)
        {
           MyUnits.Add(unit);
        }

        public void DeleteUnit(int unitID)
        {
           MyUnits.Remove(GetUnitByID(unitID));
        }

        public void UpdateUnit(Unit unit)
        {
            DeleteUnit(unit.UnitId);
            InsertUnit(unit);
        }

        public void Save()
        {
           // throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
