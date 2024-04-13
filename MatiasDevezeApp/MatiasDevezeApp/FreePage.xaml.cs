using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MatiasDevezeApp;

public partial class FreePage : ContentPage
{
    private PageBeers pageBeers;
    public ObservableCollection<Beer> Items { get; set; }
    public FreePage()
    {
        InitializeComponent();
        pageBeers = new PageBeers();
        Items = new ObservableCollection<Beer>();
        listView.ItemsSource = Items;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var beers = pageBeers.GetBeers();
        ElementCount.Text = beers.Count.ToString() + " bières présentes";
    }

    private void RandomButtonClicked(object sender, EventArgs e)
    {
        Items.Clear();
        var beers = pageBeers.GetBeers();

        ElementCountSearch.Text = "1 bières trouvées";

        if (beers.Count != 0)
        {
            Random random = new Random();
            var index = random.Next(0, beers.Count);
            Items.Add(new Beer
            {
                Name = beers[index].Name,
                Image = beers[index].Image,
                Price = beers[index].Price,
            });
        }
    }


    private void SearchButtonClicked(object sender, EventArgs e)
    {
        Items.Clear();
        var beers = pageBeers.GetBeers();

        if (string.IsNullOrWhiteSpace(SearchBeer.Text))
        {
            foreach (var beer in beers)
            {
                Items.Add(beer);
            }
        }
        else
        {
            foreach (var beer in beers)
            {
                if (beer.Name.ToLower().Contains(SearchBeer.Text.ToLower()))
                {
                    Items.Add(beer);
                }
            }
        }

        ElementCountSearch.Text = Items.Count.ToString() + " bières trouvées";
    }
}