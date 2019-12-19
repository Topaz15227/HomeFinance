Home Finance 
	- credit cards store payment management (store pays)

	It's Net Core 2.2 / Angular 8 application against SQL Server database


1. Set/Verify DB connection (appsettings.json: Server=?)

2. Run the application 
	- it creates DB and shows error message
	
3. Create views using script: Data/HF-Views-Create.sql

4. Refresh browser window
	- the application should work
	
5. Input a few Store Pay records using first card,
	select the same card in a list, then closing box appeared
	
	"Close Pay Period" button click closes payment period for selected
	card' active pays
	
	After that there will be records in a Closing and 
	Archive screens
	
6.  To suppress the DB recreation, comment the next lines in Startup.cs (~ line 64):

	context.Database.EnsureDeleted();
	context.Database.Migrate(); //create views and refresh application


Resources used:

	- https://www.youtube.com/watch?v=_lwCVE_XgqI 
		NorthwindTraders as Clean Architecture with ASP.NET Core 2.2 - Jason Taylor
		and his NorthwindTraders project on gGitHub for NetCore 2.1 (now updated for Net Core 3)

	- Angular/Angular Materials documentation

