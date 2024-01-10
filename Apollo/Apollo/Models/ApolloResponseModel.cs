using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Models
{
    class ApolloResponseModel
    {
        internal List<Sport> sports;

        public string Key { get; set; }
        public string Group { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
        public bool HasOutrights { get; set; }

    }
    public class Sport
    {
        public string Key { get; set; }
        public string Group { get; set; }

    }

}



/*public class Rootobject
{
    public string id { get; set; }
    public string sport_key { get; set; }
    public string sport_title { get; set; }
    public DateTime commence_time { get; set; }
    public string home_team { get; set; }
    public string away_team { get; set; }
    public Bookmaker[] bookmakers { get; set; }
}

public class Bookmaker
{
    public string key { get; set; }
    public string title { get; set; }
    public DateTime last_update { get; set; }
    public Market[] markets { get; set; }
}

public class Market
{
    public string key { get; set; }
    public DateTime last_update { get; set; }
    public Outcome[] outcomes { get; set; }
}

public class Outcome
{
    public string name { get; set; }
    public float price { get; set; }
}
*/