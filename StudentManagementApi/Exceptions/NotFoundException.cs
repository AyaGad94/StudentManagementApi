//////////this is custom Exception////////////
///is a user defiend class inhertis from Exception  ///
////Exception is the base class for all exceptions in .NET ////
///you use it when you want to define your own business logic errors////
namespace StudentManagementApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
