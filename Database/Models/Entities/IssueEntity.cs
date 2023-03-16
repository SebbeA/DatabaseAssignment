using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Models.Entities
{
	internal class IssueEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(50)]
		public string Description { get; set; } = null!;

		[Column(TypeName = "datetime2")]
		public DateTime CreatedAt { get; set; }

		public ICollection<PersonEntity> Persons { get; set; } = new HashSet<PersonEntity>();
	}
}
