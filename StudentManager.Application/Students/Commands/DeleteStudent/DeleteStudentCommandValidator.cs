using FluentValidation;

namespace StudentManager.Application.Students.Commands.DeleteStudent
{
	public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
	{
		public DeleteStudentCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}
