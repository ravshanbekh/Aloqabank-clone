namespace Service.DTOs.Transfer;

public class TransferUpdateDto
{
    public long Id { get; set; }
    public string TransferName { get; set; }
    public string TransferType { get; set; }
    public string Description { get; set; }
}
