


using System.ComponentModel.DataAnnotations;

public class Producer : BaseEntity {
    [Key]
    public int Id { get; set; }
    [Required]

    public string Name { get; set; }
    [Required]
    public string ImgUrl { get; set; }
    [Required]
    public string Bio { get; set; }

    public ICollection<Movie> Movies = new List<Movie>();
}