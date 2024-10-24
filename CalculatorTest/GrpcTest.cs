using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcCalculatorServiceLocal;
using Grpc.Core.Testing;

namespace CalculatorTest
{
    [TestClass]
    public class GrpcTest
    {
        const string URL = "https://localhost:7271/";
        GrpcChannel? channel = null;
        GrpcCalculatorServiceLocal.Calculator.CalculatorClient? client;

        [TestInitialize]
        public void Init()
        {
            GrpcChannel channel = GrpcChannel.ForAddress(URL);
            client = new GrpcCalculatorServiceLocal.Calculator.CalculatorClient(channel);
        }
        [TestCleanup]
        public void Cleanup()
        {
            Debug.Assert(channel != null);
            channel.Dispose();
        }

        [TestMethod]
        public void Add()
        {
            Debug.Assert(client != null);
            var request = new Nums { N1 = 1, N2 = 2 };
            var response = client.Add(request);
            Assert.AreEqual(3, response.Result);
        }
        [TestMethod]
        public void Subtract()
        {
            Debug.Assert(client != null);
            var request = new Nums { N1 = 1, N2 = 2 };
            var result = client.Subtract(request);
            Assert.AreEqual(-1, result.Result);
        }
        [TestMethod]
        public void Multiply()
        {
            Debug.Assert(client != null);
            var request = new Nums { N1 = 1, N2 = 2 };
            var result = client.Subtract(request);
            Assert.AreEqual(2, result.Result);
        }
        [TestMethod]
        public void Divide()
        {
            Debug.Assert(client != null);
            var request = new Nums { N1 = 5, N2 = 2 };
            var result = client.Subtract(request);
            Assert.AreEqual(2.5, result.Result);
        }
        [TestMethod]
        public void Mod()
        {
            Debug.Assert(client != null);
            var request = new Nums { N1 = 5, N2 = 2 };
            var result = client.Subtract(request);
            Assert.AreEqual(1, result.Result);
        }
    }
}
