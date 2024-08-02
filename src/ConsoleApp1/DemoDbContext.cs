using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
	internal class DemoDbContext
		: DbContext
	{
		public DbSet<Person> Persons { get; set; }
	}
}
