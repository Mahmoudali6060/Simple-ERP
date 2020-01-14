using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Case.DataAccessLayer
{
    public class CaseDAL  : ICaseDAL
    {
        public  DB_A48AC5_CaseManagmentContext _context;
        private DbSet<Cases> _entity;

        public CaseDAL(DB_A48AC5_CaseManagmentContext context)
        {
            this._context = context;
            this._entity = context.Set<Cases>();
        }

        public int Add(Cases entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            //AddRange();
            return 1;
        }

        //For testing 
        private void AddRange()
        {
            //For test inserting of 10000000 records >> Performance
            //for (int i = 0; i < 1000000; i++)
            //{
            //    Cases category = new Cases()
            //    {
            //        Name = "Case " + i,
            //        Code = i.ToString()
            //    };
            //    _context.Entry(category).State = EntityState.Added;
            //    _context.SaveChanges();
            //}
        }
        public int Delete(long id)
        {
            Cases @case = GetById(id);
            _context.Cases.Remove(@case);
            _context.SaveChanges();
            return 1;
        }

        public IEnumerable<Cases> GetAll()
        {
            return _context.Cases.AsEnumerable();
            //List<SP_CaseFilter_Result> obj = _context.SP_CaseFilter(Model.page, Model.recordPerPage, model.nameAr, model.nameEn, model.date,
            //     model.caseStageId, model.caseTypeId, model.domesticIndustryId, model.actionTakenId,
            //     model.governmentId, model.caseStatus).ToList();
            //if (obj.Count > 0)
            //{
            //    return obj;
            //}
            //return new List<SP_CaseFilter_Result>();

        }

        public Cases GetById(long id)
        {
            return _context.Cases.SingleOrDefault(x => x.CaseId == id);
        }

        public int Update(Cases entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity.CaseId;
        }
    }
}
