﻿using Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_zoo_at_home.Infrastructure.Data.EntityMappingConfiguration.ConcreteMapping
{
    internal class AnimalShelterEntityConfiguration : IEntityTypeConfiguration<AnimalShelter>
    {
        public void Configure(EntityTypeBuilder<AnimalShelter> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Ignore(e => e.ActiveContracts)
                .Ignore(e => e.ArchivedContracts)
                .Ignore(e => e.CompanyPetRepresentatives);

            builder.HasMany(e => e.OwnedPets)
                .WithOne(e => e.Owner as AnimalShelter)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}