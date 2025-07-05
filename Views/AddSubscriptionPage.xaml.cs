using Subs.ViewModels;

namespace Subs.Views;

public partial class AddSubscriptionPage : ContentPage
{
	public AddSubscriptionPage(AddSubscriptionViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}