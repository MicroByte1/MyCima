

public interface IMovieService : IRepository<Movie>{

    void AddMovie(Movie movie);

    Task<List<Movie>> GetAllMoviesByActorId(int actorId);

}