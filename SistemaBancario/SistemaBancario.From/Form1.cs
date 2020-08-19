using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario.From
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarControles();
        }
        private Double monto;
        private void activarControles()
        {
            txtCliente.Enabled = false;
            txtMonto.Enabled = false;
            btnAbrir.Enabled = false;

            btnDeposito.Enabled = true;
            btnRetiro.Enabled = true;
        }
        private void desactivarControles()
        {
            txtCliente.Enabled = true;
            txtMonto.Enabled = true;
            btnAbrir.Enabled = true;

            btnDeposito.Enabled = false;
            btnRetiro.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cliente;
            cliente = txtCliente.Text;
            //Leemos el monto a depositar
            monto = Convert.ToDouble(txtMonto.Text);
            if (monto >= 0)
            {
                //Activamos los controles si el monto de depósito es correcto
                activarControles();
            }
            else
            {
                MessageBox.Show("El monto debe ser mayor a cero", "Gestión de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Double leer(string mensaje) 
        {
            Double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese monto a " + mensaje, "Gestión de Ahorros", "0", 100, 0));
            return cantidad;
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Double deposito;
            deposito = leer("Deposito");
            monto = monto + deposito;
           
            lstDepositos.Items.Add(deposito);
            mostrar();
        }
        private void mostrar() 
        {
            txtSaldo.Text = Convert.ToString(monto);
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Double retiro;
            retiro = leer("retirar");
            // Evaluar
            if (retiro <= monto)
            {
                monto = monto - retiro;
                lstRetiros.Items.Add(retiro);
                mostrar();
            }
            else
            {
                MessageBox.Show("El cantidad a retirar excede el saldo", "Gestión de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtSaldo.Clear();
            lstDepositos.Items.Clear();
            lstRetiros.Items.Clear();
            desactivarControles();

        }
    }
}
