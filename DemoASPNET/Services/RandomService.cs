namespace DemoASPNET.Services
{
    public class RandomService : IRandomService
    {



        readonly Random random = new Random();

        public int GetRandom (int min, int max)
        {

            return random.Next (min, max);

        }
    }
}
