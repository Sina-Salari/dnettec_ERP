using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.Pages.Configurations
{
    public class PageConfigurations
        : IEntityTypeConfiguration<Domain.Models.Page>

    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder
                .HasOne(current => current.PageTitle)
                .WithMany(current => current.PageTitles)
                .HasForeignKey(p => p.PageTitleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
