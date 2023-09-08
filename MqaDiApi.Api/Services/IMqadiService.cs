using MqaDiApi.Data.Models;

namespace MqaDiApi.Services
{
    public interface IMqadiService
    {
        Task<List<Mqadi>> GetAsync();
        Task<Mqadi> GetAsync(int id);
    }
}
