using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManager.Domain.Entities;

namespace StudentManager.EF.Configurations
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.ValueGeneratedOnAdd();

			builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(40);

			builder.Property(e => e.Surname)
				.IsRequired()
				.HasMaxLength(40);

			builder.Property(e => e.Patronymic)
				.HasMaxLength(60);

			builder.Property(e => e.Gender)
				.IsRequired();

			builder.Property(e => e.Nickname)
				.HasMaxLength(16);
		}
	}
}
