using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly StudentsContext _context;

		public StudentController(StudentsContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<StudentListDto>> GetStudents()
		{
			var students = await _context.Students.ToListAsync();
			var studentListDto = new StudentListDto
			{
				Students = students,
				TotalCount = students.Count
			};

			return studentListDto;
		}

		[HttpPost("filtred")]
		public async Task<ActionResult<StudentListDto>> GetStudents(FilterParameters filterParameters)
		{
			var searchString = filterParameters.SearchString.ToUpper();
			var students = await _context.Students.Where(s => 
					s.Name.ToUpper().Contains(searchString) ||
					s.Surname.ToUpper().Contains(searchString) ||
					s.Patronymic.ToUpper().Contains(searchString) ||
					s.Nickname.ToUpper().Contains(searchString))
				.ToListAsync();
			var totalStudents = await _context.Students.CountAsync();

			var studentListDto = new StudentListDto
			{
				Students = students, 
				TotalCount = totalStudents
			};

			return studentListDto;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudent(Guid id)
		{
			var student = await _context.Students.FindAsync(id);

			if (student == null)
			{
				return NotFound();
			}

			return student;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutStudent(Guid id, Student student)
		{
			if (id != student.Id)
			{
				return BadRequest();
			}

			_context.Entry(student).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Student>> PostStudent(Student student)
		{
			_context.Students.Add(student);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetStudent", new { id = student.Id }, student);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Student>> DeleteStudent(Guid id)
		{
			var student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}

			_context.Students.Remove(student);
			await _context.SaveChangesAsync();

			return student;
		}

		[HttpPost("nicknameNotTaken")]
		public async Task<ActionResult<bool>> NicknameNotTaken([FromBody]NicknameNotTakenModel model)
		{
			var student = await _context.Students.FirstOrDefaultAsync(s => s.Nickname == model.Nickname);
			if (student == null)
			{
				return true;
			}

			if (student.Id == model.StudentId)
			{
				return true;
			}

			return false;
		}
		private bool StudentExists(Guid id)
		{
			return _context.Students.Any(e => e.Id == id);
		}
	}
}
