using Microsoft.AspNetCore.Mvc;
using ZXAppsBackend.Domain.Entities;
using ZXAppsBackend.Domain.Interfaces;

namespace ZXAppsBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmOperatorController : ControllerBase
    {
        private readonly IOperatorRepository _operatorRepository;

        public TmOperatorController(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        // GET: api/TmOperator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TmOperator>>> GetOperators()
        {
            var operators = await _operatorRepository.GetAllAsync();
            return Ok(operators);
        }

        // GET: api/TmOperator/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TmOperator>> GetOperator(int id)
        {
            var op = await _operatorRepository.GetByIdAsync(id);
            if (op == null)
                return NotFound();

            return Ok(op);
        }
    }
}
