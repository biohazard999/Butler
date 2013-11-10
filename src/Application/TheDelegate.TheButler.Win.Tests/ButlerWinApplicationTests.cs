using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevExpress.ExpressApp.Win;
namespace TheDelegate.TheButler.Win.Tests
{
    [TestClass]
    public class ButlerWinApplicationTests
    {
        [TestMethod]
        public void Ctor_WithNoArguments_DoesntThrow()
        {
            ButlerWinApplication sut = new ButlerWinApplication();

            sut.Should().BeAssignableTo<WinApplication>();
        }
    }
}