using MoviesApi.Entities;

namespace MoviesApi.Services.Abstracts
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task AddAsync(Movie movie);
        Task DeleteAsync(int id);
        Task UpdateAsync(Movie movie);
    }
}
