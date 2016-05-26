using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using sql2excel.helpers;

namespace sql2excel.models {
    /// <summary>
    /// Colección de actualizaciones en un mismo archivo
    /// </summary>
    class ArchivoExcel {

        /// <summary>
        /// Para la depuración mediante logger
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(string.Format("{0}({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));

        /// <summary>
        /// Ruta del archivo origen usado como plantilla
        /// donde se actualizarán los datos
        /// </summary>
        public String Origen { get; set; }

        /// <summary>
        /// Ruta del archivo destino que contendrá los
        /// datos actualizados obtenidos por la consulta
        /// </summary>
        public String Destino { get; set; }

        private List<Actualizacion> _actualizaciones = new List<Actualizacion>();
        /// <summary>
        /// Listado de actualizaciones a realizar
        /// </summary>
        public List<Actualizacion> Actualizaciones {
            get {
                return _actualizaciones;
            }
            set {
                _actualizaciones = value;
            }
        }

        /// <summary>
        /// Actualiza los datos del fichero origen generando
        /// un nuevo archivo.
        /// </summary>
        /// <param name="conexion">Conexión a utilizar para realizar las consultas.</param>
        /// <param name="sobreescribir"><c>true</c> para sobreescribir el archivo destino
        /// si existe (valor por defecto). <c>false</c> en caso contrario.</param>
        /// <exception cref="ArgumentNullException">Si no se especifica el archivo origen o el destino.</exception>
        /// <exception cref="FileNotFoundException">Si no existe el archivo origen.</exception>
        /// <exception cref="ArgumentException">Si el archivo destino existe y 
        /// <paramref name="sobreescribir"/> es <c>false</c>.</exception>
        public void ActualizarDatos(Conexion conexion, bool sobreescribir = true) {
            if (String.IsNullOrWhiteSpace(this.Origen)) {
                log.Error("No se ha especificado el archivo origen");
                throw new ArgumentNullException("Origen", "No se ha especificado el archivo Origen");
            }
            if (!File.Exists(this.Origen)) {
                log.ErrorFormat("No existe el archivo origen: {0}", this.Origen);
                throw new FileNotFoundException("El archivo origen especificado no existe.", this.Origen);
            }
            if (String.IsNullOrWhiteSpace(this.Destino)) {
                log.Error("No se ha especificado el archivo destino");
                throw new ArgumentNullException("Destino", "No se ha especificado el archivo Destino");
            }
            if (!sobreescribir && File.Exists(this.Destino)) {
                log.ErrorFormat("El archivo destino existe y no se sobreescribirá: {0}", this.Destino);
                throw new ArgumentException("El archivo destino existe y no se sobreescribirá");
            }

            Excel.Application excelApp = null;
            Excel.Workbook libro = null;

            try {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;
                libro = excelApp.Workbooks.Open(this.Origen);

                int cont = 0;
                foreach (Actualizacion item in this.Actualizaciones) {
                    cont++;
                    log.InfoFormat("Aplicando actualización {0}...", cont);
                    Excel.Worksheet hoja = libro.Sheets[item.Hoja];
                    hoja.Select();
                    List<object[]> datos = conexion.Ejecutar(item.SQL, false);
                    Excel.Range rango = hoja.get_Range(item.CeldaInicio);
                    if (item.Trasponer) {
                        rango = rango.get_Resize(datos[0].Length, datos.Count);
                    } else {
                        rango = rango.get_Resize(datos.Count, datos[0].Length);
                    }

                    // Convertimos la lista de vectores en una matriz
                    object[,] datos2 = ListHelper.CreateRectangularArray(datos, item.Trasponer);
                    rango.Value = datos2;
                    
                }

                libro.SaveAs(this.Destino, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                libro.Close();
                excelApp.Quit();
            } catch (Exception ex) {
                log.Error("Error al actualizar el archivo excel", ex);
                if (libro != null) {
                    libro.Close();
                }
            } finally {
                // Según las buenas prácticas de Microsoft, nos aseguramos de liberar los recursos
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(libro);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            }
        }

        /// <summary>
        /// Crea un fichero excel según <see cref="ArchivoDestino"/>
        /// usando la conexión para las consultas.
        /// </summary>
        /// <param name="conexion">Conexión a utilizar para realizar las consultas.</param>
        /// <param name="sobreescribir"><c>true</c> para sobreescribir el archivo destino
        /// <exception cref="ArgumentNullException">Si no se especifica el archivo destino.</exception>
        /// <exception cref="ArgumentException">Si el archivo destino existe y 
        /// <paramref name="sobreescribir"/> es <c>false</c>.</exception>
        public void CrearArchivo(Conexion conexion, bool sobreescribir = true) {
            if (String.IsNullOrWhiteSpace(this.Destino)) {
                log.Error("No se ha especificado el archivo destino");
                throw new ArgumentNullException("Destino", "No se ha especificado el archivo Destino");
            }
            if (!sobreescribir && File.Exists(this.Destino)) {
                log.ErrorFormat("El archivo destino existe y no se sobreescribirá: {0}", this.Destino);
                throw new ArgumentException("El archivo destino existe y no se sobreescribirá");
            }
            log.Error("CrearArchivo no implementado");
        }
    }
}
