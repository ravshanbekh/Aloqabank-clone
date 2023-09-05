using Domain.Commons;

namespace Domain.Entities;

public class Deposit:Auditable
{
    public string DepositName { get; set; }
    public string Description { get; set; }
    public string Percentage { get; set; }
    public string MinLifetime { get; set; }
}
