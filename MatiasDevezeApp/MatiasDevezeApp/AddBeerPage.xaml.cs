namespace MatiasDevezeApp
{
    public partial class AddBeerPage : ContentPage
    {
        private PageBeers _pageBeers;

        public AddBeerPage()
        {
            InitializeComponent();
            _pageBeers = new PageBeers();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var newBeer = new Beer
            {
                Name = titleEntry.Text,
                Image = imageUrlEntry.Text,
                Price = "$ " + priceEntry.Text // Vous pouvez ajouter une entr�e pour le prix si n�cessaire
            };

            _pageBeers.AddItem(newBeer);
        }
    }
}
