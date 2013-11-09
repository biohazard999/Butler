using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TheDelegate.TheButler.Win.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_CanBeLoaded_FromTestLocation()
        {
            Action action = () =>
            {
                var type = typeof (Program);
                
            };

            action.ShouldNotThrow();
        }
    }
}