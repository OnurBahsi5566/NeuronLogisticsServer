
namespace NeuronLogisticsServer.Application.Exceptions
{
    //opsiyonel olarak hepsini kullanabilirsin bu bir örnek 
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Error! User did not create")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
