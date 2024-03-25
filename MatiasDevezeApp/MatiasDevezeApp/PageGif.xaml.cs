namespace MatiasDevezeApp
{
	public partial class PageGif : ContentPage
	{
		public PageGif()
		{
			InitializeComponent();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(100);
            ShrekGif.IsAnimationPlaying = true;
        }
    }
}