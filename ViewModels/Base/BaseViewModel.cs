using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Subs.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
        public BaseViewModel()
        {
            IsBusy = false;
        }

        public async Task NavigateToModalAsync(string route, bool animate = true, IDictionary<string, object>? parameters = null)
        {
            if (Shell.Current == null)
                throw new InvalidOperationException("Shell is not initialized.");

            if (parameters != null)
                await Shell.Current.GoToAsync($"{route}", animate, parameters);
            else
                await Shell.Current.GoToAsync($"{route}", animate);
        }

        public async Task NavigateBackAsync(bool animate = true)
        {
            if (Shell.Current == null)
                throw new InvalidOperationException("Shell is not initialized.");
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.GoToAsync("..", animate);
            }
            else
            {
                // If no previous page, just pop the modal
                await Shell.Current.Navigation.PopModalAsync(animate);
            }
        }
    }
}
