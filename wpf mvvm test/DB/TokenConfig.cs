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
            //builder.HasData(new List<Tokenn>
            //{
            //    new Tokenn
            //    {
            //        Id = 1,
            //        UserId = 1,
            //        Value = Guid.NewGuid().ToString(),
            //    },
            //    new Tokenn
            //    {
            //        Id = 2,
            //        UserId = 2,
            //        Value = Guid.NewGuid().ToString(),
            //    },
            //    new Tokenn
            //    {
            //        Id = 3,
            //        UserId = 3,
            //        Value = Guid.NewGuid().ToString(),
            //    }
            //});
        }
    }
}
