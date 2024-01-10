using Apollo.Services;
using Apollo.Models;

namespace Apollo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadSports();

        }
        private async void LoadSports()
        {
            List<Sport> sports = await ApolloAPIService.GetLeagues();


            foreach (Sport sport in sports)
            {
                if (!SportsPicker.Items.Contains(sport.Key))
                {
                    SportsPicker.Items.Add(sport.Key);
                }
            }
        }
      
        
        private async void ButtonShowMatches_ClickedAsync(object sender, EventArgs e)
        {
            /* string selectedSport = (string)SportsPicker.SelectedItem;

             if (selectedSport != null)
             {
                 List<string> selectedSportMatches = allMatches
                     .Where(match => match.SportKey == selectedSport)
                     .Select(match => $"{match.HomeTeam} vs {match.AwayTeam} - {match.Bookmakers.First().Markets.First().Outcomes.First().Name} vs {match.Bookmakers.First().Markets.First().Outcomes.ElementAt(1).Name} vs {match.Bookmakers.First().Markets.First().Outcomes.ElementAt(2).Name}")
                     .ToList();

                 CollectionView.ItemsSource = selectedSportMatches;
             }*/
            string selectedSportKey = SportsPicker.SelectedItem.ToString();
            List<Match> matches = await ApolloAPIService.GetMatchesForSport(selectedSportKey);

            // Assuming you have a MatchesCollectionView in your XAML
            MatchesCollectionView.ItemsSource = matches;
        }



    }
}