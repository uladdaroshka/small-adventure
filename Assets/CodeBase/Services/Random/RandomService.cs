namespace CodeBase.Services.Random
{
    public class RandomService : IRandomService
    {
        public int Next(int lootMin, int lootMax) => 
            UnityEngine.Random.Range(lootMin, lootMax);
    }
}