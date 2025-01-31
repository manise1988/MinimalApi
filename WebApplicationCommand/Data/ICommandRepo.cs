using WebApplicationCommand.Models;

namespace WebApplicationCommand.Data
{
    public interface ICommandRepo
    {

        public Task SaveChanges();
        public Task<IEnumerable<Command>> GetAllCommands();

        public Task<Command?> GetCommandById(int  id);

        public Task CreateCommand(Command command);

        public void DeleteCommand(Command command);
    }
}
