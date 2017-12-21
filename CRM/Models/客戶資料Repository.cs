using System;
using System.Linq;
using System.Collections.Generic;
using CRM.Models.ViewModel;
using System.Linq.Dynamic;

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

        public List<客戶資料> SearchByType(int? 客戶分類Id)
        {
            return this.All().Where(x => x.客戶分類Id == 客戶分類Id).ToList();
        }

        public List<客戶聯絡人> Get客戶聯絡人by客戶資料ID(int? id)
        {
            var Repo = RepositoryHelper.Get客戶聯絡人Repository(this.UnitOfWork);
            return Repo.All().Where(x => x.客戶Id == id).ToList();
        }

        public List<客戶資料> SearchByVM(客戶資料VM vm)
        {
            var query = this.All();

            if (!string.IsNullOrEmpty(vm.客戶名稱))
            {
                query = query.Where(x => x.客戶名稱.Contains(vm.客戶名稱));
            }
            if (vm.客戶分類Id != null)
            {
                query = query.Where(x => x.客戶分類Id == vm.客戶分類Id);
            }
            if (!string.IsNullOrEmpty(vm.統一編號))
            {
                query = query.Where(x => x.統一編號.Contains(vm.統一編號));
            }
            if (!string.IsNullOrEmpty(vm.電話))
            {
                query = query.Where(x => x.電話.Contains(vm.電話));
            }
            if (!string.IsNullOrEmpty(vm.Email))
            {
                query = query.Where(x => x.Email.Contains(vm.Email));
            }
            if (!string.IsNullOrEmpty(vm.排序))
            {
                var propertyInfo = typeof(客戶資料).GetProperty(vm.排序);

                if (!string.IsNullOrEmpty(vm.升降))
                {
                    if (vm.升降 == "降冪")
                    {
                        query = query.OrderBy(string.Format("{0} {1}", vm.排序, "desc"));
                    }
                    else
                    {
                        query = query.OrderBy(string.Format("{0} {1}", vm.排序, "asc"));
                    }
                }
                else
                {
                    query = query.OrderBy(string.Format("{0} {1}", vm.排序, "asc"));
                }
            }

            return query.ToList();
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}