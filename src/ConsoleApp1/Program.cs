// See https://aka.ms/new-console-template for more information

using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;

var applyFilterCanBuyBeer = true;
Console.WriteLine("Hello, World!");

IEnumerable<int> ints = new List<int> { 1, 2, 3, 4, 5 };

IOrderedEnumerable<int> a = from int i
		in ints
							where i > 4
							orderby i
							select i;

var b = ints
	.Where(x1 => x1 > 4)
	.OrderBy(x => x)
	.Select(x => x);

using (var ctx = new DemoDbContext())
{
	/* optimistic concurrency */

	// we're not loading data yet
	IQueryable<Person> mmm = ctx.Persons.Select(x => x);

	ctx.Persons.Remove(ctx.Persons.First());

	/*

	mmm = 
	SELECT *
	FROM Persons
	WHERE [Person].[PersonAge] >= @param1

	@param1 =18

	 */

	if (applyFilterCanBuyBeer)
	{
		mmm = mmm.Where(x => x.Age >= 18);
	}


	// not yet...
	//EatSoup();



	foreach (var item in mmm)   // <- here we load data
	{
		Console.WriteLine(item.FirstName);
	}

	/* 1st op: we connect to DB and load data into ctx */
	var x = mmm.ToList();
	/* 2nd op: we reuse cached data from ctx */
	ctx.Persons.ToList();

	ctx.Persons.First().FirstName = "John";
	// first Person - status: modified

	/*
	 Statuses:

	Added - you create a new record in code
	Deleted - you delete a record in code
	Modified - you change a record in code
	Loaded - you load a record from the database

	Tracked/untracked
	 */

	ctx.SaveChanges();
}



void EatSoup()
{
	using var ctx = new DemoDbContext();


	using var f = File.OpenRead("file.txt");
	//using var ms = new MemoryStream(f);
	//using var d = new DeflateStream(ms);

	////dasdas

	//using (var f = File.OpenRead("file.txt"))
	//{
	//	using (var ms = new MemoryStream(f))
	//	{
	//		////sads
	//	}

	//}
	//using var d = new DeflateStream(ms);




	var mmm = 123;
}