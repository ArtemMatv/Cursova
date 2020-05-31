using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.Fluent_API_Configuration
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(p => p.Message)
                .IsRequired();

            builder.Property(p => p.DateCreated)
                .IsRequired();

            builder.Property(p => p.TopicId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            builder.HasData(new Post()
            {
                Title = "Рівень доступу до даних створено",
                Message = "Перший рівень форуму було щойно створено",
                DateCreated = DateTime.Now,
                TopicId = 1,
                UserId = 1
            });
        }
    }

}
