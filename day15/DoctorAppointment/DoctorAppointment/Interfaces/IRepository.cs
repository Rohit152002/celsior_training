namespace DoctorAppointment.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        T Get(K key);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(K key);
    }
}
