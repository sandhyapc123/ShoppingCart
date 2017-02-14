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
        //Global variables
        //apple cost
        Double AppleCost = 0.45;
        //orange cost
        Double OrangeCost = 0.65;
        Double AppleCount = 0.0;
        Double OrangeCount = 0.0;
        Double cartTotal = 0.0;
        //Special offers maintaining variables. 
        bool appleSpecialOffers = true;
        bool orangeSpecialOffers = true;
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
                    AppleCount = Math.Truncate(Convert.ToDouble(appleBox.Text));
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
                    OrangeCount = Math.Truncate(Convert.ToDouble(orangesBox.Text));
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
        
        //caluculating the total cost
        private void cartTotalCalc(Double apples, Double oranges)
        {
            cartTotal = 0;
            if (AppleCount != 0.0)
            {
                if (appleSpecialOffers)
                {
                    applespecialOfferCalc();
                }
                cartTotal = AppleCost * AppleCount;
            }
            if (OrangeCount != 0.0)
            {
                if (orangeSpecialOffers)
                {
                    orangeSpecialOfferCalc();
                }
                cartTotal = cartTotal + OrangeCost * OrangeCount;
            }
        }


        //checking for special offers on apple
        private void applespecialOfferCalc()
        {
            if (AppleCount % 2 == 0)
            {
                AppleCount = AppleCount / 2;
            }
            else
            {
                AppleCount = AppleCount / 2 + 0.5;
            }

        }

        //checking for special offers on oranges
        private void orangeSpecialOfferCalc()
        {
            if (OrangeCount % 3 == 0)
            {
                OrangeCount = (OrangeCount / 3) * 2;

            }
            else
            {
                double roundednumber = Math.Truncate(OrangeCount / 3);
                OrangeCount = roundednumber * 2 + (OrangeCount - roundednumber * 3);
            }

        }

        //Check out and display the final amount and savings
        private void button1_Click(object sender, EventArgs e)
        {
            Double AppCount = Math.Truncate(Convert.ToDouble(appleBox.Text));
            Double orgCount = Math.Truncate(Convert.ToDouble(orangesBox.Text));
            Double savings = (AppCount * AppleCost + orgCount * OrangeCost) - cartTotal;
            MessageBox.Show("Your total : $ "+cartTotal+"\n"+"Your savings for today : $ "+ savings);
        }
    }
}
