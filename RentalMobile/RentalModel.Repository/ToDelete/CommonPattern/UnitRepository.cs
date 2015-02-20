using System;
using System.Collections.Generic;
using System.Linq;
using RentalMobile.Model.Models;
using RentalMobile.Models;
using RentalModel.Repository.CommonPattern;
using EntityState = System.Data.Entity.EntityState;

namespace RentalModel.Repository.ToDelete.CommonPattern
{
    public class UnitRepository : IUnitRepository
    {
        private readonly RentalContext _context;

        public UnitRepository()
        {
            _context = new RentalContext();
        }

        public UnitRepository(RentalContext unitContext)
        {
            _context = unitContext;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return _context.Units.Include("UnitPricing").ToList();
        }

        public Unit GetUnitByID(int unitId)
        {
            return _context.Units.Find(unitId);
        }

        public void InsertUnit(Unit unit)
        {
            _context.Units.Add(unit);
        }

        public void DeleteUnit(int unitID)
        {
            var unit = _context.Units.Find(unitID);
            _context.Units.Remove(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
