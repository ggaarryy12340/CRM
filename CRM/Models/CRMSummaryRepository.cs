using System;
using System.Linq;
using System.Collections.Generic;
	
namespace CRM.Models
{   
	public  class CRMSummaryRepository : EFRepository<CRMSummary>, ICRMSummaryRepository
	{

	}

	public  interface ICRMSummaryRepository : IRepository<CRMSummary>
	{

	}
}