using Microsoft.VisualBasic;
using MoviesApi.Data;
using MoviesApi.Entities;
using MoviesApi.Services.Abstracts;

namespace MoviesApi.Services.Concretes
{
    public class BackgroundWorkerService : BackgroundService
    {
        private readonly IRandomMoviesService _randomMovieService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<BackgroundWorkerService> _logger;

        public BackgroundWorkerService(IRandomMoviesService randomMovieService, IServiceScopeFactory serviceScopeFactory, ILogger<BackgroundWorkerService> logger)
        {
            _randomMovieService = randomMovieService;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var randomMovie = await _randomMovieService.GetRandomMovieAsync();

                    if (randomMovie != null)
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var movieService = scope.ServiceProvider.GetRequiredService<IMovieService>();
                            var allMovie = await movieService.GetAllAsync();
                            var checkMovie = allMovie.FirstOrDefault(m => m.ImdbID == randomMovie.ImdbID);

                            if (checkMovie == null)
                            {
                                await movieService.AddAsync(randomMovie);
                                _logger.LogInformation("Movie added: {Title}", randomMovie.Title);
                            }
                            else
                            {
                                _logger.LogInformation("The Movie has in database: {Title}", randomMovie.Title);
                                //continue;
                            }
                        }
                    }
                    else
                    {
                        _logger.LogWarning("No movie found.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching or saving movie.");
                }
                finally
                {
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }
    }
}


