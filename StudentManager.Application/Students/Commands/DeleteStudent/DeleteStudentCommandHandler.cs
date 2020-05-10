using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManager.Application.Common.Exceptions;
using StudentManager.Application.Common.Interfaces;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Students.Commands.DeleteStudent
{
	public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
	{
		private readonly IStudentManagerContext _context;

		public DeleteStudentCommandHandler(IStudentManagerContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.Students
				.FindAsync(request.Id);

			if (entity == null)
			{
				throw new NotFoundException(nameof(Student), request.Id);
			}

			_context.Students.Remove(entity);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
        }
	}
}
