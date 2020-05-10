using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Application.Students.Queries.GetStudentDetail;

namespace StudentManager.API.Controllers
{
	/// <summary>
	/// Students controller
	/// </summary>
	public class StudentController : BaseController
	{
		//[HttpGet]
		//public async Task<ActionResult<StudentListDto>> GetStudents()
		//{
		//	var vm = await Mediator.Send(new GetStudentsListQuery());

		//	return Ok(vm);
		//}

		//[HttpPost("filtred")]
		//public async Task<ActionResult<StudentListDto>> GetStudents(FilterParameters filterParameters)
		//{

		//}

		/// <summary>
		/// Get student details
		/// </summary>
		/// <param name="id">Student ID</param>
		/// <returns>Student details</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<StudentDetailVm>> GetStudent(Guid id)
		{
			var vm = await Mediator.Send(new GetStudentDetailQuery { Id = id });

			return Ok(vm);
		}

		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutStudent([FromBody]UpdateStudentCommand command)
		//{
		//	await Mediator.Send(command);

		//	return NoContent();
		//}

		//[HttpPost]
		//public async Task<ActionResult<Student>> PostStudent(Student student)
		//{
		//	_context.Students.Add(student);
		//	await _context.SaveChangesAsync();

		//	return CreatedAtAction("GetStudent", new { id = student.Id }, student);
		//}

		//[HttpDelete("{id}")]
		//public async Task<ActionResult<Student>> DeleteStudent(Guid id)
		//{
		//	var student = await _context.Students.FindAsync(id);
		//	if (student == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.Students.Remove(student);
		//	await _context.SaveChangesAsync();

		//	return student;
		//}

		//[HttpPost("nicknameNotTaken")]
		//public async Task<ActionResult<bool>> NicknameNotTaken([FromBody]NicknameNotTakenModel model)
		//{
		//	var student = await _context.Students.FirstOrDefaultAsync(s => s.Nickname == model.Nickname);
		//	if (student == null)
		//	{
		//		return true;
		//	}

		//	if (student.Id == model.StudentId)
		//	{
		//		return true;
		//	}

		//	return false;
		//}
		//private bool StudentExists(Guid id)
		//{
		//	return _context.Students.Any(e => e.Id == id);
		//}
	}
}
