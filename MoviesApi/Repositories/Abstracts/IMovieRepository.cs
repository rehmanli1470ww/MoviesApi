using MoviesApi.Entities;

namespace MoviesApi.Repositories.Abstracts
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task AddAsync(Movie movie);
        Task DeleteAsync(int id);
        Task UpdateAsync(Movie movie);
    }
}
