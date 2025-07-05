using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Subs.Enums;
using Subs.Models;
using Subs.ViewModels.Base;
using Subs.Views;
using System.Collections.ObjectModel;

namespace Subs.ViewModels
{
    public partial class SubscriptionViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<SubscriptionModel> _subscriptions;

        public async Task Initialize()
        {
            Subscriptions = new ObservableCollection<SubscriptionModel>
            {
                new SubscriptionModel
                {
                    Id = Guid.NewGuid(),
                    Name = "YouTube Premium",
                    Description = "Ad-free music and videos",
                    Price = 11.99m,
                    Currency = "USD",
                    Interval = IntervalEnum.Monthly,
                    IntervalCount = 1,
                    IsActive = true,
                    IsTrialPeriod = false,
                    TrialDays = 0,
                    LogoUrl = "https://download.logo.wine/logo/YouTube/YouTube-Logo.wine.png",
                    NextRenewalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(15)),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddMonths(-3)),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Today)
                },
                new SubscriptionModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Spotify Premium",
                    Description = "Unlimited music streaming",
                    Price = 9.99m,
                    Currency = "USD",
                    Interval = IntervalEnum.Monthly,
                    IntervalCount = 1,
                    IsActive = true,
                    IsTrialPeriod = false,
                    TrialDays = 0,
                    LogoUrl = "https://download.logo.wine/logo/Spotify/Spotify-Logo.wine.png",
                    NextRenewalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(20)),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddMonths(-2)),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Today)
                },
                new SubscriptionModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Netflix",
                    Description = "Streaming movies and shows",
                    Price = 15.49m,
                    Currency = "USD",
                    Interval = IntervalEnum.Monthly,
                    IntervalCount = 1,
                    IsActive = true,
                    IsTrialPeriod = false,
                    TrialDays = 0,
                    LogoUrl = "https://download.logo.wine/logo/Netflix/Netflix-Logo.wine.png",
                    NextRenewalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10)),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddMonths(-4)),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Today)
                },
                new SubscriptionModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple Music",
                    Description = "Music streaming service",
                    Price = 10.99m,
                    Currency = "USD",
                    Interval = IntervalEnum.Monthly,
                    IntervalCount = 1,
                    IsActive = false,
                    IsTrialPeriod = true,
                    TrialDays = 30,
                    LogoUrl = "https://download.logo.wine/logo/Apple_Music/Apple_Music-Logo.wine.png",
                    NextRenewalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Today)
                },
                new SubscriptionModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Disney+",
                    Description = "Family entertainment streaming",
                    Price = 7.99m,
                    Currency = "USD",
                    Interval = IntervalEnum.Monthly,
                    IntervalCount = 1,
                    IsActive = true,
                    IsTrialPeriod = false,
                    TrialDays = 0,
                    LogoUrl = "https://download.logo.wine/logo/Disney%2B/Disney%2B-Logo.wine.png",
                    NextRenewalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(5)),
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1)),
                    UpdatedAt = DateOnly.FromDateTime(DateTime.Today)
                }
            };
            await Task.Delay(100);
        }

        [RelayCommand]
        public async Task AddNewSubscriptionAsync()
        {
            await NavigateToModalAsync(nameof(AddSubscriptionPage), true, null);
        }

        [RelayCommand]
        public async Task SubscriptionDetailsAsync(object obj)
        {
            if (obj is not SubscriptionModel subscription || (obj as SubscriptionModel) is null)
                return;

            await NavigateToModalAsync(nameof(SubscriptionDetailsPage), true, new Dictionary<string, object>
            {
                { "Subscription", subscription }
            });
        }
    }
}
