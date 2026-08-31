using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Autotests.TestAQA1.Interfaces;
using Autotests.TestAQA1.Interfaces.Email;
using Autotests.TestAQA1.Services;

namespace Autotests.TestAQA1.Tests
{
    public class FakeEmailSender : IEmailSender
    {
        public string? Recipient { get; private set; }
        public string? Message { get; private set; }
        public void Send(string to, string text)
        {
            Recipient = to;
            Message = text;
        }
        public class TestEmail 
        {
            [Test]
            public void  UserNotifierShouldSendEmail()
            {
                var fakeSender = new FakeEmailSender();
                var notifier = new UserNotifier(fakeSender);
                notifier.Notify(5);

                fakeSender.Recipient.Should().Be("user@mail.com");
                fakeSender.Message.Should().Be("Hello, user 5!");

            }
        }
    }
}