using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RentalMobile.Model.Models;
using RentalModel.Repository.Generic.Repositories.Base;
using RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern;

namespace TestProject.Before.UnitOfWork
{
    public class DummyRentalRepositoryTest : IUnitRepository, IGenericRepository<Unit>
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








        public IQueryable<Unit> All
        {
            get { return MyUnits.AsQueryable(); }
        }

        public IQueryable<Unit> AllIncluding(params Expression<Func<Unit, object>>[] includeProperties)
        {
            return MyUnits.AsQueryable(); 
        }

        public IEnumerable<Unit> FindBy(Expression<Func<Unit, bool>> predicate)
        {
            return MyUnits;
        }

        public Unit Single(Expression<Func<Unit, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Unit SingleOrDefault(Expression<Func<Unit, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Unit First(Expression<Func<Unit, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Unit FirstOrDefault(Expression<Func<Unit, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Unit> Except(IQueryable<Unit> excluded)
        {
            return MyUnits.Except(excluded).AsQueryable();
        }

        public int Count()
        {
            return MyUnits.Count();
        }

        public int Count(Expression<Func<Unit, bool>> predicate)
        {
            return MyUnits.Count();
        }

        public Unit Find(Unit entity)
        {
            return MyUnits.SingleOrDefault(x => x.UnitId == entity.UnitId);
        }

        public void Add(Unit entity)
        {
            MyUnits.Add(entity);
        }

        public void Insert(Unit entity)
        {
            MyUnits.Add(entity);
        }

        public void Update(Unit entity)
        {
            DeleteUnit(entity.UnitId);
            InsertUnit(entity);
        }

        public void Edit(Unit entity)
        {
            DeleteUnit(entity.UnitId);
            InsertUnit(entity);
        }

        public void Delete(Unit entity)
        {
            MyUnits.Remove(entity); 
        }



        public void Save()
        {
           // throw new NotImplementedException();
        }

        public Task<IQueryable<Unit>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            MyUnits = null;
        }
    }
}
