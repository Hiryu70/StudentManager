using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Models
{
	public class NicknameNotTakenModel
	{
		public Guid StudentId { get; set; }
		public string Nickname { get; set; }
	}
}
