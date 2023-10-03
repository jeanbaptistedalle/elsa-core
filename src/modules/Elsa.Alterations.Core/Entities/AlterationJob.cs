using Elsa.Alterations.Core.Enums;
using Elsa.Common.Entities;

namespace Elsa.Alterations.Core.Entities;

/// <summary>
/// Represents the execution of the plan for an individual workflow instance.
/// </summary>
public class AlterationJob : Entity
{
    /// <summary>
    /// The ID of the plan that this job belongs to.
    /// </summary>
    public string PlanId { get; set; } = default!;
    
    /// <summary>
    /// The ID of the workflow instance that this job applies to.
    /// </summary>
    public string WorkflowInstanceId { get; set; } = default!;
    
    /// <summary>
    /// The status of the job.
    /// </summary>
    public AlterationJobStatus Status { get; set; }
    
    /// <summary>
    /// The serialized log of the job.
    /// </summary>
    public string? SerializedLog { get; set; }
    
    /// <summary>
    /// The resulting serialized workflow state of the job.
    /// </summary>
    public string? SerializedWorkflowState { get; set; }
    
    /// <summary>
    /// The date and time at which the job was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// The date and time at which the job was started.
    /// </summary>
    public DateTimeOffset? StartedAt { get; set; }
    
    /// <summary>
    /// The date and time at which the job was completed.
    /// </summary>
    public DateTimeOffset? CompletedAt { get; set; }
}