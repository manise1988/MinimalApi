
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCommand.Data;
using WebApplicationCommand.Dtos;
using WebApplicationCommand.Models;

namespace WebApplicationCommand.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo commandRepo, IMapper mapper) {
        
            _commandRepo = commandRepo;
            _mapper = mapper;
        
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetCommands()
        {
            var commands = await _commandRepo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));

        }
        [HttpGet("{id}",Name ="GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            var command = await _commandRepo.GetCommandById(id);
            if (command == null)
                return NotFound();
            return Ok(_mapper.Map<CommandReadDto>(command));
        }
        
        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map <Command>(commandCreateDto);

            await _commandRepo.CreateCommand(command);
            await _commandRepo.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(command);
            return Ok(commandReadDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var command = await _commandRepo.GetCommandById(id);
            if (command == null)
                return NotFound();
            _commandRepo.DeleteCommand(command);
            await _commandRepo.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommandReadDto>> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = await _commandRepo.GetCommandById(id);
            if(command == null) return NotFound();

            _mapper.Map(commandUpdateDto , command);

            await _commandRepo.SaveChanges();
            return NoContent();
        }

    }
}
