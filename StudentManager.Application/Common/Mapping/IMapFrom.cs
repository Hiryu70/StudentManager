using AutoMapper;

namespace StudentManager.Application.Common.Mapping
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}
