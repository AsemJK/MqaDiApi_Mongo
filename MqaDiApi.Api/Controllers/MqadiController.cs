using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MqaDiApi.Data.Models;
using MqaDiApi.Services;

namespace MqaDiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MqadiController : ControllerBase
    {
        private readonly IMqadiService _mqadiService;

        public MqadiController(IMqadiService mqadiService)
        {
            _mqadiService = mqadiService;
        }
        [HttpGet]
        public async Task<List<Mqadi>> Get()
        {
            var res = await _mqadiService.GetAsync();
            return res;
        }
        [HttpPost("add")]
        public async Task<Mqadi> NewMqadi(Mqadi payload)
        {
            var newAdded = await _mqadiService.CreateAsync(payload);
            return newAdded;
        }
        [HttpPost("done")]
        public async Task MakeDone(string id)
        {
            await _mqadiService.MakeDoneAsync(id);
        }
    }
}
