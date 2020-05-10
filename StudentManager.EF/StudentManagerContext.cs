using Microsoft.EntityFrameworkCore;
using StudentManager.Application.Common.Interfaces;
using StudentManager.Domain.Entities;

namespace StudentManager.EF
{
	public class StudentManagerContext : DbContext, IStudentManagerContext
	{
		public StudentManagerContext(DbContextOptions<StudentManagerContext> options):base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
	}
}
