﻿namespace Service.DTOs.Deposit;

public class DepositUpdateDto
{
    public long Id { get; set; }
    public string DepositName { get; set; }
    public string Description { get; set; }
    public string Percentage { get; set; }
    public string MinLifetime { get; set; }
}
