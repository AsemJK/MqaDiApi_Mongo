using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    }
}
