using System.Collections.Generic;

namespace StudentManager.Application.Students.Queries.GetStudentsList
{
	public class StudentsListVm
	{
		public int TotalCount { get; set; }
		public IList<StudentLookupDto> Students { get; set; }
	}
}
