using SQLite;
using Subs.Enums;
using Subs.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Models;

[Table("SubscriptionApps")]
public class SubscriptionApp : IEntity
{
    [PrimaryKey]
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? IconUrl { get; set; }

    public decimal DefaultPrice { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
