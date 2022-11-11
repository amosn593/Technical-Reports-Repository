using AutoMapper;
using AzureBlobStorage.Interfaces;
using DOMAIN.IConfiguration;
using DOMAIN.Models;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            try
            {
                _logger.LogInformation($"Getting Books on BookController on Get method at {DateTime.Now}");
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
                _logger.LogError($"Something went wrong gettings Books on BookController on Get method at {DateTime.Now} with Error {Ex}");
                return BadRequest();
            }
        }

        // GET api/<BookController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Gettin  Book by Id on BookController on Get Method at {DateTime.Now}");

                var book = await _unitOfWork.Book.FindById(id);

                var bookdto = _mapper.Map<BookDTO>(book);

                return Ok(bookdto);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong Getting Book By Id on BookController Get Method at {DateTime.Now} with Error {ex}");
                return BadRequest();

            }
        }

        // GET api/<BookController>/5
        [HttpGet("GetByCategoryName/{CategoryName}")]
        public async Task<IActionResult> GetBookByCategory(string categoryname)
        {
            try
            {
                _logger.LogInformation($"Getting Books by categoryname on BookController on GetBookByCategory Method at {DateTime.Now}");

                var book = await _unitOfWork.Book.FindByCategory(categoryname);

                //var bookdto = _mapper.Map<BookDTO>(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong Getting Book By categoryname on BookController GetBookByCategory Method at {DateTime.Now} with Error {ex}");
                return BadRequest();

            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromServices] IFileUpload _ifileupload, [FromForm] BookCreateDTO bookCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _logger.LogInformation($"Posting Book on BookController on Post Method at {DateTime.Now}");

                var book = _mapper.Map<Book>(bookCreateDTO);

                var imageupload = await _ifileupload.ImageUpload(bookCreateDTO.ImageFile);

                book.PostDate = DateTime.Now;

                book.ImageUrl = imageupload.Url;

                _unitOfWork.Book.Create(book);

                await _unitOfWork.Save();

                return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong Posting Book on BookController Post Method at {DateTime.Now} with Error {ex}");
                return BadRequest();
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting Book on BookController on Delete Method at {DateTime.Now}");

                var book = await _unitOfWork.Book.FindById(id);

                if( book == null)
                {
                    return BadRequest("Book with that Id not found!!!");
                }

                _unitOfWork.Book.Delete(book);

                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong Deleting Book By Id on BookController Delete Method at {DateTime.Now} with Error {ex}");
                return BadRequest();
            }
        }
    }
}
