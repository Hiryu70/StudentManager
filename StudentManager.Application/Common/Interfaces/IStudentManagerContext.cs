using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Common.Interfaces
{
	public interface IStudentManagerContext
	{
		DbSet<Student> Students { get; set; }
	}
}
