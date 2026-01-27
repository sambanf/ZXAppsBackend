using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZXAppsBackend.Infrastructure;
using ZXAppsBackend.Domain.Entities;

namespace ZXAppsBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TmOperatorController : ControllerBase
{
    private readonly AppDbContext _db;

    public TmOperatorController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/TmOperator
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TmOperator>>> GetOperators()
    {
        var operators = await _db.Operators.ToListAsync();
        return Ok(operators);
    }

    // GET: api/TmOperator/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TmOperator>> GetOperator(int id)
    {
        var op = await _db.Operators.FindAsync(id);
        if (op == null)
            return NotFound();

        return Ok(op);
    }
}
