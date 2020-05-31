using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Fluent_API_Configuration
{
    internal class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired();

            builder.HasMany(t => t.Posts)
                .WithOne(p => p.Topic);

            builder.HasData(new Topic()
            {
                Name = "News"
            });
        }
    }
}
