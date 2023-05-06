using Application.Abstractions.Common;
using Domain.Primitives.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;

    public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUserService,
        IDateTime dateTime)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,InterceptionResult<int> result,CancellationToken cancellationToken=default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        #region Delete Block
        foreach (var entry in context.ChangeTracker.Entries<IHaveSoftDelete>())
        {

            if (entry.State == EntityState.Added)
            {
                entry.CurrentValues[nameof(IHaveSoftDelete.IsDeleted)] = false;
                entry.CurrentValues[nameof(IHaveSoftDelete.CreatedDate)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveSoftDelete.CreatedBy)] = _currentUserService.UserId??"1";
            }
            if (entry.State == EntityState.Modified)
            {
                entry.CurrentValues[nameof(IHaveSoftDelete.LastModified)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveSoftDelete.LastModifiedBy)] = _currentUserService.UserId;
            }
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues[nameof(IHaveSoftDelete.IsDeleted)] = true;
                entry.CurrentValues[nameof(IHaveSoftDelete.DeletedDate)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveSoftDelete.DeletedBy)] = _currentUserService.UserId;
            }

        }
        #endregion

        #region Audit
        foreach (var entry in context.ChangeTracker.Entries<IHaveAudit>())
        {

            if (entry.State == EntityState.Added)
            { 
                entry.CurrentValues[nameof(IHaveAudit.CreatedDate)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveAudit.CreatedBy)] = _currentUserService.UserId ?? "1";
            }
            if (entry.State == EntityState.Modified)
            {
                entry.CurrentValues[nameof(IHaveAudit.LastModified)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveAudit.LastModifiedBy)] = _currentUserService.UserId;
            }
      

        }
        #endregion

        #region Add

        foreach (var entry in context.ChangeTracker.Entries<IHaveCreator>())
        {

            if (entry.State == EntityState.Added)
            {
                
                entry.CurrentValues[nameof(IHaveCreator.CreatedDate)] = _dateTime.Now;
                entry.CurrentValues[nameof(IHaveCreator.CreatedBy)] = _currentUserService.UserId ?? "1";
            }
          

        }
        #endregion
    }




}
