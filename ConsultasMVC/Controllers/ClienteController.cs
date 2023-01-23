using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultasMVC.Models.Dao;
using ConsultasMVC.Models.Dto;
using ConsultasMVC.Views;
using System.Windows.Forms; 

namespace ConsultasMVC.Controllers
{
    class ClienteController
    {
        ClienteView Vista;
        //Constructor
        public ClienteController(ClienteView View) {
            Vista = View;
            //inicializar eventos
            //BUSCAR
            Vista.Load += new EventHandler(ClienteList);
            Vista.btn_buscar.Click += new EventHandler(ClienteList );
            Vista.btn_actualizar.Click += new EventHandler(ClienteList);
            Vista.txt_buscar.TextChanged += new EventHandler(ClienteList);
            // AGREGAR
            Vista.btn_agregar.Click += new EventHandler(ClienteAdd);
            Vista.btn_guardar.Click += new EventHandler(ClienteSave);
            // SELECCIONAR REGISTRO
            Vista.TablaCliente.CellMouseClick += new DataGridViewCellMouseEventHandler(ClienteSeleccionar);
        }


        private void ClienteList(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            Vista.TablaCliente.DataSource =
                db.VerRegistros(Vista.txt_buscar.Text);
        }

        private void ClienteAdd(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            db.Insert(
                Vista.txt_nombre.Text,
                Vista.txt_apellido.Text,
                Vista.txt_direccion.Text,
                Vista.txt_ciudad.Text,
                Vista.txt_email.Text,
                Vista.txt_telefono.Text,
                Vista.txt_ocupacion.Text
            );

            MessageBox.Show("Dato Agregado.");

            Vista.txt_id.Text = "";
            Vista.txt_nombre.Text = "";
            Vista.txt_apellido.Text = "";
            Vista.txt_direccion.Text = "";
            Vista.txt_ciudad.Text = "";
            Vista.txt_email.Text = "";
            Vista.txt_telefono.Text = "";
            Vista.txt_ocupacion.Text = "";
            Vista.txt_estatus.Text = "";

            // PRODUCE UN ERROR QUE NO ME DEJA ACTUALIZAR
            //  AGREGUE EL BOTON DE ACTUALIZAR PARA SOLENTAR EL PROBLEMA
            // Vista.TablaCliente.DataSource = db.VerRegistros("");
        }

        private void ClienteSave(object sender, EventArgs e)
        {
            ClienteDao db = new ClienteDao();
            db.Edit(
                Int32.Parse(Vista.txt_id.Text),
                Vista.txt_nombre.Text,
                Vista.txt_apellido.Text,
                Vista.txt_direccion.Text,
                Vista.txt_ciudad.Text,
                Vista.txt_email.Text,
                Vista.txt_telefono.Text,
                Vista.txt_ocupacion.Text,
                Vista.txt_estatus.Text
            );

            MessageBox.Show("Dato Actualizado.");

            Vista.txt_id.Text = "";
            Vista.txt_nombre.Text = "";
            Vista.txt_apellido.Text = "";
            Vista.txt_direccion.Text = "";
            Vista.txt_ciudad.Text = "";
            Vista.txt_email.Text = "";
            Vista.txt_telefono.Text = "";
            Vista.txt_ocupacion.Text = "";
            Vista.txt_estatus.Text = "";


            // PRODUCE UN ERROR QUE NO ME DEJA ACTUALIZAR
            //  AGREGUE EL BOTON DE ACTUALIZAR PARA SOLENTAR EL PROBLEMA
            //Vista.TablaCliente.DataSource = db.VerRegistros("");
        }

        private void ClienteSeleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            Vista.txt_id.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[0].Value.ToString();
            Vista.txt_nombre.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[1].Value.ToString();
            Vista.txt_apellido.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[2].Value.ToString();
            Vista.txt_direccion.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[3].Value.ToString();
            Vista.txt_ciudad.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[4].Value.ToString();
            Vista.txt_email.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[5].Value.ToString();
            Vista.txt_telefono.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[6].Value.ToString();
            Vista.txt_ocupacion.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[7].Value.ToString();
            Vista.txt_estatus.Text = Vista.TablaCliente.Rows[e.RowIndex].Cells[8].Value.ToString();

            // MessageBox.Show("id: " + id);
            // MessageBox.Show("nombre: " + nombre);
            // MessageBox.Show("apellido: " + apellido);
            // MessageBox.Show("direccion: " + direccion);
            // MessageBox.Show("ciudad: " + ciudad);
            // MessageBox.Show("email: " + email);
            // MessageBox.Show("telefono: " + telefono);
            // MessageBox.Show("ocupacion: " + ocupacion);
            // MessageBox.Show("estatus: " + estatus); 
        }
    }
}
