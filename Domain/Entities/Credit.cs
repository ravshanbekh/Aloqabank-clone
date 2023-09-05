using Domain.Commons;

namespace Domain.Entities;

public class Credit:Auditable
{
    public string CreditName { get; set; }
    public string Description { get; set; }
    public string Percentage { get; set; }
    public string Lifetime { get; set; }
}
