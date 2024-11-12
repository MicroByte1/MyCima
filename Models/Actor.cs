

using System.ComponentModel.DataAnnotations;

public class Actor : BaseEntity {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Bio { get; set; }
    [Required]
    public string ImgUrl { get; set; }

    public List<Actors_Movies> Actors_Movies = new List<Actors_Movies>();
}