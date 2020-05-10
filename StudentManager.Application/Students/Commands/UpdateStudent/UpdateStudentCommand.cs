using System;
using MediatR;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Students.Commands.UpdateStudent
{
	public class UpdateStudentCommand : IRequest
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Patronymic { get; set; }

		public Gender? Gender { get; set; }

		public string Nickname { get; set; }
	}
}
