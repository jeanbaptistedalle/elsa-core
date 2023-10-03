using Elsa.Alterations.Core.Contracts;
using Elsa.Alterations.Core.Enums;
using Elsa.Alterations.Core.Filters;
using Elsa.Alterations.Core.Notifications;
using Elsa.Common.Contracts;
using Elsa.Mediator.Contracts;

namespace Elsa.Alterations.BackgroundRunner.Handlers;

public class AlterationJobCompletedHandler : INotificationHandler<AlterationJobCompleted>
{
    private readonly IAlterationPlanStore _alterationPlanStore;
    private readonly IAlterationJobStore _alterationJobStore;
    private readonly ISystemClock _systemClock;

    public AlterationJobCompletedHandler(IAlterationPlanStore alterationPlanStore, IAlterationJobStore alterationJobStore, ISystemClock systemClock)
    {
        _alterationPlanStore = alterationPlanStore;
        _alterationJobStore = alterationJobStore;
        _systemClock = systemClock;
    }
    
    public async Task HandleAsync(AlterationJobCompleted notification, CancellationToken cancellationToken)
    {
        var job = notification.Job;
        var planId = job.PlanId;
        var planFilter = new AlterationPlanFilter { Id = planId };
        var plan = (await _alterationPlanStore.FindAsync(planFilter, cancellationToken))!;

        // Check if all jobs are completed.
        var jobFilter = new AlterationJobFilter
        {
            PlanId = planId,
            Statuses = new[] { AlterationJobStatus.Pending, AlterationJobStatus.Running }
        };
        
        var allJobsCompleted = await _alterationJobStore.CountAsync(jobFilter, cancellationToken) == 0;
        
        if(!allJobsCompleted)
            return;
        
        // Update plan status.
        plan.Status = AlterationPlanStatus.Completed;
        plan.CompletedAt = _systemClock.UtcNow;
        
        await _alterationPlanStore.SaveAsync(plan, cancellationToken);
    }
}