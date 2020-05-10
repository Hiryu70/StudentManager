//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace StudentManager.Application.Students.Commands.CreateStudent
//{
//	class CreateStudentCommandHandler
//	{
//		public class Handler : IRequestHandler<CreateStudentCommand>
//		{
//			private readonly INorthwindDbContext _context;
//			private readonly IMediator _mediator;

//			public Handler(INorthwindDbContext context, IMediator mediator)
//			{
//				_context = context;
//				_mediator = mediator;
//			}

//			public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
//			{
//				var entity = new Student
//				{
//					Id = request.Id,
//				};

//				_context.Customers.Add(entity);

//				await _context.SaveChangesAsync(cancellationToken);

//				await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

//				return Unit.Value;
//			}
//		}
//    }
//}
