using MqaDiApi.Data.Models;

namespace MqaDiApi.Services
{
    public interface IMqadiService
    {
        Task<List<Mqadi>> GetAsync();
        Task<Mqadi> GetAsync(int id);
        Task<Mqadi> CreateAsync(Mqadi newMqadi);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Mqadi mqadi);
        Task MakeDoneAsync(string id);
    }
}
