using FluentValidation;

namespace StudentManager.Application.Students.Queries.GetStudentDetail
{
	public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
	{
		public GetStudentDetailQueryValidator()
		{
			RuleFor(v => v.Id).NotEmpty();
		}
	}
}
