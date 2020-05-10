using MediatR;

namespace StudentManager.Application.Students.Queries.GetStudentsList
{
	public class GetStudentsListQuery : IRequest<StudentsListVm>
	{
		public string SearchString { get; set; }
	}
}
