using AutoMapper;
using StudentManager.Application.Common.Exceptions;
using StudentManager.Application.Common.Interfaces;
using StudentManager.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace StudentManager.Application.Students.Queries.GetStudentDetail
{
	public class GetStudentDetailHandler : IRequestHandler<GetStudentDetailQuery, StudentDetailVm>
	{
		private readonly IStudentManagerContext _context;
		private readonly IMapper _mapper;

		public GetStudentDetailHandler(IStudentManagerContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<StudentDetailVm> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
		{
			var entity = await _context.Students
				.FindAsync(request.Id);

			if (entity == null)
			{
				throw new NotFoundException(nameof(Student), request.Id);
			}

			return _mapper.Map<StudentDetailVm>(entity);
		}
	}
}
