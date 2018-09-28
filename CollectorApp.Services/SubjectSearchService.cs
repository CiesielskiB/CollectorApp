using CollectorApp.Core.Contracts;
using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Services
{
	public class SubjectSearchService
	{
		private IRepository<Subject> subjectContext;

		public SubjectSearchService(IRepository<Subject> subjects)
		{
			this.subjectContext = subjects;
		}

		public IQueryable<Subject> SubjetFiltering(SubjectSearchModel filterData)
		{
			IQueryable<Subject> result = subjectContext.Collection();
			
			if(filterData != null)
			{
				if (!string.IsNullOrEmpty(filterData.Category)) result = result.Where(x => x.Category == filterData.Category);
				if (!string.IsNullOrEmpty(filterData.Title)) result = result.Where(x => x.Title.Contains(filterData.Title));
				if (!string.IsNullOrEmpty(filterData.Genre)) result = result.Where(x => x.Genre.Contains(filterData.Genre));
				if (!string.IsNullOrEmpty(filterData.Publisher)) result = result.Where(x => x.Publisher.Contains(filterData.Publisher));
				if (filterData.IsBorrowed.HasValue) result = result.Where(x => x.IsBorrowed == filterData.IsBorrowed);

			}

			return result;
		}

		public Object RouteValuesSearches(SubjectSearchModel filterData)
		{
			var routeValues = new
			{
				filterData.Category,
				filterData.IsBorrowed,
				filterData.Title,
				filterData.Genre,
				filterData.Publisher
			};
			return routeValues;
		}

	}
}
