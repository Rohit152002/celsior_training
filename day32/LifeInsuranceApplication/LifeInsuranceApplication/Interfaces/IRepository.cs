namespace LifeInsuranceApplication.Interface
{
    public interface IRepository<K,T> where T:class
    {
        public Task<K> Create(T entity);
        public Task<T> Get(K key);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(K key,T entity);
        public Task<T> Delete(K key);
    }
}
