using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Engine.ViewModels;
using NuGet.Frameworks;

namespace TestEngine.ViewModels
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void MyTestMethod()
        {
            GameSession gameSession = new GameSession();
            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Town square", gameSession.CurrentLocation.Name);
        }
    }
}