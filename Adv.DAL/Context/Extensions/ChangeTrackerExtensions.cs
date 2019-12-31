using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Common;
using Adv.DOMAIN.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Adv.DAL.Context.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ApplyAuditableInformation(this ChangeTracker changeTracker)
        {
            DateTime now = DateTime.Now;
            foreach (var entry in changeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("Created").CurrentValue = now;
                        break;
                    case EntityState.Modified:
                        entry.Property("LastModified").CurrentValue = now;
                        break;
                }
            }
        }
    }
}
