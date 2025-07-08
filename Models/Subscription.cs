using SQLite;
using SQLiteNetExtensions.Attributes;
using Subs.Enums;
using Subs.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Models;

[Table("Subscriptions")]
public class Subscription : IEntity
{
    [PrimaryKey]
    public Guid Id { get; set; }

    [Indexed]
    public Guid SubscriptionAppId { get; set; }

    [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
    public SubscriptionApp SubscriptionApp { get; set; } = default!;

    public BillingCycleEnum BillingCycle { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime RenewalDate { get; set; }

    public decimal Price { get; set; }

    public string? Notes { get; set; }

    public bool IsReminderEnabled { get; set; } = true;

    public int DaysBeforeReminder { get; set; } = 3;

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
