using AvukatProjectCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectRepository.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(   
                               new Category { Id = 1, Name = "Ceza Hukuku" }, 
                               new Category { Id = 2, Name = "Medeni Hukuku" },
                               new Category { Id = 3, Name = "Borçlar Hukuku" });
        }
    }
}
