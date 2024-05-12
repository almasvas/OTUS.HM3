namespace OTUS.HM3
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new();

        public int Generate(int min, int max) => _random.Next(min, max + 1);        
    }
}
