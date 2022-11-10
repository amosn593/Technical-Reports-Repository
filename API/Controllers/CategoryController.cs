using AutoMapper;
using DOMAIN.IConfiguration;
using DOMAIN.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Category> _logger;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Category> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        // GET: api/<CategoryController>
        [HttpGet("Getting all Categories")]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation($"Getting categories on CategoryController at {DateTime.Now}");

                var categories = await _unitOfWork.Category.FindAll();

                _logger.LogInformation($"Tranfering Categories on CategoryController to BooksDTO at {DateTime.Now}");

                var categorydto = _mapper.Map<List<CategoryDTO>>(categories);

                return Ok(categorydto);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting categories on CategoryController Get Method at {DateTime.Now} with Error {ex} ");
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            try
            {
                _logger.LogInformation($"Getting category on CategoryController at {DateTime.Now}");

                var category = await _unitOfWork.Category.FindById(id);

                var categorydto = _mapper.Map<CategoryDTO>(category);

                return Ok(categorydto);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while Getting category on CategoryController Get Method at {DateTime.Now} with Error {ex} ");
                return BadRequest(ex.Message);

            }
        }

        // POST api/<CategoryController>
        [HttpPost("Creating a Category")]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _logger.LogInformation($"Posting Category on CategoryController Post Method at {DateTime.Now}");
                
                category.Name.ToLower();

                var cat = _mapper.Map<Category>(category);

                _unitOfWork.Category.Create(cat);

                await _unitOfWork.Save();

                return CreatedAtAction(nameof(Get), new { id = cat.CategoryId }, cat);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while posting category on CategoryController Post Method at {DateTime.Now} with Error {ex} ");
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
