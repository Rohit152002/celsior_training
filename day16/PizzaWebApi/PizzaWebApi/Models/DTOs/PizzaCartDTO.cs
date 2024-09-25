namespace PizzaWebApi.Models.DTOs
{
    public class PizzaCartDTO : IEquatable<PizzaCartDTO>
    {
        public int SiNo { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

        public bool Equals(PizzaCartDTO? other)
        {
            return (this ?? new PizzaCartDTO()).SiNo == (other ?? new PizzaCartDTO()).SiNo;
        }
    }
}
