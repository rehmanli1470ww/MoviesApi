using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Dtos;
using MoviesApi.Repositories.Abstracts;
using MoviesApi.Services.Abstracts;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<List<MovieDto>> Get()
        {
            var movies = await _movieService.GetAllAsync();
            var moviesDto = _mapper.Map<List<MovieDto>>(movies);
            return moviesDto;

        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
