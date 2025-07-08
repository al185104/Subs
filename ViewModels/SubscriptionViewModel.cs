using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Subs.Data;
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
        private ObservableCollection<Subscription> _subscriptions;

        public SubscriptionViewModel()
        {
            Subscriptions = new ObservableCollection<Subscription>();
        }

        [RelayCommand]
        public async Task OnInitializeAsync()
        {
            Subscriptions.Clear();
            // Load subscriptions from the service
            var subscriptions = await DBService.SubscriptionRepo.GetAllAsync();
            Subscriptions = new ObservableCollection<Subscription>(subscriptions);
        }

        [RelayCommand]
        public async Task AddNewSubscriptionAsync()
        {
            await NavigateToModalAsync(nameof(AddSubscriptionPage), true, null);
        }

        [RelayCommand]
        public async Task SubscriptionDetailsAsync(object obj)
        {
            if (obj is not Subscription subscription || (obj as Subscription) is null)
                return;

            await NavigateToModalAsync(nameof(SubscriptionDetailsPage), true, new Dictionary<string, object>
            {
                { "Subscription", subscription }
            });
        }
    }
}
