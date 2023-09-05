namespace Service.DTOs.Credit;

public class CreditUpdateDto
{
    public long Id { get; set; }
    public string CreditName { get; set; }
    public string Description { get; set; }
    public string Percentage { get; set; }
    public string Lifetime { get; set; }
}
