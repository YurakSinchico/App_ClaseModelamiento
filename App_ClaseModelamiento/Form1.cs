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

        private void btnUpadate_Click(object sender, EventArgs e)
        {
            p._Id= Convert.ToInt32(txtID.Text.Trim());
            p._Name = txtName.Text;
            p._Price = Convert.ToDouble(txtPrice.Text);
            p._Amount = Convert.ToInt32(txtAmount.Text);

            if (dbG.Actualizar(p) > 0)
            {
                MessageBox.Show("Los datos del docente se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbG.Buscar(dataProducts);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Producto Actual", "Estas Seguro ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dbG.Eliminar(Convert.ToInt32(txtID.Text)) > 0)
                {

                    MessageBox.Show("Producto Eliminado Correctamente!", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbG.Buscar(dataProducts);
                }
                else
                {
                    MessageBox.Show("No se pudoeliminar el producto", "Producto No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    
    }
}
