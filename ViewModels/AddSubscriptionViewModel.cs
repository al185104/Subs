using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fonts;
using Subs.Data;
using Subs.Enums;
using Subs.Models;
using Subs.Services;
using Subs.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Subs.ViewModels
{
    public partial class AddSubscriptionViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<SubscriptionApp> _subscriptionApps;

        [ObservableProperty]
        public ObservableCollection<BillingCycleEnum> _billingCycles;

        [ObservableProperty]
        private SubscriptionApp? _selectedApp;

        // Subscription fields
        [ObservableProperty]
        private DateTime _startDate;

        [ObservableProperty]
        private DateTime _renewalDate;

        [ObservableProperty]
        private decimal _price;

        [ObservableProperty]
        private string _notes;

        [ObservableProperty]
        private BillingCycleEnum _selectedBillingCycle;

        [ObservableProperty]
        private bool _isReminderEnabled = true;

        [ObservableProperty]
        private int _daysBeforeReminder;

        public AddSubscriptionViewModel()
        {
            SubscriptionApps = new ObservableCollection<SubscriptionApp>();

            // Initialize default values
            BillingCycles = Enum.GetValues(typeof(BillingCycleEnum))
                .Cast<BillingCycleEnum>()
                .Where(e => e != BillingCycleEnum.None)
                .ToObservableCollection();
            StartDate = DateTime.Today;
            RenewalDate = DateTime.Today.AddMonths(1);
            Price = 0m;
            IsReminderEnabled = true;
            SelectedBillingCycle = BillingCycleEnum.Monthly;
            Notes = string.Empty;
            DaysBeforeReminder = 3;
        }

        [RelayCommand]
        private async Task OnInitializeAsync()
        {
            SubscriptionApps.Clear();
            var apps = await DBService.SubscriptionAppRepo.GetAllAsync();

            // Seed defaults if none exist
            if (!apps.Any())
            {
                #region Dummy Subscription Apps
                var defaults = new[]
                {
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Spotify Premium",
                        Description = "Ad-free music streaming",
                        Category = FluentUI.music_note_2_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Spotify_New_Full_Logo_RGB_Green.png/960px-Spotify_New_Full_Logo_RGB_Green.png",
                        DefaultPrice = 9.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Netflix",
                        Description = "Watch TV shows and movies online",
                        Category = FluentUI.video_clip_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Netflix_2015_N_logo.svg/2048px-Netflix_2015_N_logo.svg.png",
                        DefaultPrice = 15.49m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Amazon Prime Video",
                        Description = "Streaming of movies, TV shows, and Amazon Originals",
                        Category = FluentUI.video_clip_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Amazon_Prime_logo_%282024%29.svg/640px-Amazon_Prime_logo_%282024%29.svg.png",
                        DefaultPrice = 8.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Disney+",
                        Description = "Streaming service for movies and TV shows from Disney, Pixar, Marvel, Star Wars, and National Geographic",
                        Category = FluentUI.video_clip_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Disney%2B_logo.svg/960px-Disney%2B_logo.svg.png",
                        DefaultPrice = 7.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "YouTube Premium",
                        Description = "Ad-free YouTube and YouTube Music",
                        Category = FluentUI.video_clip_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/YouTube_Premium_logo.svg/640px-YouTube_Premium_logo.svg.png",
                        DefaultPrice = 11.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Microsoft 365",
                        Description = "Suite of productivity applications",
                        Category = FluentUI.briefcase_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Microsoft_365_%282022%29.svg/250px-Microsoft_365_%282022%29.svg.png",
                        DefaultPrice = 6.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Adobe Creative Cloud",
                        Description = "Collection of software for graphic design, video editing, and web development",
                        Category = FluentUI.draw_image_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/Creative_Cloud.svg/330px-Creative_Cloud.svg.png",
                        DefaultPrice = 54.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dropbox",
                        Description = "File hosting service that offers cloud storage",
                        Category = FluentUI.folder_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/23/Dropbox_Logo_01.svg/800px-Dropbox_Logo_01.svg.png",
                        DefaultPrice = 11.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Xbox Game Pass",
                        Description = "Video game subscription service from Microsoft",
                        Category = FluentUI.games_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Xbox_Game_Pass_2020_logo_-_alternative_version_%28colored%29.svg/640px-Xbox_Game_Pass_2020_logo_-_alternative_version_%28colored%29.svg.png",
                        DefaultPrice = 9.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "PlayStation Plus",
                        Description = "Subscription service for PlayStation users",
                        Category = FluentUI.games_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/PlayStation_Plus_second_logo_and_wordmark.svg/512px-PlayStation_Plus_second_logo_and_wordmark.svg.png",
                        DefaultPrice = 9.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Duolingo Super",
                        Description = "Learn a language with no ads and extra features",
                        Category = FluentUI.book_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Duolingo_logo_%282019%29.svg/640px-Duolingo_logo_%282019%29.svg.png",
                        DefaultPrice = 6.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Gemini Advanced",
                        Description = "Access to Google's most capable AI models",
                        Category = FluentUI.sparkle_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Google_Gemini_logo.svg/640px-Google_Gemini_logo.svg.png",
                        DefaultPrice = 19.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Hulu",
                        Description = "Streaming library of TV shows and movies",
                        Category = FluentUI.video_clip_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Hulu_Japan_logo.png/960px-Hulu_Japan_logo.png",
                        DefaultPrice = 7.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "Audible Premium Plus",
                        Description = "Audiobooks and exclusive podcasts",
                        Category = FluentUI.headphones_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Font_Awesome_5_brands_audible.svg/600px-Font_Awesome_5_brands_audible.svg.png",
                        DefaultPrice = 14.95m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    },
                    new SubscriptionApp
                    {
                        Id = Guid.NewGuid(),
                        Name = "LinkedIn Premium",
                        Description = "Career-building features and industry insights",
                        Category = FluentUI.people_24_regular,
                        IconUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/LinkedIn_Logo_2013_%282%29.svg/640px-LinkedIn_Logo_2013_%282%29.svg.png",
                        DefaultPrice = 29.99m,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    }
                };
                #endregion

                foreach (var def in defaults.OrderBy(i => i.Name))
                    await DBService.SubscriptionAppRepo.InsertAsync(def);

                apps = await DBService.SubscriptionAppRepo.GetAllAsync();
            }

            // Populate the collection
            foreach (var app in apps)
                SubscriptionApps.Add(app);

            SelectedApp = SubscriptionApps.FirstOrDefault();
            Price = SelectedApp?.DefaultPrice ?? 0m;
        }

        /// <summary>
        /// Determines if the Save command can execute.
        /// </summary>
        private bool CanSave()
        {
            return SelectedApp != null && RenewalDate >= StartDate;
        }

        /// <summary>
        /// Saves the new Subscription via the service.
        /// </summary>
        [RelayCommand]
        private async Task OnSaveAsync()
        {
            if (!CanSave() || SelectedApp == null)
                return;

            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                SubscriptionAppId = SelectedApp!.Id,
                StartDate = StartDate,
                RenewalDate = RenewalDate,
                Price = Price,
                Notes = Notes,
                BillingCycle = SelectedBillingCycle,
                IsReminderEnabled = IsReminderEnabled,
                DaysBeforeReminder = DaysBeforeReminder
            };

            if(await DBService.SubscriptionRepo.InsertAsync(subscription) > 0)
            {
                // Optionally: show success message
                await Shell.Current.DisplayAlert("Success", "Subscription added successfully!", "OK");
                // Clear fields for next entry
                StartDate = DateTime.Today;
                RenewalDate = DateTime.Today.AddMonths(1);
                Price = 0m;
                Notes = string.Empty;
                IsReminderEnabled = true;
                SelectedApp = SubscriptionApps.FirstOrDefault();
                SelectedBillingCycle = BillingCycleEnum.Monthly;

                var notifyTime = subscription.RenewalDate.AddDays(-DaysBeforeReminder);

                NotificationService.ScheduleRenewalNotification(
                    title: $"Upcoming: {subscription.SubscriptionApp.Name}",
                    message: $"Your {subscription.SubscriptionApp.Name} will renew on {subscription.RenewalDate:MMM dd}",
                    scheduleTime: notifyTime,
                    id: subscription.Id.GetHashCode() // use hash of GUID to generate an int ID
                );

                DaysBeforeReminder = 3;

                await NavigateBackAsync();
            }
            else
                await Shell.Current.DisplayAlert("Error", "Failed to add subscription. Please try again.", "OK");
        }
    }
}
