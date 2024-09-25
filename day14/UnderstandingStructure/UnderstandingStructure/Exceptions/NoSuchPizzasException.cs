namespace UnderstandingStructure.Exceptions
{
    public class NoSuchPizzasException:Exception
    {
        string msg;
        public NoSuchPizzasException()
        {
            msg = "Pizza withthe given details not found in the repository";
        }
        public override string Message => msg;

    }
}
