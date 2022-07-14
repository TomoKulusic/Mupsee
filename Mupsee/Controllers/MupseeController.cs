using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MupseeController : ControllerBase
    {
        private readonly IMupseeService _movieService;

        public MupseeController(IMupseeService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Will return number of movies that matches search criteria
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of movie objects</returns>
        [HttpGet("SearchAsync")]
        public async Task<List<Movie>> SearchAsync(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return new List<Movie>();
            }

            var returnList = new List<Movie>() {
                new Movie()
                {
                    Id = "tt0848228",
                    Title = "The Avengers",
                    Image = "https://imdb-api.com/images/original/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_Ratio0.7273_AL_.jpg",
                    Description =  "(2012)",
                    MovieRatings = {
                       ImdbRating = "8",
                       RottenTomatoesRating = "91",
                    },
                    MovieTrailerResponseItems = {
                        new MovieTrailer() { 
                            TrailerId = "eOrNdBpGMv8",
                            Title = "Marvel&#39;s The Avengers- Trailer (OFFICIAL)"
                        }
                    }
                },
                new Movie()
                {
                    Id = "tt4154756",
                    Title ="Avengers: Infinity War",
                    Image = "https://imdb-api.com/images/original/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_Ratio0.7273_AL_.jpg",
                    Description = "(2018) aka \"The Avengers 3\"",
                    MovieRatings = {
                       ImdbRating = "8.4",
                       RottenTomatoesRating = "85",
                    },
                    MovieTrailerResponseItems = {
                        new MovieTrailer() {
                            TrailerId = "6ZfuNTqbHE8",
                            Title = "Marvel Studios&#39; Avengers: Infinity War Official Trailer"
                        }
                    }

                },
                new Movie()
                {
                    Id = "tt4154757",
                    Title ="Test Movie",
                    Image = "https://imdb-api.com/images/original/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_Ratio0.7273_AL_.jpg",
                    Description = "(2018) aka \"The Avengers 3\"",
                    MovieRatings = {
                       ImdbRating = "8.4",
                       RottenTomatoesRating = "85",
                    },
                    MovieTrailerResponseItems = {
                        new MovieTrailer() {
                            TrailerId = "6ZfuNTqbHE8",
                            Title = "Marvel Studios&#39; Avengers: Infinity War Official Trailer"
                        }
                    }

                },
                new Movie()
                {
                    Id = "tt4154751",
                    Title ="Best movie ",
                    Image = "https://imdb-api.com/images/original/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_Ratio0.7273_AL_.jpg",
                    Description = "(2018) aka \"The Avengers 3\"",
                    MovieRatings = {
                       ImdbRating = "8.4",
                       RottenTomatoesRating = "85",
                    },
                    MovieTrailerResponseItems = {
                        new MovieTrailer() {
                            TrailerId = "6ZfuNTqbHE8",
                            Title = "Marvel Studios&#39; Avengers: Infinity War Official Trailer"
                        }
                    }

                },

            };

            return returnList;


            //return await _movieService.SearchAsync(search);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public async Task<Movie> SearchByIdAsync(string movieId)
        {
            //return _movieService.SearchByIdAsync(movieId);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut]
        public async Task SaveMovieAsync()
        {
            //return _movieService.SaveMovieAsync();
            throw new NotImplementedException();
        }
    }
}
