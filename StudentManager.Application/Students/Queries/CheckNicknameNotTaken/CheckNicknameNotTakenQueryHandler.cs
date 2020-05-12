using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManager.Application.Common.Interfaces;

namespace StudentManager.Application.Students.Queries.CheckNicknameNotTaken
{
	public class CheckNicknameNotTakenQueryHandler : IRequestHandler<CheckNicknameNotTakenQuery, NicknameNotTakenVm>
	{
		private readonly IStudentManagerContext _context;

		public CheckNicknameNotTakenQueryHandler(IStudentManagerContext context)
		{
			_context = context;
		}

		public async Task<NicknameNotTakenVm> Handle(CheckNicknameNotTakenQuery request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(request.Nickname))
			{
				return new NicknameNotTakenVm { Result = true };
			}

			var student = await _context.Students.FirstOrDefaultAsync(s => s.Nickname == request.Nickname, cancellationToken);
			if (student == null)
			{
				return new NicknameNotTakenVm { Result = true };
			}

			if (student.Id == request.StudentId)
			{
				return new NicknameNotTakenVm { Result = true };
			}

			return new NicknameNotTakenVm { Result = false }; ;
		}
	}
}
