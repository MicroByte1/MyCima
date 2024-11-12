

public interface IProducerService : IRepository<Producer> {
    void Update(int id, Producer element);
}