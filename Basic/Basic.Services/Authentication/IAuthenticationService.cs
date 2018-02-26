namespace Basic.Services.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(string userName);

        void SignOut();
    }
}
