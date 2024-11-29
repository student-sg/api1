using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stickwebapi.Services;
using stickwebapi.Models;

namespace stickwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly AlertsService _alertsService;

        public AlertsController(AlertsService alertsService) =>
            _alertsService = alertsService;

        [HttpGet]
        public async Task<List<Alert>> Get() =>
            await _alertsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Alert>> Get(string id)
        {
            var alert = await _alertsService.GetAsync(id);

            if (alert is null)
            {
                return NotFound();
            }

            return alert;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Alert newAlert)
        {
            await _alertsService.CreateAsync(newAlert);

            return CreatedAtAction(nameof(Get), new { id = newAlert.Id }, newAlert);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Alert updatedAlert)
        {
            var alert = await _alertsService.GetAsync(id);

            if (alert is null)
            {
                return NotFound();
            }

            updatedAlert.Id = alert.Id;

            await _alertsService.UpdateAsync(id, updatedAlert);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var alert = await _alertsService.GetAsync(id);

            if (alert is null)
            {
                return NotFound();
            }

            await _alertsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
