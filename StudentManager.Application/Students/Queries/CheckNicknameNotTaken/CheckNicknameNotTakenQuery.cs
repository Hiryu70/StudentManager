using System;
using MediatR;

namespace StudentManager.Application.Students.Queries.CheckNicknameNotTaken
{
	public class CheckNicknameNotTakenQuery : IRequest<NicknameNotTakenVm>
	{
		public Guid StudentId { get; set; }
		public string Nickname { get; set; }
	}
}
