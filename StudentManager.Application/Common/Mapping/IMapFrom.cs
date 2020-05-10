using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace StudentManager.Application.Common.Mapping
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}
