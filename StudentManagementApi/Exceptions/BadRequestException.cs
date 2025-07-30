//////////this is custom Exception////////////
///is a user defiend class inhertis from Exception  ///
////Exception is the base class for all exceptions in .NET ////
///you use it when you want to define your own business logic errors////
namespace StudentManagementApi.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
