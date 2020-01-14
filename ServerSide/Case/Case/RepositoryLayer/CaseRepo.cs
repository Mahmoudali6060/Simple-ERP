using AutoMapper;
using Case.DTOs;
using Case.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Case.RepositoryLayer
{
    public class CaseRepo : ICaseRepo
    {
        ICaseDAL _caseDAL;
        private readonly IMapper _mapper;

        public CaseRepo(ICaseDAL caseDAL, IMapper mapper)
        {
            _caseDAL = caseDAL;
            _mapper = mapper;

        }
        public int Add(CasesDTO entity)
        {
            return _caseDAL.Add(_mapper.Map<Cases>(entity));
        }

        public int Delete(long id)
        {
            return _caseDAL.Delete(id);
        }

        public IEnumerable<CasesDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<CasesDTO>>(_caseDAL.GetAll());

        }

        public CasesDTO GetById(long id)
        {
            return _mapper.Map<CasesDTO>(_caseDAL.GetById(id));
        }

        public int Update(CasesDTO entity)
        {
            return _caseDAL.Update(_mapper.Map<Cases>(entity));
        }
    }
}
