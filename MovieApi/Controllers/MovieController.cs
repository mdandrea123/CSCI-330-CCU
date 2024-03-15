using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
            new Movie { Name = "Citizen Kane", Genre = "Drama", Year = 1941 },
            new Movie { Name = "The Wizard of Oz", Genre = "Fantasy", Year = 1939 },
            new Movie { Name = "The Godfather", Genre = "Drama", Year = 1972 },
        };

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            if (movies != null){
                return Ok(movies);
            }else{
                return BadRequest();
            }
        }

        [HttpGet("{name}", Name = "GetMovie")]
        public IActionResult GetMoviesByName(string name)
        {
            foreach (Movie m in movies)
            {
                if (m.Name == name)
                {
                    return Ok(m);
                }
            }
            return BadRequest();
        }

        [HttpGet("year/")]
        public IActionResult GetMovieByYear(int year)
        {
            foreach (Movie m in movies)
            {
                if (m.Year == year)
                {
                    return Ok(m);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {   
            try{
                movies.Add(movie);
                return CreatedAtRoute("GetMovie", new {name= movie.Name}, movie);
            }catch(Exception e){
                return StatusCode(500, e);
            }
            
        }

        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name, Movie movieIn)
        {
            try{
                //movies.add(movie);
                foreach(Movie m in movies){
                    if(m.Name == name){
                        m.Name = movieIn.Name;
                        m.Genre = movieIn.Genre;
                        m.Year = movieIn.Year;
                        return NoContent();
                    }
                }
                return BadRequest();
            }catch(Exception e){
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteMovie(string name)
        {
            try{
                foreach(Movie m in movies){
                    if(m.Name == name){
                        movies.Remove(m);
                        return NoContent();
                    }
                }
                return BadRequest();
            }catch(Exception e){
                return StatusCode(500, e);
            }
        }
    }
}
