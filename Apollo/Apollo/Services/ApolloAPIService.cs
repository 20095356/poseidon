using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using RestSharp;
using Apollo.Models;
using Newtonsoft.Json;

namespace Apollo.Services
{
    static class ApolloAPIService
    {
        static string baseURL = "https://api.the-odds-api.com";


        public static async Task<List<Sport>> GetLeagues()

        {
            List<Sport> leagues = new List<Sport>();

            string endpoint = baseURL + "/v4/sports/?apiKey=6bd2c963cbb083dc1d4b2ded0436bbcc";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                List<ApolloResponseModel> responseModels =
                    JsonConvert.DeserializeObject<List<ApolloResponseModel>>(content);

                foreach (var model in responseModels)
                {
                    leagues.Add(new Sport { Key = model.Key, Group = model.Group });
                }
            }

            return leagues;
        }
        public static async Task<List<Match>> GetMatchesForSport(string sportKey)
        {
            List<Match> matches = new List<Match>();

            string endpoint = baseURL + "/v4/sports/upcoming/odds/?apiKey=6bd2c963cbb083dc1d4b2ded0436bbcc&regions=au&markets=h2h&bookmakers=unibet";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                
                List<ApolloOddsResponseModel> responseModels = JsonConvert.DeserializeObject<List<ApolloOddsResponseModel>>(content);

                foreach (var model in responseModels)
                {
                    if (model.sport_key == sportKey)
                    {
                        var match = new Match
                        {
                            HomeTeam = model.home_team,
                            AwayTeam = model.away_team,
                            Odds = model.bookmakers.First().markets.First().outcomes.ToDictionary(o => o.name, o => o.price)
                        };
                        matches.Add(match);
                    }
                }
            }

            return matches;
        }




    }
}