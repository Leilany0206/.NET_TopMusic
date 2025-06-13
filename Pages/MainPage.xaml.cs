using TopMusic.Models;
using TopMusic.PageModels;

namespace TopMusic.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainPageModel vm)
            {
                _ = vm.LoadRandomImageAsync();
            }
        }
    }
}