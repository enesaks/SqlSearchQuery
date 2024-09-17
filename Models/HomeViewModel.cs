using System;
using SqlSearchQuery.Models.Entities;

namespace SqlSearchQuery.Models;

public class HomeViewModel
{
    public List<Company> Companies { get; set; }
    public List<string> Segments { get; set; }
}
