using System;
using AutoMapper;
using StudentManager.Application.Common.Mapping;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Students.Queries.GetStudentsList
{
	public class StudentVm : IMapFrom<Student>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public Gender Gender { get; set; }
		public string Nickname { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Student, StudentVm>();
		}
	}
}
