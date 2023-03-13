namespace MessageHandler.Quickstart.Contract
{
    public class ChangeConsoleColorCommandBuilder
    {
        private ChangeConsoleColor _command;

        public ChangeConsoleColorCommandBuilder()
        {
            _command = new ChangeConsoleColor
            {
               
            };
        }

        public ChangeConsoleColorCommandBuilder WellknownCommand(string commandId)
        {
            if (_wellknownCommands.ContainsKey(commandId))
            {
                _command = _wellknownCommands[commandId]();
            }

            return this;
        }

        public ChangeConsoleColor Build()
        {
            return _command;
        }

        private readonly Dictionary<string, Func<ChangeConsoleColor>> _wellknownCommands = new()
        {
            {
                "yellow",
                () =>
                {
                    return new ChangeConsoleColor()
                    {
                        Color = "Yellow"
                    };
                }
            },
            {
                "red",
                () =>
                {
                    return new ChangeConsoleColor()
                    {
                        Color = "Red"
                    };
                }
            }
        };
    }
}