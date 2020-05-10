//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace StudentManager.Application.Students.Queries.GetStudentsList
//{
//	class GetStudentsListQueryHandler : IRequestHandler<GetStudentsListQuery, StudentsListVm>
//	{
//		private readonly IStudentManager _context;
//		private readonly IMapper _mapper;

//		public GetStudentsListQueryHandler(IStudentManager context, IMapper mapper)
//		{
//			_context = context;
//			_mapper = mapper;
//		}

//		public async Task<StudentsListVm> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
//		{
//			//var searchString = filterParameters.SearchString.ToUpper();
//			//var students = await _context.Students.Where(s =>
//			//		s.Name.ToUpper().Contains(searchString) ||
//			//		s.Surname.ToUpper().Contains(searchString) ||
//			//		s.Patronymic.ToUpper().Contains(searchString) ||
//			//		s.Nickname.ToUpper().Contains(searchString))
//			//	.ToListAsync();
//			//var totalStudents = await _context.Students.CountAsync();

//			//var studentListDto = new StudentListDto
//			//{
//			//	Students = students,
//			//	TotalCount = totalStudents
//			//};

//			//return studentListDto;



//			var students = await _context.Students
//				.ProjectTo<StudentLookupDto>(_mapper.ConfigurationProvider)
//				.ToListAsync();

//			var vm = new StudentsListVm
//			{
//				Students = students,
//				TotalCount = students.Count
//			};

//			return vm;
//		}


//	}
//}
