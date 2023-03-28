namespace BackendProject.Services.Email
{
    public interface IEmailSend
    {
        void Send(string userEmail, string subject, string body);
    }
}
