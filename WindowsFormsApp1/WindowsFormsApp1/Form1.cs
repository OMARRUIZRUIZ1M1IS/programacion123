using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string dia;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToShortDateString();

            DateTime fecha = DateTime.Parse(lblfecha.Text);
            dia = fecha.ToString("dddd");
            MessageBox.Show(dia);

            double costo = 0;
            switch (dia)
            {
                case "domingo": costo = 2; break;
                case "lunes": costo = 4; break;
                case "martes": costo = 4; break;
                case "miércoles": costo = 4; break;
                case "jueves":costo = 4; break;
                   

                case "viernes":
                case "sabado":
                    costo = 7; break;
            }
            lblcosto.Text = costo.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e) 
        {
            string placa = txtplaca.Text;
            double costo = double.Parse(lblcosto.Text);
            DateTime fecha = DateTime.Parse(lblfecha.Text);
            DateTime horainicio = DateTime.Parse(txthorai.Text);
            DateTime horasalida = DateTime.Parse(txthoras.Text);

            //calcular hora

            TimeSpan hora = horasalida - horainicio;

            // calcular nimporte

            double importe = costo * (hora.TotalHours);


            // pasar todo al lisviw

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horainicio.ToString("t"));
            fila.SubItems.Add(horasalida.ToString("t"));

            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("c"));
            fila.SubItems.Add(importe.ToString("c"));
            lvRegistro.Items.Add(fila);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtplaca.Clear();
            txthoras.Clear();
            txthorai.Clear();
            txtplaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult R = MessageBox.Show("estas seguro que quieres salir", "señ@r",
            MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (R == DialogResult.Yes)
                this.Close();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem fila in lvRegistro.SelectedItems)
            {
                fila.Remove();
            }
        }
    }
}
