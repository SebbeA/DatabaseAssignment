using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Models.Entities
{
	internal class StatusEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(100)")]
		public string StatusName { get; set; } = null!;
		public ICollection<PersonEntity> Persons { get; set; } = new HashSet<PersonEntity>();
	}
}
