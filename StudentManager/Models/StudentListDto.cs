using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
	public class StudentListDto
	{
		public int TotalCount { get; set; }
		public IEnumerable<Student> Students { get; set; }
	}
}
