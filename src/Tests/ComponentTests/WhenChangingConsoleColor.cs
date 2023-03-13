using MessageHandler.Quickstart.Contract;
using Moq;
using System;
using System.Threading.Tasks;
using Worker;
using Xunit;

namespace ComponentTests
{
    public class WhenChangingConsoleColor
    {
        [Fact]
        public async Task GivenYellowCommand_WhenHandlingCommand_ShouldSetForegroundColor()
        {
            var consoleMock = new Mock<IConsole>();
            consoleMock.SetupSet(c => c.ForegroundColor = It.IsAny<ConsoleColor>()).Verifiable();

            // given
            var command = new ChangeConsoleColorCommandBuilder()
                                       .WellknownCommand("yellow")
                                       .Build();
            //when
            var handler = new ConsoleColorHandler(consoleMock.Object);
            await handler.Handle(command, null!);

            // Then
            consoleMock.VerifySet(c => c.ForegroundColor=ConsoleColor.Yellow);
        }
    }
}