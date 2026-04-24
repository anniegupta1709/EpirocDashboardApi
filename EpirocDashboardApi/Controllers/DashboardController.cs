using Microsoft.AspNetCore.Mvc;
using EpirocDashboardApi.Data;
using EpirocDashboardApi.Models;
using MongoDB.Driver;

namespace EpirocDashboardApi.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly MongoContext _context;

    public DashboardController(MongoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Dashboard
            .Find(x => x.Id == "1")
            .FirstOrDefaultAsync();

        return Ok(data);
    }

    // UPDATE SPEED (slider)
    [HttpPost("speed")]
    public async Task<IActionResult> UpdateSpeed([FromBody] int speed)
    {
        var update = Builders<Dashboard>.Update.Set(x => x.Speed, speed);

        await _context.Dashboard.UpdateOneAsync(
            x => x.Id == "1",
            update
        );

        return Ok("Speed updated");
    }

    // TOGGLE CHARGING
    [HttpPost("charge")]
    public async Task<IActionResult> ToggleCharge()
    {
        var data = await _context.Dashboard
            .Find(x => x.Id == "1")
            .FirstOrDefaultAsync();

        if (data == null) return NotFound();

        data.IsCharging = !data.IsCharging;

        await _context.Dashboard.ReplaceOneAsync(
            x => x.Id == "1",
            data
        );

        return Ok(data.IsCharging);
    }
}