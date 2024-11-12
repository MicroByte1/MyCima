


public class ActorVM{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ImgUrl { get; set; }

    public List<Movie> movies {get; set;}

    public ActorVM()
    {
        
    }

    public ActorVM(Actor actor)
    {
        Id = actor.Id;
        Name = actor.Name;
        ImgUrl = actor.ImgUrl;
        Bio = actor.Bio;
    }
}