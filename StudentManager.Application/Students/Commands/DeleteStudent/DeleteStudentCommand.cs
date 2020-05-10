using System;
using MediatR;

namespace StudentManager.Application.Students.Commands.DeleteStudent
{
	public class DeleteStudentCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
