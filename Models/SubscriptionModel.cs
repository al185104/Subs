using Subs.Enums;

namespace Subs.Models
{
    public class SubscriptionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = default!;
        public IntervalEnum Interval { get; set; }
        public int IntervalCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrialPeriod { get; set; }
        public int TrialDays { get; set; }
        public string? LogoUrl { get; set; }
        public DateOnly NextRenewalDate { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}
