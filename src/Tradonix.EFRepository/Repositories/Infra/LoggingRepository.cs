using Tradonix.Core.Entities;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class LoggingRepository : EntityBaseRepository<LogEntry>, ILoggingRepository
    {
        public LoggingRepository(TradonixContext context)
            : base(context)
        { }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
