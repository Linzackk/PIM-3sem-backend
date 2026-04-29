namespace PIM_3sem_backend.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message) { }
    }
}
