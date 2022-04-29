namespace Examen2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (monto.Text != "" && comboBox1.Text != "")
            {
                Form2 form = new Form2();
                form.checkedListBox1.Items.Remove(comboBox1.Text);
                int pixeles = 25;
                groupBox1.Controls.Clear();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i <= (form.checkedListBox1.Items.Count - 1); i++)
                    {
                        if (form.checkedListBox1.GetItemChecked(i))
                        {
                            Label lblMoneda = new Label();
                            TextBox txtConversion = new TextBox();
                            txtConversion.Text = calcularConversion(comboBox1.Text, form.checkedListBox1.Items[i].ToString(), double.Parse(monto.Text)).ToString();
                            if (txtConversion.Text.Contains("."))
                            {
                                txtConversion.Text = txtConversion.Text.Remove(txtConversion.Text.IndexOf(".") + 3);
                            }
                            else
                            {
                                txtConversion.Text = txtConversion.Text + ".00";
                            }
                            
                            txtConversion.Enabled = false;
                            txtConversion.Location = new Point(185, pixeles);
                            lblMoneda.Text = form.checkedListBox1.Items[i].ToString();
                            lblMoneda.AutoSize = true;
                            lblMoneda.Location = new Point(7, pixeles);
                            pixeles += 30;
                            groupBox1.Controls.Add(txtConversion);
                            groupBox1.Controls.Add(lblMoneda);
                        }
                    }
                }

            }
            
        }

        private string calcularConversion(string monedaInicial,string conversion, double cantidad)
        {
            switch (monedaInicial)
            {
                case "MXN - Peso mexicano":
                    return conversionMXN(conversion, cantidad);
                    break;
                case "USD - Dólar estadounidense":
                    return conversionUSD(conversion, cantidad);
                    break;
                case "CAD - Dólar canadiense":
                    return conversionCAD(conversion, cantidad);
                    break;
                case "EUR - Euro":
                    return conversionEUR(conversion, cantidad);
                    break;
                case "JPY - Yen japonés":
                    return conversionJPY(conversion, cantidad);
                    break;
            }

            return "";
        }

        private string conversionMXN(string conversion,double cantidad)
        {
            if (conversion == "USD - Dólar estadounidense")
            {
                return "$ " + cantidad * 0.05 + "00";
            }
            if (conversion == "CAD - Dólar canadiense")
            {
                return "$ " + cantidad * 0.06 + "00";
            }
            if (conversion == "EUR - Euro")
            {
                return "€ " + cantidad * 0.04 + "00";
            }
            if (conversion == "JPY - Yen japonés")
            {
                return "¥ " + cantidad * 5.32 + "00";
            }

            return "$ " + 0.0;
        }

        private string conversionUSD(string conversion, double cantidad)
        {
            if (conversion == "MXN - Peso mexicano")
            {
                return "$ " + cantidad * 21.23 + "00";
            }
            if (conversion == "CAD - Dólar canadiense")
            {
                return "$ " + cantidad * 1.28 + "00";
            }
            if (conversion == "EUR - Euro")
            {
                return "€ " + cantidad * 0.89 + "00";
            }
            if (conversion == "JPY - Yen japonés")
            {
                return "¥ " + cantidad * 113.05 + "00";
            }

            return "$" + 0.0;
        }

        private string conversionCAD(string conversion, double cantidad)
        {
            if (conversion == "MXN - Peso mexicano")
            {
                return "$ " + cantidad * 16.55 + "00";
            }
            if (conversion == "USD - Dólar estadounidense")
            {
                return "$ " + cantidad * 0.78 + "00";
            }
            if (conversion == "EUR - Euro")
            {
                return "€ " + cantidad * 0.69 + "00";
            }
            if (conversion == "JPY - Yen japonés")
            { 
                return "¥ " + cantidad * 88.12 + "00";
            }

            return "$" + 0.0;
        }

        private string conversionEUR(string conversion, double cantidad)
        {
            if (conversion == "MXN - Peso mexicano")
            {
                return "$ " + cantidad * 23.96 + "00";
            }
            if (conversion == "USD - Dólar estadounidense")
            {
                return "$ " + cantidad * 1.13 + "00";
            }
            if (conversion == "CAD - Dólar canadiense")
            {
                return "$ " + cantidad * 1.45 + "00";
            }
            if (conversion == "JPY - Yen japonés")
            {
                return "¥ " + cantidad * 127.56 + "00";
            }

            return "$" + 0.0;
        }

        private string conversionJPY(string conversion, double cantidad)
        {
            if (conversion == "MXN - Peso mexicano")
            {
                return "$ " + cantidad * 0.1878 + "00";
            }
            if (conversion == "USD - Dólar estadounidense")
            {
                return "$ " + cantidad * 0.0088 + "00";
            }
            if (conversion == "CAD - Dólar canadiense")
            {
                return "$ " + cantidad * 0.0113 + "00";
            }
            if (conversion == "EUR - Euro")
            {
                return "€ " + cantidad * 0.0078 + "00";
            }

            return "$ " + 0.0;
        }

        private void MiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((monto.Text.IndexOf(".") != -1) && monto.Text.IndexOf(".") == monto.Text.Length-3)
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                
            }
        }
    }
}