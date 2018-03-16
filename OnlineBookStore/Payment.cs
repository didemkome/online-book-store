using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            label7.Text = " " + Home.shopCart.PaymentAmount;
            foreach (var item in Home.shopCart.ItemsToPurchase)
            {
                PaymentPanel panel = new PaymentPanel();
                panel.create(item);
                flowLayoutPanel1.Controls.Add(panel);
            }
            grpCreditCard.Visible = false;
        }

     

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpCreditCard.Visible = cmbPayment.SelectedIndex == 0;
            switch (cmbPayment.SelectedIndex)
            {
                case 0:
                    Home.shopCart.PaymentType = "Cash";
                    grpCreditCard.Visible = false;
                    break;
                case 1:
                    Home.shopCart.PaymentType = "Credit Card";
                    grpCreditCard.Visible = true;
                    break;
            }
        }

        private void txtCardName_TextChanged(object sender, EventArgs e)
        {
            txtCardName.Text = "";
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            txtCardNumber.Text = "";
        }

        private void txtCCV_TextChanged(object sender, EventArgs e)
        {
            txtCCV.Text = "";
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text == "")
            {
                MessageBox.Show("You cannot complete your shopping without adress!");
            }
            else if (rdbBuKoli.Checked == false && rdbYurtici.Checked == false && rdbUps.Checked == false)
                MessageBox.Show("You must select cargo company.");
            else if (cmbPayment.SelectedIndex == -1)
            {
                MessageBox.Show("You should select payment type");
            }
            else if (cmbPayment.SelectedIndex == 1)
            {
                if (txtCardName.Text == null || txtCardNumber.Text == null || txtCCV.Text == null || cmbCardMonth.SelectedIndex == -1 || cmbCardYear.SelectedIndex == -1)
                {
                    MessageBox.Show("Please, be sure credit card infos write correctly");
                }
            }
            else
            {
                MessageBox.Show("Payment is completed. Thank you for choosing us.");
                Profile profile = new Profile();
                Home.shopCart.ItemsToPurchase.Clear();
                flowLayoutPanel1.Controls.Clear();
                profile.ShowDialog();
                this.Hide();
            }
            string buttonname = "Buy";
            SaveLog.Savelog(buttonname);
        }
    }
}
