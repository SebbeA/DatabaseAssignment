namespace Database.Models
{
	internal class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public string StatusName { get; set; } = null!;
	}
}
