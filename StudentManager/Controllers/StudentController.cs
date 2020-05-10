using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Students.Commands.CreateStudent;
using StudentManager.Application.Students.Commands.DeleteStudent;
using StudentManager.Application.Students.Queries.GetStudentDetail;
using StudentManager.Application.Students.Commands.UpdateStudent;
using StudentManager.Application.Students.Queries.CheckNicknameNotTaken;
using StudentManager.Application.Students.Queries.GetStudentsList;
using StudentManager.Domain.Entities;

namespace StudentManager.API.Controllers
{
	/// <summary>
	/// Students controller
	/// </summary>
	public class StudentController : BaseController
	{
		/// <summary>
		/// Get all students
		/// </summary>
		/// <returns>List of students</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<StudentsListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetStudentsListQuery { SearchString = string.Empty });

			return Ok(vm);
		}

		/// <summary>
		/// Get all students with filter parameter
		/// </summary>
		/// <param name="query">Filter parameters</param>
		/// <returns>List of students</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<StudentsListVm>> GetAllFiltered([FromBody]GetStudentsListQuery query)
		{
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Get student details
		/// </summary>
		/// <param name="id">Student ID</param>
		/// <returns>Student details</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<StudentDetailVm>> Get(Guid id)
		{
			var vm = await Mediator.Send(new GetStudentDetailQuery { Id = id });

			return Ok(vm);
		}

		/// <summary>
		/// Update student
		/// </summary>
		/// <param name="command">New student details</param>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update([FromBody]UpdateStudentCommand command)
		{
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Create new student
		/// </summary>
		/// <param name="command">New student details</param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Create(CreateStudentCommand command)
		{
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Delete student
		/// </summary>
		/// <param name="id">Student ID</param>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Student>> Delete(Guid id)
		{
			await Mediator.Send(new DeleteStudentCommand { Id = id });

			return NoContent();
		}

		/// <summary>
		/// Check if nickname is already taken
		/// </summary>
		/// <returns>True - nickname not taken. False - nickname already taken</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> CheckNicknameNotTaken([FromBody]CheckNicknameNotTakenQuery query)
		{
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}
	}
}
