using Database.Contexts;
using Database.Models.Entities;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Services
{
	internal class PersonService
	{
		private static DataContext _context = new DataContext();

		public static async Task SaveAsync(Person person)
		{
			var _personEntity = new PersonEntity
			{
				FirstName = person.FirstName,
				LastName = person.LastName,
				Email = person.Email,
				PhoneNumber = person.PhoneNumber
			};

			var _issueEntity = await _context.Issues.FirstOrDefaultAsync(x => x.Title == person.Title);
			if (_issueEntity != null)
			{
				_personEntity.IssueId = _issueEntity.Id;
			}
			else
			{
				var newIssue = new IssueEntity
				{
					Title = person.Title,
					Description = person.Description,
					CreatedAt = person.CreatedAt
				};

				_context.Add(newIssue);
				await _context.SaveChangesAsync();

				_personEntity.IssueId = newIssue.Id;
			}

			var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusName == person.StatusName);
			if (_statusEntity != null)
			{
				_personEntity.StatusId = _statusEntity.Id;
			}
			else
			{
				var newStatus = new StatusEntity
				{
					StatusName = person.StatusName
				};

				_context.Add(newStatus);
				await _context.SaveChangesAsync();

				_personEntity.StatusId = newStatus.Id;
			}

			_context.Add(_personEntity);
			await _context.SaveChangesAsync();
		}
		public static async Task<IEnumerable<Person>> GetAllAsync()
		{
			var _persons = new List<Person>();

			foreach (var _person in await _context.Persons.Include(x => x.Issue).Include(x => x.Status).ToListAsync())
				_persons.Add(new Person
				{
					Id = _person.Id,
					FirstName = _person.FirstName,
					LastName = _person.LastName,
					Email = _person.Email,
					PhoneNumber = _person.PhoneNumber,
					Title = _person.Issue.Title,
					Description = _person.Issue.Description,
					CreatedAt = _person.Issue.CreatedAt,
					StatusName = _person.Status.StatusName
				});

			return _persons;
		}
		public static async Task<Person> GetAsync(string email)
		{
			var _person = await _context.Persons.Include(x => x.Issue).Include(x => x.Status).FirstOrDefaultAsync(x => x.Email == email);
			if (_person != null)
				return new Person
				{
					Id = _person.Id,
					FirstName = _person.FirstName,
					LastName = _person.LastName,
					Email = _person.Email,
					PhoneNumber = _person.PhoneNumber,
					Title = _person.Issue.Title,
					Description = _person.Issue.Description,
					CreatedAt = _person.Issue.CreatedAt,
					StatusName = _person.Status.StatusName
				};
			else
				return null!;
		}
		public static async Task UpdateAsync(Person person)
		{
			var _personEntity = await _context.Persons.Include(x => x.Issue).Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == person.Id);

			if (_personEntity != null)
			{
				if (!string.IsNullOrEmpty(person.FirstName))
					_personEntity.FirstName = person.FirstName;

				if (!string.IsNullOrEmpty(person.LastName))
					_personEntity.LastName = person.LastName;

				if (!string.IsNullOrEmpty(person.Email))
					_personEntity.Email = person.Email;

				if (!string.IsNullOrEmpty(person.PhoneNumber))
					_personEntity.PhoneNumber = person.PhoneNumber;

				if (!string.IsNullOrEmpty(person.Title))
				{
					var _issueEntity = await _context.Issues.FirstOrDefaultAsync(x => x.Title == person.Title && x.Description == person.Description);
					if (_issueEntity != null)
						_personEntity.IssueId = _issueEntity.Id;
					else
						_personEntity.Issue = new IssueEntity
						{
							Title = person.Title,
							Description = person.Description,
							CreatedAt = person.CreatedAt
						};
				}

				if (!string.IsNullOrEmpty(person.StatusName))
				{
					var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusName == person.StatusName);
					if (_statusEntity != null)
						_personEntity.StatusId = _statusEntity.Id;
					else
						_personEntity.Status = new StatusEntity
						{
							StatusName = person.StatusName
						};
				}

				_context.Update(_personEntity);
				await _context.SaveChangesAsync();
			}
		}
		public static async Task DeleteAsync(string email)
		{
			var person = await _context.Persons
				.Include(x => x.Issue)
				.Include(x => x.Status)
				.FirstOrDefaultAsync(x => x.Email == email);

			if (person != null)
			{
				if (person.Issue != null)
				{
					_context.Remove(person.Issue);
				}

				if (person.Status != null)
				{
					_context.Remove(person.Status);
				}

				_context.Remove(person);
				await _context.SaveChangesAsync();
			}
		}
	}
}
