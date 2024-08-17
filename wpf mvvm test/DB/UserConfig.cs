using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_mvvm_test.Models;

namespace wpf_mvvm_test.DB
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x=>x.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x=>x.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new List<User>
                {
                    new User
                    {
                        Id = 1,
                        Name = "test",
                        Email = "testemail@gmail.com",
                        Password = "12345"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "test2",
                        Password= "12345",
                        Email = "test2email@gmail.com"
                    },
                    new User
                    {
                        Id = 3,
                        Name = "test3",
                        Email = "test3email@gmail.com",
                        Password = "12345"
                    }
                }
                );

        }
    }
}
