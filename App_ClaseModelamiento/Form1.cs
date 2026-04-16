using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_ClaseModelamiento
{
    public partial class Form1 : Form
    {
       
        dbGeneral dbG=new dbGeneral();
        Products p= new Products();
        public Form1()
        {
            InitializeComponent();
            dbG.ObtenerConexion();
            dbG.Buscar(dataProducts);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.p._Id = Convert.ToInt32(txtID.Text);
            this.p._Name = txtName.Text;
            this.p._Price = Convert.ToDouble(txtPrice.Text);
            this.p._Amount = Convert.ToInt32(txtAmount.Text);

            int resultado =dbG.Agregar(this.p);

            if (resultado > 0)
            {
                MessageBox.Show("Datos guardados","Guardar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dbG.Buscar(this.dataProducts);
            }
            else
            {
                MessageBox.Show("Error al guardar los datos", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataProducts.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataProducts.CurrentRow.Cells[2].Value.ToString();
            txtAmount.Text = dataProducts.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
