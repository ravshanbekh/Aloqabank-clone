using Domain.Commons;

namespace Domain.Entities;

public class BankCard:Auditable
{
    public string CardName { get; set; }
    public decimal CardIssue { get; set; }
    public string ValidityPeriod { get; set; }
    public string Description { get; set; }
}
