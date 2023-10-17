using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.LangMessages.Configurations
{
    public class LangMessageConfigurations
        : IEntityTypeConfiguration<LangMessage>
    {
        public void Configure(EntityTypeBuilder<LangMessage> builder)
        {
            builder
                .HasOne(current => current.Message)
                .WithMany(current => current.LangMessages)
                .HasForeignKey(p => p.MessageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
