using Elsa.Runtime.Stimuli;

namespace Elsa.Runtime.Models;

public static class Stimulus
{
    public static StandardStimulus Standard(string activityTypeName, string? hash = default, IReadOnlyDictionary<string, object?>? data = default) => new(activityTypeName, hash, data);
}