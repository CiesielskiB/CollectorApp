using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using CollectorApp.Core.Models;
using CollectorApp.Core.Contracts;

namespace CollectorApp.DataAccess.InMemory
{
	public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
	{
		ObjectCache cache = MemoryCache.Default;
		List<T> subjects;
		string className;

		public InMemoryRepository()
		{
			className = typeof(T).Name;
			subjects = cache[className] as List<T>;
			if(subjects == null)
			{
				subjects = new List<T>();
			}
		}

		public void Commit()
		{
			cache[className] = subjects;
		}

		public void Insert(T t)
		{
			subjects.Add(t);
		}

		public void Update(T t)
		{
			T subjectToUpdate = subjects.Find(i => i.Id == t.Id);

			if (subjectToUpdate != null) subjectToUpdate = t;
			else throw new Exception(className + "not found");
		}

		public T Find(string Id)
		{
			T subject = subjects.Find(i => i.Id == Id);
			if (subject != null) return subject;
			else throw new Exception(className + "not found");
		}
		public void Delete(string Id)
		{
			T subjectToDelete = subjects.Find(i => i.Id == Id);
			if (subjectToDelete != null) subjects.Remove(subjectToDelete);
			else throw new Exception(className + "not found");
		}

		public IQueryable<T> Collection()
		{
			return subjects.AsQueryable();
		}
	}
}
