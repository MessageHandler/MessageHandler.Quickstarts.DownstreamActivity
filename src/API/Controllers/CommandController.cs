using MessageHandler.Quickstart.Contract;
using MessageHandler.Runtime.AtomicProcessing;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("control")]
    public class CommandController : ControllerBase
    {
        private IDispatchMessages dispatcher;

        public CommandController(IDispatchMessages dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpPost()]
        [Route("changeconsolecolor")]
        //[Authorize]
        public async Task<IActionResult> ChangeColor([FromBody] ChangeConsoleColor cmd)
        {
            await dispatcher.Dispatch(cmd);

            return Ok();
        }

    }
}