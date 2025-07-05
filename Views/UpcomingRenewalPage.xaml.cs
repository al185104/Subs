using Subs.ViewModels;

namespace Subs.Views;

public partial class UpcomingRenewalPage : ContentPage
{
	public UpcomingRenewalPage(UpcomingRenewalViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}