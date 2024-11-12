


public class ProducerVM {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string Bio { get; set; }

    public ICollection<Movie> Movies = new List<Movie>();

    public ProducerVM()
    {
        
    }

    public ProducerVM(Producer producer)
    {
        Id = producer.Id;
        Name = producer.Name;
        Bio = producer.Bio;
        ImgUrl = producer.ImgUrl;
        
    }
}