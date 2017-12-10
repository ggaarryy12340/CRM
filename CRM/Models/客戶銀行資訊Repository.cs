using System;
using System.Linq;
using System.Collections.Generic;
using CRM.Models.ViewModel;

namespace CRM.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(x => x.IsDeleted != true);
        }

        public 客戶銀行資訊 Find(int? id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public List<客戶資料> Get客戶資料List()
        {
            var Repo = RepositoryHelper.Get客戶資料Repository(this.UnitOfWork);
            return Repo.All().ToList();
        }

        public List<客戶銀行資訊> SearchByVM(客戶銀行資訊VM vm)
        {
            var query = this.All();

            if (!string.IsNullOrEmpty(vm.銀行名稱))
            {
                query = query.Where(x => x.銀行名稱.Contains(vm.銀行名稱));
            }
            if (vm.銀行代碼 != null)
            {
                query = query.Where(x => x.銀行代碼 == vm.銀行代碼);
            }
            if (vm.分行代碼 != null)
            {
                query = query.Where(x => x.分行代碼 == vm.分行代碼);
            }
            if (!string.IsNullOrEmpty(vm.帳戶名稱))
            {
                query = query.Where(x => x.帳戶名稱.Contains(vm.帳戶名稱));
            }
            if (!string.IsNullOrEmpty(vm.帳戶號碼))
            {
                query = query.Where(x => x.帳戶號碼.Contains(vm.帳戶號碼));
            }

            return query.ToList();
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}