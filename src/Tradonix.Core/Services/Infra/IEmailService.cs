using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tradonix.Services.Infra
{
    public interface IEmailService
    {
        Task SendEmailAsync(string body, string subjectLine, string toAddress);
        Task SendEmailAsync(string body, string subjectLine, List<string> toAddresses);
    }
}
