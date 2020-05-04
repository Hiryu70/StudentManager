using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
	public class Student
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(40)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(40)")]
		public string Surname { get; set; }

		[Column(TypeName = "nvarchar(60)")]
		public string Patronymic { get; set; }

		[Required]
		public Gender Gender { get; set; }

		[Column(TypeName = "nvarchar(16)")]
		public string Nickname { get; set; }
	}
}
