using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class DomicilioConfiguration
    {

        public class ClassificationConfiguration : _BaseConfiguration<Domicilio>
        {
            public override void Configure(EntityTypeBuilder<Domicilio> builder)
            {
                builder.HasKey(p => p.Id);
            }
        }

    }
}
