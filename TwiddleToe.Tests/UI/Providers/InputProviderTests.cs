// <copyright file="InputProviderTests.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.UI.Providers
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestBase;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;

    /// <summary>
    /// Test fiddles for the generic input.
    /// </summary>
    [TestClass]
    public class InputProviderTests : TestBase<TestScope>
    {
        /// <summary>
        /// Tests the text input.
        /// </summary>
        [TestMethod]
        public void TestTextInput()
        {
            using (var scope = this.StartTest())
            {
                var provider = scope.InputProvider;

                var inputs = new List<IGenericInput>
                {
                    new TextInputModel { Label = "Onderwerp" }
                };

                var r = provider.Get("Proef", inputs);

                // Assert.Fail("This test should not be active, only when fiddling.");
            }
        }
    }
}
