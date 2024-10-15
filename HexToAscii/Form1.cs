using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexToAscii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string inputTxt = txtBInput.Text;
            string asciiOutput = HexToAscii(inputTxt);
            lblDisplay.Text = "ASCII: " + asciiOutput;
        }
        private string HexToAscii(string hex)
        {
            // Remove spaces if any
            hex = hex.Replace(" ", "");

            // Make sure the input length is even
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Invalid Hex string");

            StringBuilder ascii = new StringBuilder();

            for (int i = 0; i < hex.Length; i += 2)
            {
                // Convert each hex pair to a byte
                string hexPair = hex.Substring(i, 2);
                byte byteValue = Convert.ToByte(hexPair, 16);

                // Convert byte to ASCII character and append to the string
                ascii.Append((char)byteValue);
            }

            return ascii.ToString();
        }
    }
}
