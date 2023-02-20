namespace ICustomerRepository
{
    /// <summary>
    /// Basic CRU Operation
    /// </summary>
    public interface ICruRepository<T, Id>
    {
        IEnumerable<T> GetAll();
        T GetById(Id id);
        void Add(T entity);
        void Update(T entity);

        IEnumerable<T> GetGetCustomerTopGenre(Id id);
    }
}
