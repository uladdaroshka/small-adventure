namespace CodeBase.Services.Random
{
    public interface IRandomService : IService
    {
        int Next(int lootMin, int lootMax);
    }
}