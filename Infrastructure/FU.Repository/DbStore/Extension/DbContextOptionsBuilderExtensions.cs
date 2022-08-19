using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.DbStore.Extension
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseSerilog(this DbContextOptionsBuilder optionsBuilder, ILoggerFactory loggerFactory, bool throwOnQueryWarnings = false)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Log(RelationalEventId.TransactionError);

                if (!throwOnQueryWarnings)
                {
                    warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
                }
                else
                {
                    warnings.Log(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning);
                }
            });

            return optionsBuilder;
        }
    }
}
