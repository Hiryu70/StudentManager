using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManager.Application.Common.Interfaces;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Students.Commands.CreateStudent
{
	public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
	{
		private readonly IStudentManagerContext _context;

		public CreateStudentCommandHandler(IStudentManagerContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
		{
			var entity = new Student
			{
				Name = request.Name,
				Surname = request.Surname,
				Patronymic = request.Patronymic,
				Gender = request.Gender.Value,
				Nickname = request.Nickname
			};

			_context.Students.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
