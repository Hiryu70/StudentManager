using System;

namespace StudentManager.Domain.Entities
{
	public class Student
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Patronymic { get; set; }

		public Gender Gender { get; set; }

		public string Nickname { get; set; }
	}
}
