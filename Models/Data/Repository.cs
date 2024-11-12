


public class Repository<T> : IRepository<T> where T : class, BaseEntity, new() {

    private AppContext _context;
    public Repository(AppContext context)
    {
        _context = context;
    }

    public void Save(){
        _context.SaveChanges();
    }

    public T GetById(int id){
        return _context.Set<T>().First(e => e.Id == id);
    }

    public IEnumerable<T> GetAll(){
        return _context.Set<T>().ToList();
    }

    public void Add(T element){
        _context.Set<T>().Add(element);
        Save();
    }

    public void Delete(T element){
        _context.Set<T>().Remove(element);
        Save();
    }

    
}