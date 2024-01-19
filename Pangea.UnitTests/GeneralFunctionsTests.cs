using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pangea.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.UnitTests
{
    [TestClass]
    public class GeneralFunctionsTests
    {


        #region Functions Test

        [TestMethod]
        public async Task GetPangeaRates_CountryCode_IsValid()
        {
            var mockPathProvider = new Mock<IPathProvider>();
            mockPathProvider.Setup(p => p.GetBaseDirectory()).Returns("YourTestBaseDirectory");

            var result = GeneralFunction.GetPangeaRates("MEX", mockPathProvider.Object);
            Assert.IsNotNull(result);
           // Assert.IsNull(GeneralFunction.GetPangeaRates("ABC"));
        }
        #endregion
    }
}
