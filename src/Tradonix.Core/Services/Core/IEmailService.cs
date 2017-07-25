using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tradonix.Core.Helper
{
    public interface IEmailService
    {
        Task SendEmailAsync(string body, string subjectLine, string toAddress);
        Task SendEmailAsync(string body, string subjectLine, List<string> toAddresses);
    }
}
