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
    }
}
