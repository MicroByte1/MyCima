


public class ProducerService : Repository<Producer>, IProducerService
{
    public ProducerService(AppContext context) : base(context)
    {
    }


    public void Update(int id, Producer element){
        var old = GetById(id);
        old.Name = element.Name;
        old.Bio = element.Bio;
        old.ImgUrl = element.ImgUrl;
        Save();
    }
}