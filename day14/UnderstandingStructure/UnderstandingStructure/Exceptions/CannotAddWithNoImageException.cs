namespace UnderstandingStructure.Exceptions
{
    public class CannotAddWithNoImageException:Exception
    {
        string message;
        public CannotAddWithNoImageException()  {
            message = "Cannot add image";
        }

        public override string Message => message;
    }
}
