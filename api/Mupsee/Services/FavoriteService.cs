using Mupsee.Interfaces;
using Mupsee.Models;
using Repository.Context;
using Repository.Entities;

namespace Mupsee.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly MupseeContext _context;
        public FavoriteService(MupseeContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task SaveMovieAsFavoriteAsync(FavoriteMovieViewModel favoriteMovieViewModel)
        {
            if (favoriteMovieViewModel is null)
                throw new ArgumentNullException($"Parameter {favoriteMovieViewModel} cannot be null");

            try
            {
                var isMovieAlreadyExist = _context.Favorites.FirstOrDefault(x => x.MovieId == favoriteMovieViewModel.Id);

                /// Check if the current movie already exists in database if does just update it
                if (isMovieAlreadyExist is not null)
                {
                    isMovieAlreadyExist.IsFavorite = favoriteMovieViewModel.IsFavorite;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var data = new Favorite()
                    {
                        MovieId = favoriteMovieViewModel.Id,
                        IsFavorite = favoriteMovieViewModel.IsFavorite,
                        Image = favoriteMovieViewModel.Image
                    };

                    await _context.Favorites.AddAsync(data);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public bool CheckIsFavorite(string movieId)
        {
            if (string.IsNullOrWhiteSpace(movieId))
                throw new ArgumentNullException($"Parameter {movieId} cannot be null");

            try
            {
                var favoriteVm = _context.Favorites.FirstOrDefault(x => x.MovieId == movieId);

                if (favoriteVm is null)
                    return false;

                return favoriteVm.IsFavorite;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public List<MovieViewModel> GetFavoriteMovies()
        {
            try
            {
                var favoritesVm = _context.Favorites.Where(x => x.IsFavorite == true);
                var moviesVm = new List<MovieViewModel>();

                foreach (var favorite in favoritesVm)
                {
                    moviesVm.Add(new MovieViewModel
                    {
                        Id = favorite.MovieId,
                        Image = favorite.Image,
                    });
                }

                return moviesVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
