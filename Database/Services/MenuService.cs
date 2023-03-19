using Database.Models;

namespace Database.Services
{
	internal class MenuService
	{
		public async Task CreateNewIssueAsync()
		{
			var person = new Person();

			Console.Write("Ange förnamn: ");
			person.FirstName = Console.ReadLine() ?? "";

			Console.Write("Ange efternamn: ");
			person.LastName = Console.ReadLine() ?? "";

			Console.Write("Ange email: ");
			person.Email = Console.ReadLine() ?? "";

			Console.Write("Ange telefonnummer: ");
			person.PhoneNumber = Console.ReadLine() ?? "";
			Console.Write("");

			Console.Write("Ange titel på ditt problem: ");
			person.Title = Console.ReadLine() ?? "";

			Console.Write("Ange en beskrivning: ");
			person.Description = Console.ReadLine() ?? "";

			Console.Write("");

			Console.Write("Ange någon av statusarna: ");
			Console.Write("Ej påbörjad ");
			Console.Write("Pågående ");
			Console.Write("Avslutad \n");
			person.StatusName = Console.ReadLine() ?? "";

			person.CreatedAt = DateTime.Now;

			// save issue to database
			await PersonService.SaveAsync(person);
		}
		public async Task ShowAllIssuesAsync()
		{
			// get all customers + addresses from database
			var persons = await PersonService.GetAllAsync();

			if (persons.Any())
			{
				foreach (Person person in persons)
				{
					Console.WriteLine($"Kundnummer: {person.Id}");
					Console.WriteLine($"Namn: {person.FirstName} {person.LastName}");
					Console.WriteLine($"E-postadress: {person.Email}");
					Console.WriteLine($"Telefonnummer: {person.PhoneNumber}");
					Console.WriteLine("");
					Console.WriteLine($"Titel på problemet: {person.Title} ");
					Console.WriteLine($"Beskrivning på problemet: {person.Description} ");
					Console.WriteLine($"Problem skapat: {person.CreatedAt} ");
					Console.WriteLine("");
					Console.WriteLine($"Status på ärendet: {person.StatusName}");
					Console.WriteLine("");
				}
			}
			else
			{
				Console.WriteLine("Inga problem finns i databasen.");
				Console.WriteLine("");
			}

		}
		public async Task ShowOneIssueAsync()
		{

			Console.Write("Ange e-postadress på kunden: ");
			var email = Console.ReadLine();

			if (!string.IsNullOrEmpty(email))
			{
				// get specific issue + status from database
				var person = await PersonService.GetAsync(email);

				if (person != null)
				{
					Console.WriteLine($"Kundnummer: {person.Id}");
					Console.WriteLine($"Namn: {person.FirstName} {person.LastName}");
					Console.WriteLine($"E-postadress: {person.Email}");
					Console.WriteLine($"Telefonnummer: {person.PhoneNumber}");
					Console.WriteLine("");
					Console.WriteLine($"Titel på problemet: {person.Title} ");
					Console.WriteLine($"Beskrivning på problemet: {person.Description} ");
					Console.WriteLine($"Problem skapat: {person.CreatedAt} ");
					Console.WriteLine("");
					Console.WriteLine($"Status på ärendet: {person.StatusName}");
					Console.WriteLine("");
				}
				else
				{
					Console.Clear();
					Console.WriteLine($"Ingen kund med den angivna e-postadresses {email} hittades.");
					Console.WriteLine("");
				}
			}
			else
			{
				Console.WriteLine("Ingen e-postadress angiven.");
				Console.WriteLine("");
			}
		}
		public async Task UpdateIssueAsync()
		{
			Console.Write("Ange e-postadress på kunden: ");
			var email = Console.ReadLine();

			if (!string.IsNullOrEmpty(email))
			{
				var person = await PersonService.GetAsync(email);
				if (person != null)
				{
					Console.WriteLine("Skriv in nya information på de fält som du vill uppdatera. \n");

					Console.Write("Ange förnamn: ");
					person.FirstName = Console.ReadLine() ?? "";

					Console.Write("Ange efternamn: ");
					person.LastName = Console.ReadLine() ?? "";

					Console.Write("Ange email: ");
					person.Email = Console.ReadLine() ?? "";

					Console.Write("Ange telefonnummer: ");
					person.PhoneNumber = Console.ReadLine() ?? "";

					Console.Write("Ange ny titel: ");
					person.Title = Console.ReadLine() ?? "";

					Console.Write("Ange ny beskrivning: ");
					person.Description = Console.ReadLine() ?? "";

					Console.Write("Ange den nya statusen: ");
					Console.Write("Ej påbörjad ");
					Console.Write("Pågående ");
					Console.Write("Avslutad \n");
					person.StatusName = Console.ReadLine() ?? "";

					person.CreatedAt = DateTime.Now;

					// update issue and status from database
					await PersonService.UpdateAsync(person);
				}
				else
				{
					Console.WriteLine("Ingen kund med hittades med den angivna e-postadressen.");
					Console.WriteLine("");
				}
			}
			else
			{
				Console.WriteLine("Ingen e-postadress angiven.");
				Console.WriteLine("");
			}
		}
		public async Task DeleteIssueAsync()
		{

			Console.Write("Ange e-postadress på kunden: ");
			var email = Console.ReadLine();

			if (!string.IsNullOrEmpty(email))
			{
				// delete customer from database
				await PersonService.DeleteAsync(email);
			}
			else
			{
				Console.WriteLine("Ingen e-postadress angiven.");
				Console.WriteLine("");
			}
		}
	}
}
