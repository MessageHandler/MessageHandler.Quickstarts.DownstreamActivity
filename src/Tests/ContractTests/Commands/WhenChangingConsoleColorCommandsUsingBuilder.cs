using MessageHandler.Quickstart.Contract;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MessageHandler.Quickstart.AggregateRoot.ContractTests
{
    public class WhenChangingConsoleColorCommandsUsingBuilder
    {
        [Fact]
        public async Task ShouldAdhereToContract()
        {
            var command = new ChangeConsoleColorCommandBuilder()
                                        .WellknownCommand("yellow")
                                        .Build();

            string currentOutput = JsonSerializer.Serialize(command);

            await File.WriteAllTextAsync(@"./.verification/yellow/actual.changeconsolecolor.command.cs.json", currentOutput);

            var previousOutput = await File.ReadAllTextAsync(@"./.verification/yellow/verified.changeconsolecolor.command.cs.json");

            Assert.Equal(previousOutput, currentOutput);
        }
    }
}