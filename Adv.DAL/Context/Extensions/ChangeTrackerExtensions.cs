using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Adv.DAL.Context.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ApplyAuditableInformation(this ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
        }
    }
}
