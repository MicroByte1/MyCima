


using Microsoft.EntityFrameworkCore;

public class MovieService : Repository<Movie> , IMovieService {

    AppContext _context;
    public MovieService(AppContext context) : base(context)
    {
        _context = context;
    }

    public void AddMovie(Movie movie)
    {
        Add(movie);
        
    }

    public async Task<List<Movie>> GetAllMoviesByActorId(int actorId)
    {
        List<Movie> actors = new List<Movie>();
        var res = await _context.actors_Movies.Where(x => x.ActorId == actorId).ToListAsync();
        foreach (var item in res){
            var movie = GetById(item.MovieId);
            actors.Add(movie);
        }
        return actors;
    }
}