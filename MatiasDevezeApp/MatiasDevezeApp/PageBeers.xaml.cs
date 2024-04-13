using System.Collections.ObjectModel;

namespace MatiasDevezeApp
{
    public partial class PageBeers : ContentPage
    {
        private ApiService _apiService;

        private static List<Beer> _personalBeer = new List<Beer>();
        public ObservableCollection<Beer> Items { get; set; }

        private bool _isApiDataLoaded = false;

        public PageBeers()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Items = new ObservableCollection<Beer>();
            listView.ItemsSource = Items;
        }

        public void AddItem(Beer beer)
        {
            _personalBeer.Add(beer);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!_isApiDataLoaded)
            {
                await LoadApiData();
                _isApiDataLoaded = true;
            }
            LoadPersonalData();
        }

        private async Task LoadApiData()
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
        }
        public void LoadPersonalData() 
        {
            foreach (var beer in _personalBeer)
            {
                Items.Add(new Beer
                {
                    Name = beer.Name,
                    Image = beer.Image,
                    Price = beer.Price
                });
            }
            _personalBeer.Clear();
        }
    }
    public class Beer
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
}
