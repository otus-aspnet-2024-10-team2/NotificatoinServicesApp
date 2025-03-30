using Core.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Services.Repositories;

namespace Infrastructure.Repositories.Implementations;

public class UserRepository : Repository<User, int>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }

    public override Task<User> GetAsync(int id, CancellationToken token = default)
    {
        var u = Context.Set<User>().AsQueryable();
        return u.SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public Task<int> GetRandomUserId()
    {
        return Task.FromResult(new Random().Next(1, 200));
    }
}