

public interface IRepository<T> where T : class, BaseEntity, new() {

    void Save();
    T GetById(int id);

    IEnumerable<T> GetAll();

    void Add(T element);

    void Delete(T element);
    
}