using Grpc.Net.Client;
using GrpcCalculatorServiceLocal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InsertNumber(object sender, EventArgs e)
        {
            if (OP.Text == " ")
            {
                P1.Text = ((Button)sender).Text;
            }
            else
            {
                P2.Text = ((Button)sender).Text;
            }
        }

        private void InsertOP(object sender, EventArgs e)
        {
            OP.Text = ((Button)sender).Text;
        }

        private void Clear(object sender, EventArgs e)
        {
            P1.Text = " ";
            P2.Text = " ";
            OP.Text = " ";
            ANS.Text = " ";
        }

        private void EnterButton(object sender, EventArgs e)
        {
            double p1 = Double.Parse(P1.Text);
            double p2 = Double.Parse(P2.Text);

            var httpHandler = new SocketsHttpHandler();
            var channel = GrpcChannel.ForAddress("https://localhost:7271/");
            var calculatorClient = new GrpcCalculatorServiceLocal.Calculator.CalculatorClient(channel);
            var clientRequested = new Nums { N1 = p1, N2 = p2 };
            calculatorClient.Add(clientRequested);
            var result = calculatorClient.Add(clientRequested);

            ANS.Text = ("1 + 2 = " + result.Result.ToString());

        }
    }
}
