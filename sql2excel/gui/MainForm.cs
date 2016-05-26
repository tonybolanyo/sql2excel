using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sql2excel.helpers;
using System.Data.SqlClient;
using sql2excel.models;
using Newtonsoft.Json;
using System.IO;

namespace sql2excel.gui {
    public partial class MainForm : Form {

        /// <summary>
        /// Para la depuración mediante logger
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(string.Format("{0}({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));

        /// <summary>
        /// Permite enlazar la salida de consola de log4net a un TextBox
        /// </summary>
        private TextBoxWriter _logWriter;

        /// <summary>
        /// Mantiene datos de la conexión a utilizar
        /// </summary>
        private Conexion _conexion;

        /// <summary>
        /// Archivo excel en uso
        /// </summary>
        private ArchivoExcel _excel;

        /// <summary>
        /// Constructor básico
        /// </summary>
        public MainForm() {
            InitializeComponent();
            _logWriter = new TextBoxWriter(txtLogConsole);
            _conexion = new Conexion();

            txtNumLineasConsola.Text = "";
            for (int i = 1; i < 10000; i++) {
                txtNumLineasConsola.Text += i.ToString() + "\r\n";
            }
            txtNumLineasConfig.Text = txtNumLineasConsola.Text;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Console.SetOut(_logWriter);
            propiedadesConexion.SelectedObject = _conexion;
        }

        private void tsbLimpiarConsola_Click(object sender, EventArgs e) {
            txtLogConsole.Text = String.Empty;
        }

        private void tsbCargarConfiguracion_Click(object sender, EventArgs e) {
            try {
                if (cargarConfDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    StreamReader archivo = new StreamReader(cargarConfDlg.OpenFile());
                    txtArchivo.Text = archivo.ReadToEnd();
                    archivo.Close();
                    archivo.Dispose();
                    _excel = JsonConvert.DeserializeObject<ArchivoExcel>(txtArchivo.Text);
                }
            } catch (Exception ex) {
                log.Error("Error al cargar archivo de configuración desde el GUI", ex);
            }
        }

        private void tsbGuardarConfiguracion_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(txtArchivo.Text)) {
                MessageBox.Show(this, "¡Eh! No has escrito ningún archivo de configuración.", "Archivo de configuración vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try {
                if (guardarConfDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    StreamWriter archivo = new StreamWriter(guardarConfDlg.OpenFile());
                    archivo.Write(txtArchivo.Text);
                    archivo.Close();
                    archivo.Dispose();
                }
            } catch (Exception ex) {
                log.Error(ex);
            }
        }

        private void tsbGenerarExcel_Click(object sender, EventArgs e) {
            if (_excel == null) {
                MessageBox.Show(this, "Debes cargar un archivo de configuración para lanzar la actualización", "No hay archivo cargaddo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try {
                _excel.ActualizarDatos(_conexion);
            } catch (Exception ex) {
                log.Error("Error al actualizar los datos desde el GUI", ex);
            }
        }

        private void tsbProbarConexion_Click(object sender, EventArgs e) {
            bool conectado = false;
            Console.WriteLine("Probando la conexión");

            try {
                conectado = _conexion.Probar();
            } catch (ArgumentNullException ane) {
                MessageBox.Show(this, ane.Message, "Error al probar la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                log.Error("Error al probar la conexión", ex);
            }

            if (conectado) {
                lblEstadoConexion.Text = "OK";
                lblEstadoConexion.ForeColor = Color.Green;
            } else {
                lblEstadoConexion.Text = "ERROR";
                lblEstadoConexion.ForeColor = Color.Red;
            }
        }
    }
}
