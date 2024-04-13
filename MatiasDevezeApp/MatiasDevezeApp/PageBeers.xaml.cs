using System.Collections.ObjectModel;

namespace MatiasDevezeApp
{
    public partial class PageBeers : ContentPage
    {
        private ApiService _apiService;

        public ObservableCollection<Beer> Items { get; set; }

        public PageBeers()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Items = new ObservableCollection<Beer>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadData();
        }

        private async Task LoadData()
        {
            var beers = await _apiService.FetchData();

            foreach (var beer in beers)
            {
                Items.Add(new Beer
                {
                    Name = beer.Name,
                    Image = beer.Image,
                    Price = beer.Price
                });
            }
            listView.ItemsSource = Items;
        }
    }
    public class Beer
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
}
