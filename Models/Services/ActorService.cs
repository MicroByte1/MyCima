



using Microsoft.EntityFrameworkCore;

public class ActorService : Repository<Actor> , IActorService{
    private AppContext _context;
    public ActorService(AppContext context): base(context)
    {
        _context = context;
    }

    public async Task<List<Actor>> GetAllActorsByMoviId(int moviId)
    {
        List<Actor> actors = new List<Actor>();
        var res = await _context.actors_Movies.Where(x => x.MovieId == moviId).ToListAsync();
        foreach (var item in res){
            var actor = GetById(item.ActorId);
            actors.Add(actor);
        }
        return actors;
    }

    public void Update(int id, Actor element){
        var old = GetById(id);
        old.Name = element.Name;
        old.Bio = element.Bio;
        old.ImgUrl = element.ImgUrl;
        Save();
    }

}