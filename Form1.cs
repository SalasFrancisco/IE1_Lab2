using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALUMNO
{
    public partial class Form1 : Form
    {
        Decimal Importe = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Decimal Importe = 0;
        }

        private void BtnVer_Click(object sender, EventArgs e)
        {

            Grilla.Rows.Clear();

            Barrios oBarrios = new Barrios();
            DataTable TabBarrios = oBarrios.getdata();

            Viajes oViajes = new Viajes();
            DataTable TabViajes = oViajes.getdata();

            Choferes oChoferes = new Choferes();
            DataTable TabChoferes = oChoferes.getdata();
            Decimal Total = 0;
            

            if (TxtImporte.Text == "")
            {
                TxtImporte.Text = "0";
                Importe = 0;
            }
            else
            {
                Importe = Convert.ToDecimal(TxtImporte.Text);
            }
            
            
            foreach (DataRow filaViaje in TabViajes.Rows)
            {
                DateTime fecha = Convert.ToDateTime(filaViaje["fecha"]);
                string fechaViaje = fecha.ToString("dd/MM/yyyy");

                if (fecha >= DtpDesde.Value && fecha <= DtpHasta.Value && Convert.ToDecimal(filaViaje["importe"]) > Importe)
                {
                    DataRow filaChofer = TabChoferes.Rows.Find(filaViaje["chofer"]);
                    DataRow filaOrigen = TabBarrios.Rows.Find(filaViaje["desdebarrio"]);
                    DataRow filaDestino = TabBarrios.Rows.Find(filaViaje["hastabarrio"]);

                    Total += Convert.ToDecimal(filaViaje["importe"]);

                    Grilla.Rows.Add(filaViaje["viaje"], fechaViaje, filaOrigen["nombre"], filaDestino["nombre"], filaChofer["nombre"], filaViaje["importe"] + " €");
                    LblTotal.Text = Total.ToString();
                }
            }
            
            
        }
    }
}
