


using System.ComponentModel.DataAnnotations.Schema;

public class Movie : BaseEntity {
    public int Id { get; set; }

    public string Name { get; set; }

    
    public string Description { get; set; }

    
    public string ImgUrl { get; set; }

    public string WatchUrl { get; set; }

    public int Duration { get; set; }

    public MovieCategory Category { get; set; }

    // relationships
    [ForeignKey("ProducerId")]
    public int ProducerId { get; set; }

    public Producer Producer { get; set; }

    public List<Actors_Movies> Actors_Movies { get; set; }
}
