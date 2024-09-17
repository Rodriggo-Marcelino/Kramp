using System.Text.Json.Serialization;

namespace Application.PlanCQ.Commands;

public class UpdatePlanCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
}