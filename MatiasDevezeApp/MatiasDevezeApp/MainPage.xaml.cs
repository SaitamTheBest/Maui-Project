namespace MatiasDevezeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnShrekButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageGif());
        }
    }
}