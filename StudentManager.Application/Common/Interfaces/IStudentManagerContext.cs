using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Common.Interfaces
{
	public interface IStudentManagerContext
	{
		DbSet<Student> Students { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
