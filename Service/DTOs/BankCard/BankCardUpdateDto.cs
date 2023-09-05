﻿namespace Service.DTOs.BankCard;

public class BankCardUpdateDto
{
    public long Id { get; set; }
    public string CardName { get; set; }
    public decimal CardIssue { get; set; }
    public string ValidityPeriod { get; set; }
    public string Description { get; set; }
}
