using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        Double AppleCost = 0.45;
        Double OrangeCost = 0.65;
        Double AppleCount = 0.0;
        Double OrangeCount = 0.0;
        Double cartTotal = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void appleBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (appleBox.Text != string.Empty)
                {
                    AppleCount = Convert.ToDouble(appleBox.Text);
                }
                else
                {
                    AppleCount = 0;
                }
                cartTotalCalc(AppleCount, OrangeCount);
                totalCostBox.Text = cartTotal.ToString();
            }
            catch (Exception ex)
            {
                //write to log and system trace
            }
        }

        private void orangesBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (orangesBox.Text != string.Empty)
                {
                    OrangeCount = Convert.ToDouble(orangesBox.Text);
                }
                else
                {
                    OrangeCount = 0;
                }
                cartTotalCalc(AppleCount, OrangeCount);
                totalCostBox.Text = cartTotal.ToString();
            }
            catch (Exception ex)
            {
                //write to log and system trace
            }
        }

        private void cartTotalCalc(Double apples, Double oranges)
        {
            cartTotal = 0;
            if (AppleCount != 0.0)
            {                
                cartTotal = AppleCost * AppleCount;
            }
            if (OrangeCount != 0.0)
            {               
                cartTotal = cartTotal + OrangeCost * OrangeCount;
            }
        }

       
    }
}
