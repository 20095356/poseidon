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
            
            string selectedSportKey = SportsPicker.SelectedItem.ToString();
            List<Match> matches = await ApolloAPIService.GetMatchesForSport(selectedSportKey);

          
            MatchesCollectionView.ItemsSource = matches;
        }



    }
}