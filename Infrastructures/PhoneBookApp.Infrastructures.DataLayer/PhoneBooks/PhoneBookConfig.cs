using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBookApp.Domain.Core.PhoneBooks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Infrastructures.DataLayer.PhoneBooks
{
    internal class PhoneBookConfig : IEntityTypeConfiguration<PhoneBook>
    {
        public void Configure(EntityTypeBuilder<PhoneBook> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}
