using MessageHandler.Quickstart.Contract;
using MessageHandler.Runtime.AtomicProcessing;

namespace Worker
{
    public class ConsoleColorHandler : IHandle<ChangeConsoleColor>
    {
        private readonly ILogger<ConsoleColorHandler> logger;
        private readonly IConsole console;

        public ConsoleColorHandler(IConsole console = null!, ILogger<ConsoleColorHandler> logger = null!)
        {
            this.logger = logger;
            this.console = console ?? new ConsoleWrapper();
        }

        public async Task Handle(ChangeConsoleColor message, IHandlerContext context)
        {
            logger?.LogInformation("Received ChangeConsoleColor command, changing the color...");

            console.ForegroundColor = Enum.Parse<ConsoleColor>(message.Color);

            await Console.Out.WriteLineAsync("Testing the console color");

            logger?.LogInformation("Console color set");
        }
    }

    public interface IConsole
    {
        ConsoleColor ForegroundColor { get; set; }
    }

    public class ConsoleWrapper : IConsole
    {
        public ConsoleColor ForegroundColor { get => Console.ForegroundColor; set => Console.ForegroundColor = value; }
    }


}
