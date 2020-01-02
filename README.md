# HomeFinance
Credit Cards Payments

Main purpose for creation: practice in Angular.

It's Net Core 3.1 / Angular 8 application against SQL Server database
(Originally was created in NetCore 2.2, then it was converted to higher version)


How to use:

1. Set/Verify DB connection (appsettings.json: Server=?)

2. Make sure that next lines in Startup.cs (~ line 64) are uncommented:

			context.Database.EnsureDeleted();
      context.Database.Migrate();        [*]

3. Run the application
	- it creates DB, tables and views
	
4. Input a few Store Pay records using first card, then:

	- select the same card in a list, the closing box appeares
	
	- press "Close Pay Period" button, it closes payment period for a selected
	card's active pay records
	
	- verify that there will be the records in a Closing and Archive screens
	
5.  To suppress the DB recreation, comment [*] lines in Startup.cs (~ line 64):



Resources used:

	- https://www.youtube.com/watch?v=_lwCVE_XgqI 
		NorthwindTraders as Clean Architecture with ASP.NET Core 2.2 - Jason Taylor
		and his NorthwindTraders project on GitHub for NetCore 2.1 (now updated for Net Core 3)

	- Angular/Angular Materials documentation
  
