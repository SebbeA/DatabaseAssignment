using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Models.Entities
{
	internal class CommentEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string CommentText { get; set; } = null!;

		[Required]
		[Column(TypeName = "datetime2")]
		public DateTime CreatedAt { get; set; }

		[Required]
		public int IssueId { get; set; }
		public IssueEntity Issue { get; set; } = null!;

		[Required]
		public int PersonId { get; set; }
		public PersonEntity Person { get; set; } = null!;
	}
}
