using FinalAssessment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAssessment.Core.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionApp>
    {
        public void Configure(EntityTypeBuilder<TransactionApp> builder)
        {
            builder.Property(x => x.Service).HasMaxLength(550);
         

             
        }
    }
}
