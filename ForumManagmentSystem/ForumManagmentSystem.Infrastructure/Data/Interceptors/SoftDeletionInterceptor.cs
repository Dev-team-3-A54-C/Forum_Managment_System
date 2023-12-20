using ForumManagmentSystem.Infrastructure.Data.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ForumManagmentSystem.Infrastructure.Data.Interceptors
{
    internal class SoftDeletionInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;

                entry.State = EntityState.Modified;
                delete.IsDeleted = true;
                delete.DeletedOn = DateTime.Now;

            }

            return result;
        }
    }
}
