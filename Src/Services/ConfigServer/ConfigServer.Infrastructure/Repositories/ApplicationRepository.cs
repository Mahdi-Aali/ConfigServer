using ConfigServer.Domain.AggregateModels.ApplicationAggregate;
using ConfigServer.Domain.CommonExceptions;
using ConfigServer.Domain.SeedWorker;
using Microsoft.EntityFrameworkCore;

namespace ConfigServer.Infrastructure.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicationRepository(ApplicationDbContext context) => _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<bool> AddAsync(Application application, CancellationToken cancellationToken = default)
    {
        if (!await IsApplicationNameExist(application.ApplicationName))
        {
            await _context.Applications.AddAsync(application, cancellationToken);
            return true;
        }
        throw new ItemAlreadyExistException($"application with name {application.ApplicationName.ToLower()} alrady exist.");
    }

    public async Task<bool> IsApplicationNameExist(string name, CancellationToken cancellationToken = default) =>
        await _context.Applications.FirstOrDefaultAsync(a => a.ApplicationName.Equals(name.ToLower()), cancellationToken) != null;
}
