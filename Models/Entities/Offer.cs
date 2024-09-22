using System;

namespace SqlSearchQuery.Models.Entities;

public class Offer
{
    public int OfferId { get; set; }
    public string NameSurname { get; set; }
    public string JobTittle { get; set; }
    public string JobComment { get; set; }
    public string Email { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyName { get; set; }
    public int CompanyId { get; set; }
    public DateTime OfferTime { get; set; }

}
