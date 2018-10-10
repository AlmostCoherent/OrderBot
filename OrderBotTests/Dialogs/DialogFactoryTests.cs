using FluentAssertions;
using Moq;
using OrderBot.Dialogs.Support;
using Xunit;


namespace OrderBot.Dialogs.Tests
{
    public class DialogFactoryTests
    {
        [Fact]
        public void CreateTest()
        {
            var mockService = new Mock<IDialogFactory>();
            mockService.Setup(m => m.Create("Support"));

            SupportDialog expectedSupportDialog = new SupportDialog();

            expectedSupportDialog.Should().BeEquivalentTo(mockService);
        }

    }
}