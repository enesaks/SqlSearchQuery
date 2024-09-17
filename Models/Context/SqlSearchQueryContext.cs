using System;
using Microsoft.EntityFrameworkCore;
using SqlSearchQuery.Models.Entities;

namespace SqlSearchQuery.Models.Context;

public class SqlSearchQueryContext : DbContext
{
    public SqlSearchQueryContext(DbContextOptions<SqlSearchQueryContext> options) : base(options)
    {

    }

    public DbSet<Company> Companies { get; set; }


}
