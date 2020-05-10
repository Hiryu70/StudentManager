using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManager.Application.Common.Interfaces;

namespace StudentManager.Application.Students.Queries.GetStudentsList
{
	public class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, StudentsListVm>
	{
		private readonly IStudentManagerContext _context;
		private readonly IMapper _mapper;

		public GetStudentsListQueryHandler(IStudentManagerContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<StudentsListVm> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
		{
			List<StudentLookupDto> students;
			if (string.IsNullOrEmpty(request.SearchString))
			{
				students = await _context.Students
					.ProjectTo<StudentLookupDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);
			}
			else
			{
				var searchString = request.SearchString.ToUpper();
				students = await _context.Students.Where(s =>
						s.Name.ToUpper().Contains(searchString) ||
						s.Surname.ToUpper().Contains(searchString) ||
						s.Patronymic.ToUpper().Contains(searchString) ||
						s.Nickname.ToUpper().Contains(searchString))
					.ProjectTo<StudentLookupDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);
			}

			var totalStudents = await _context.Students.CountAsync(cancellationToken);

			var vm = new StudentsListVm
			{
				Students = students,
				TotalCount = totalStudents
			};

			return vm;
		}
	}
}
