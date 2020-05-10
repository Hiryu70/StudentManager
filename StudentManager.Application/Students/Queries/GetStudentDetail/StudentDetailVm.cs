using StudentManager.Domain.Entities;
using System;
using AutoMapper;
using StudentManager.Application.Common.Mapping;

namespace StudentManager.Application.Students.Queries.GetStudentDetail
{
	public class StudentDetailVm : IMapFrom<Student>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public Gender Gender { get; set; }
		public string Nickname { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Student, StudentDetailVm>();
		}
	}
}
