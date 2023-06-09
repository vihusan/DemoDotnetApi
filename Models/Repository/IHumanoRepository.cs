using DemoDotnetApi.Models.Data;

namespace DemoDotnetApi.Models.Repository
{
    public interface IHumanoRepository
    {
        Task<Humano> CreateHumanoAsync(Humano humano);
        Task<bool> DeleteHumanoAsync(Humano humano);
        Humano GetHumanoById(int id);
        IEnumerable<Humano> GetHumanos();
        Task<bool> UpdateHumanoAsync(Humano humano);
    }
}
