using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CRM.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(x => x.IsDeleted != true);
        }

        public 客戶聯絡人 Find(int? id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public List<客戶資料> Get客戶資料List()
        {
            var Repo = RepositoryHelper.Get客戶資料Repository(this.UnitOfWork);
            return Repo.All().ToList();
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}