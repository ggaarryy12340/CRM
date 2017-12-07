using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CRM.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(x => x.IsDeleted != true);
        }

        public 客戶資料 Find(int? id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public List<客戶分類> GetCostomerTypeList()
        {
            var Repo = RepositoryHelper.Get客戶分類Repository(this.UnitOfWork);
            return Repo.All().ToList();
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}