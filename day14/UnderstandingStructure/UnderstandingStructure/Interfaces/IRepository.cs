using UnderstandingStructure.Models;

namespace UnderstandingStructure.Interfaces
{
    public interface IRepository<K,T> where T:class
    {
        void Add(T Item);
        T Get(K id);
        List<T> GetAll();
        T Update(T Item);
        T Delete(K key);
    }
}
