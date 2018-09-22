using CollectorApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.DataAccess.SQL
{
    public class DataContext : DbContext
    {
		public DataContext()
			: base("DefaultConnection")
		{
		}

		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<BorrowedSubject> BorrowedSubjects { get; set; }

	}
}
