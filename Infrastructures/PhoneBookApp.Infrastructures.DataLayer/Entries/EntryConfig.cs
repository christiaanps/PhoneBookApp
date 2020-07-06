using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookApp.Domain.Core.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Infrastructures.DataLayer.Entries
{
    internal class EntryConfig : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).HasMaxLength(50);
        }
    }
}
