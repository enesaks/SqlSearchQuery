using System;

namespace SqlSearchQuery.Models.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string Segment { get; set; }
    public string TaxNo { get; set; }
}
