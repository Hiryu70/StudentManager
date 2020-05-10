using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Application.Students.Queries.GetStudentsList
{
	class StudentsListVm
	{
		public int TotalCount { get; set; }
		public IList<StudentLookupDto> Students { get; set; }
	}
}
