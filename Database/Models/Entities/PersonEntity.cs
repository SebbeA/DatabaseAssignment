using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Database.Models.Entities
{
	[Index(nameof(Email), IsUnique = true)]
	internal class PersonEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[Column(TypeName = "nvarchar(100)")]
		public string Email { get; set; } = null!;

		[Required]
		[Column(TypeName = "char(13)")]
		public string? PhoneNumber { get; set; }

		[Required]
		public int IssueId { get; set; }
		public IssueEntity Issue { get; set; } = null!;

		[Required]
		public int StatusId { get; set; }
		public virtual StatusEntity Status { get; set; } = null!;
	}
}
