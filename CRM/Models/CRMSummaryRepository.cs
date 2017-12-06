using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CRM.Models
{   
	public  class CRMSummaryRepository : EFRepository<CRMSummary>, ICRMSummaryRepository
	{
        public override IQueryable<CRMSummary> All()
        {
            return base.All().Where(x => x.IsDeleted != true);
        }
    }

	public  interface ICRMSummaryRepository : IRepository<CRMSummary>
	{

	}
}