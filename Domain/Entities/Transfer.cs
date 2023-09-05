using Domain.Commons;

namespace Domain.Entities;

public class Transfer:Auditable
{
    public string TransferName { get; set; }
    public string TransferType { get; set; }
    public string Description { get; set; }
}
