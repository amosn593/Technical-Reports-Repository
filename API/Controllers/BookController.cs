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
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Book> _logger;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Book> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<BookController>
        [HttpGet("Getting all books")]
        public async Task<IActionResult>  Get()
        {
            try
            {
                _logger.LogInformation($"Getting Books on BookController at {DateTime.Now}");
                var books = await _unitOfWork.Book.FindAll();

                _logger.LogInformation($"Tranfering Books on BookController to BooksDTO at {DateTime.Now}");
                var booksdto = _mapper.Map<List<BookDTO>>(books);

                //if(booksdto.Count < 1)
                //{
                //    _logger.LogWarning($"No books found on BookController at {DateTime.Now} ");
                //    return NotFound();
                //}

                return Ok(books);
            }
            catch (Exception Ex)
            {
                _logger.LogError($"Something went wrong gettings Books on BookController at {DateTime.Now} with Error {Ex}");
                return BadRequest();
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
