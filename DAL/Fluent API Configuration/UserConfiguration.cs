﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.Fluent_API_Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasAlternateKey(u => u.UserName);

            builder.Property(u => u.Age);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.AvatarPath);

            builder.Property(u => u.Gender);

            builder.Property(u => u.BannedTo);

            builder.Property(u => u.SilencedTo);

            builder.HasMany(u => u.Comments)
                .WithOne(p => p.User);

            builder.HasMany(u => u.Posts)
               .WithOne(p => p.User)
                .IsRequired();

            builder.Property(u => u.RoleName)
                .IsRequired();

            builder.HasOne(u => u.UserRole);


            builder.HasData(new User()
            {
                Id = 1,
                UserName = "kvazar2569",
                PasswordHash = "cg/+jWvRrsDXTWAvy5oCkTP1K+S/Uti6niwDI0nSsRE=",
                Email = "kvazar2569@gmail.com",
                Age = DateTime.Now.Year - 2001,
                Gender = "Male",
                AvatarPath = "",
                RoleName = "Admin"
            });
        }
    }
}
