using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManager.Application.Common.Exceptions;
using StudentManager.Application.Common.Interfaces;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Students.Commands.UpdateStudent
{
	public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
	{
		private readonly IStudentManagerContext _context;

		public UpdateStudentCommandHandler(IStudentManagerContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.Students.SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
			if (entity == null)
			{
				throw new NotFoundException(nameof(Student), request.Id);
			}

			entity.Name = request.Name;
			entity.Surname = request.Surname;
			entity.Patronymic = request.Patronymic;
			entity.Gender = request.Gender.Value;
			entity.Nickname = request.Nickname;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
