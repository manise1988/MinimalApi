using Microsoft.EntityFrameworkCore;
using WebApplicationCommand.Models;

namespace WebApplicationCommand.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CommandRepo(ApplicationDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public async Task CreateCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            await _dbContext.AddAsync(command);
        }

        public  void DeleteCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _dbContext.Commands.Remove(command);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _dbContext.Commands!.ToListAsync();
        }

        public async Task<Command?> GetCommandById(int id)
        {
          return  await _dbContext.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
          await _dbContext.SaveChangesAsync();
        }

    }
}
