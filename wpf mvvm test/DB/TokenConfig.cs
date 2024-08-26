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
    public class TokenConfig : IEntityTypeConfiguration<Tokenn>
    {
        public void Configure(EntityTypeBuilder<Tokenn> builder)
        {
            builder.HasData(new Tokenn
            {
                Id = 1,
                Value = 10
            });
        }
    }
}
