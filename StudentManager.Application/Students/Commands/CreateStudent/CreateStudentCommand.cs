using MediatR;
using StudentManager.Domain.Entities;
using System;

namespace StudentManager.Application.Students.Commands.CreateStudent
{
	public class CreateStudentCommand : IRequest
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Patronymic { get; set; }

		public Gender? Gender { get; set; }

		public string Nickname { get; set; }
	}
}
