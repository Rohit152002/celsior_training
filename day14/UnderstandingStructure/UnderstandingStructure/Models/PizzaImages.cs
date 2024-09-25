namespace UnderstandingStructure.Models
{
    public class PizzaImages : IEquatable<PizzaImages>
    {
        public int Id;
        public List<string> Images;

        public bool Equals(PizzaImages? other)
        {
            return this.Id == other.Id;
        }
    }
}
