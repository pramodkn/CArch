using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CArch.Application.Interfaces;
using CArch.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> Get() {
            return Ok(await _movieService.GetMovies());
        }
    }
}