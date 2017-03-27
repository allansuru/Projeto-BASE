﻿using EP.IdentityIsolation.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EP.IdentityIsolation.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);


            Property(c => c.SobreNome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired();

        }
    }
}