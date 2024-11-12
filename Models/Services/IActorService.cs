

public interface IActorService : IRepository<Actor> {
    void Update(int id, Actor element);

    Task<List<Actor>> GetAllActorsByMoviId(int moviId);
}