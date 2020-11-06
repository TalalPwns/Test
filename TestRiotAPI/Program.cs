using MingweiSamuel.Camille;
using MingweiSamuel.Camille.Enums;
using System;

namespace TestRiotAPI
{
    class Program
    {
        const string API_KEY = "RGAPI-5e874468-1ca7-41cf-8686-9c07e6ef69ce";
        static void Main(string[] args)
        {

            var riotApi = RiotApi.NewInstance(API_KEY);
            Console.WriteLine("Hello World!");
           var test = riotApi.SummonerV4.GetBySummonerName(Region.NA, "Kakuzo");

            
            
                Console.WriteLine($"{test.Name}'s Top 10 Champs:");

                var masteries =
                    riotApi.ChampionMasteryV4.GetAllChampionMasteries(Region.NA, test.Id);

                for (var i = 0; i < 10; i++)
                {
                    var mastery = masteries[i];
                    // Get champion for this mastery.
                    var champ = (Champion)mastery.ChampionId;
                    // print i, champ id, champ mastery points, and champ level
                    Console.WriteLine("{0,3}) {1,-16} {2,10:N0} ({3})", i + 1, champ.Name(),
                        mastery.ChampionPoints, mastery.ChampionLevel);
                }
                Console.WriteLine();
        }
    }
    
}
