



public class MovieVM {

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImgUrl { get; set; }
    public string WatchUrl { get; set; }

    public int Duration { get; set; }

    public MovieCategory Category { get; set; }


    public int ProducerId { get; set; }

    public Producer Producer { get; set; }

    public List<int> ActorIds {get; set;}

    public List<Actor> Actors {get; set;}

    public MovieVM()
    {
        
    }

    public MovieVM(Movie movie)
    {
        Id = movie.Id;
        Name = movie.Name;
        Description = movie.Description;
        Duration = movie.Duration;
        ImgUrl = movie.ImgUrl;
        Category = movie.Category;
        ProducerId = movie.ProducerId;
        Producer = movie.Producer;
        WatchUrl = movie.WatchUrl;
        Actors = new List<Actor>();
    }

    public Movie ToModel(){
        

        Movie m = new Movie(){
            Name = this.Name,
            Description = this.Description,
            Duration = this.Duration,
            ImgUrl = this.ImgUrl,
            Category = this.Category,
            ProducerId = this.ProducerId,
            WatchUrl = this.WatchUrl,
            Actors_Movies = new List<Actors_Movies>()
        };

        foreach (var item in ActorIds){
            Actors_Movies a = new Actors_Movies(){ActorId = item};
            m.Actors_Movies.Add(a);
        }

        return m;
    }
}