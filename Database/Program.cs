using Database.Services;

var menu = new MenuService();

while (true)
{
	Console.Clear();
	Console.Write("Välkommen! Vänligen ett av följande alternativ (1-6): \n");
	Console.Write("\n");
	Console.WriteLine("1. Skapa ett ärende ");
	Console.WriteLine("2. Visa alla ärenden ");
	Console.WriteLine("3. Visa ett specifik ärende ");
	Console.WriteLine("4. Uppdatera ett specifikt ärende ");
	Console.WriteLine("5. Radera ett specifikt ärende ");
	Console.WriteLine("6. Avsluta. \n");


	switch (Console.ReadLine())
	{
		case "1":
			Console.Clear();
			await menu.CreateNewIssueAsync();
			break;

		case "2":
			Console.Clear();
			await menu.ShowAllIssuesAsync();
			break;

		case "3":
			Console.Clear();
			await menu.ShowOneIssueAsync();
			break;

		case "4":
			Console.Clear();
			await menu.UpdateIssueAsync();
			break;

		case "5":
			Console.Clear();
			await menu.DeleteIssueAsync();
			break;

		case "6":
			Environment.Exit(0);
			break;
	}

	Console.WriteLine("\nTryck på valfri knapp för att fortsätta...");
	Console.ReadKey();
}