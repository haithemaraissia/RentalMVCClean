using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;

namespace RentalModel.Repository.Old.Basic_Respository_Test.TestingRepositoryDirectly.CommonPattern
{
    public interface IUnitRepository : IDisposable
    {
        IEnumerable<Unit> GetUnits();
        Unit GetUnitByID(int unitId);
        void InsertUnit(Unit unit);
        void DeleteUnit(int unitID);
        void UpdateUnit(Unit unit);
        void Save();
    }
}