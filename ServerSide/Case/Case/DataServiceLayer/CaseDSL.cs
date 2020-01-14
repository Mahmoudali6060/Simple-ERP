using Case.DTOs;
using Case.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.DataServiceLayer
{
    public class CaseDSL : ICaseDSL
    {
        ICaseRepo _caseRepo;
        public CaseDSL(ICaseRepo clienRepo)
        {
            this._caseRepo = clienRepo;
        }
        public int Add(CasesDTO entity)
        {
           return _caseRepo.Add(entity);
        }

        public int Delete(long id)
        {
           return _caseRepo.Delete(id);
        }

        public IEnumerable<CasesDTO> GetAll()
        {
            return _caseRepo.GetAll();
        }

        public CasesDTO GetById(long id)
        {
            return _caseRepo.GetById(id);
        }

        public int Update(CasesDTO entity)
        {
           return _caseRepo.Update(entity);
        }
    }
}
