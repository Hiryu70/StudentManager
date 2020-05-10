using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentManager.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManager.Application.Students.Commands.UpdateStudent
{
	public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
	{
		private readonly IStudentManagerContext _context;

		public UpdateStudentCommandValidator(IStudentManagerContext context)
		{
			_context = context;
			RuleFor(x => x.Name).MaximumLength(40);
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Surname).MaximumLength(40);
			RuleFor(x => x.Surname).NotEmpty();
			RuleFor(x => x.Patronymic).MaximumLength(60);
			RuleFor(x => x.Gender).NotNull();
			RuleFor(x => x.Nickname).MustAsync(UniqueNickname)
				.When(x => !string.IsNullOrEmpty(x.Nickname))
				.WithMessage("Nickname must be unique");
			RuleFor(x => x.Nickname).MaximumLength(16)
				.MinimumLength(6)
				.When(x => !string.IsNullOrEmpty(x.Nickname));
		}

		private async Task<bool> UniqueNickname(UpdateStudentCommand command, string nickname, CancellationToken cancellationToken)
		{
			var student = await _context.Students.FirstOrDefaultAsync(s => s.Nickname == command.Nickname, cancellationToken);
			if (student == null)
			{
				return true;
			}

			if (student.Id == command.Id)
			{
				return true;
			}

			return false;
		}
	}
}
