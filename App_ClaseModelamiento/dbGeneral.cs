using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //PARA poder ocupar el data girl 
using MySql.Data.MySqlClient;
namespace App_ClaseModelamiento
{
    public class dbGeneral
    {
        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database= dbmodsoftt; Uid= root;pwd=;");
            try
            {
                conectar.Open();
                Console.WriteLine("Coneccion exitosa");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con la DB");
            }
            return conectar;
        }

        public int Agregar(Products p)

        {

            try

            {

                int retorno = 0;

                MySqlCommand comando = new MySqlCommand(string.Format("Insert into tbl_products (id, nombre, price, amount )values({0},'{1}',{2}, {3})",

                p._Id , p._Name,p._Price,p._Amount), this.ObtenerConexion());

                retorno = comando.ExecuteNonQuery();

                return retorno;

            }
            catch (Exception)

            {

                return -1;

            }

        }

        public void Buscar(DataGridView grilla)
        {
            //List<Docente> miLista = new List<Docente>();
            if (grilla.Rows.Count >= 0)
            {
                grilla.Rows.Clear();
            }
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM tbl_products"), this.ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Products p = new Products();
                    p._Id = _reader.GetInt32(0);
                    p._Name = _reader.GetString(1);
                    p._Price = _reader.GetDouble(2);
                    p._Amount = _reader.GetInt32(3);
                    string[] rows = new string[]{
                    Convert.ToString(p._Id),
                    p._Name,
                     Convert.ToString(p._Price),
                     Convert.ToString(p._Amount)
                    };
                    grilla.Rows.Add(rows);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al listar los datos de la DB");
            }
        }
    }
}
