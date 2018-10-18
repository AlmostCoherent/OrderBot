using FluentAssertions;
using Microsoft.Bot.Builder.Dialogs;
using Moq;
using OrderBot.Dialogs.Support;
using System;
using System.Threading.Tasks;
using Xunit;


namespace OrderBot.Dialogs.Tests
{
    public interface IChatHelper
    {
        Task PostAsync(IDialogContext context, string message);
    }
    [Serializable]
    public class ChatHelper : IChatHelper
    {
        public async Task PostAsync(IDialogContext context, string message)
        {
            await context.PostAsync(message);
        }
    }

    public class DialogFactoryTests
    {
        private Mock<IChatHelper> _chat;
        private RootDialog _dialog;
        private Mock<IDialogContext> _context;

                public void SetUp()
        {
            _chat = new Mock<IChatHelper>();
            _dialog = new RootDialog();
            _context = new Mock<IDialogContext>();
        }

        [Fact]
        public async void CreateTest()
        {
            var mockService = new Mock<IDialogFactory>();
            mockService.Setup(m => m.Create("Support"));

            SupportDialog expectedSupportDialog = new SupportDialog();

            expectedSupportDialog.Should().BeEquivalentTo(mockService);
        }

    }
}