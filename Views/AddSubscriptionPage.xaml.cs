using Subs.ViewModels;

namespace Subs.Views;

public partial class AddSubscriptionPage : ContentPage
{
	public AddSubscriptionPage(AddSubscriptionViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is AddSubscriptionViewModel vm)
        {
            await vm.InitializeCommand.ExecuteAsync(null);
        }
    }
}