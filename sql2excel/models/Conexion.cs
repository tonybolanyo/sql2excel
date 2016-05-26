using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.ComponentModel;

namespace sql2excel.models {
    /// <summary>
    /// Mantiene los datos de la conexión a la base de datos
    /// y contiene algunas funciones básicas para gestionar la
    /// conexión.
    /// </summary>
    class Conexion {

        /// <summary>
        /// Para la depuración mediante logger
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(string.Format("{0}({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));

        /// <summary>
        /// Nombre del servidor SQL al que se conecta la aplicación
        /// </summary>
        [CategoryAttribute("BaseDatos"),
        Description("Nombre o dirección IP del servidor SQL Server.")]
        public String Servidor { get; set; }

        /// <summary>
        /// Base de datos sobre la que se realiza la conexión inicialmente
        /// </summary>
        [CategoryAttribute("BaseDatos"),
        Description("Nombre de la base de datos en el servidor SQL Server donde se realizarán las consultas.")]
        public String BaseDatos { get; set; }

        /// <summary>
        /// Cadena de conexión según servidor y base de datos indicadas
        /// </summary>
        [CategoryAttribute("BaseDatos"),
        Description("Cadena de conexión utilizada a partir de los datos de conexión.")]
        public String CadenaConexion {
            get {
                return String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True", this.Servidor, this.BaseDatos);
            }
        }

        /// <summary>
        /// Se sobreescribe la propiedad para que devuelva por defecto la cadena de conexión
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return this.CadenaConexion;
        }

        /// <summary>
        /// Prueba la conexión según los datos de las propiedades <see cref="this.Servidor"/>
        /// y <see cref="this.BaseDatos"/>.
        /// </summary>
        /// <returns><c>true</c> si la conexión se realiza con éxito, 
        /// <c>false</c> en caso contrario.</returns>
        /// <exception cref="ArgumentNullException">En caso de que <see cref="Servidor"/> o
        /// <see cref="BaseDatos"/> sea <c>null</c>.</exception>
        public bool Probar() {
            bool conectado = false;

            if (this.BaseDatos == null) {
                String msg = "No se ha especificado un nombre para la base de datos";
                log.Error(msg);
                throw new ArgumentNullException("BaseDatos");
            }

            if (this.Servidor == null) {
                String msg = "No se ha especificado un nombre de servidor de base de datos";
                log.Error(msg);
                throw new ArgumentNullException("Servidor");
            }

            try {
                log.DebugFormat("Probando la conexión a la base de datos {0} de {1}", this.BaseDatos, this.Servidor);
                using (SqlConnection conn = new SqlConnection(this.CadenaConexion)) {
                    conn.Open();
                    SqlCommand sql = new SqlCommand();
                    sql.Connection = conn;
                    sql.CommandText = "select 1";
                    int result = (int)sql.ExecuteScalar();
                    conectado = (result == 1);
                    conn.Close();
                }
            } catch (Exception ex) {
                log.Error(ex.Message);
            }
            return conectado;
        }

        /// <summary>
        /// Ejecuta una consulta SQL contra la conexión definida
        /// </summary>
        /// <param name="sql">Consulta SQL a ejecutar</param>
        /// <param name="usarNombres"><c>true</c> indica que el primer elemento de la lista
        /// serán los nombres de las columnas. <c>false</c> en caso contrario. Este parámetro
        /// es opcional siendo el valor por defecto <c>true</c>.</param>
        /// <returns>Lista de vectores de cadena con los resultados. Un elemento de la lista
        /// corresponde a una fila devuelta por la consulta. El vector de cadena contiene
        /// un elemento por columna que devuelve la consulta.</returns>
        public List<Object[]> Ejecutar(String sql, bool usarNombres = true) {
            try {
                List<Object[]> result = new List<Object[]>();
                using (SqlConnection conexion = new SqlConnection(this.CadenaConexion)) {
                    conexion.Open();
                    SqlDataReader reader = null;
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    reader = comando.ExecuteReader();
                    if (usarNombres) {
                        String[] nombres = new String[reader.FieldCount];
                        for (int col = 0; col < reader.FieldCount; col++) {
                            nombres[col] = reader.GetName(col);
                        }
                        result.Add(nombres);
                    }
                    while (reader.Read()) {
                        Object[] fila = new Object[reader.FieldCount];
                        for (int col = 0; col < reader.FieldCount; col++) {
                            fila[col] = reader[col];
                        }
                        result.Add(fila);
                    }
                    conexion.Close();
                    return result;
                }
            } catch (Exception ex) {
                log.Error("Error al ejecutar la sentencia SQL");
                throw new ApplicationException("Error al ejecutar la sentencia SQL", ex);
            }
        }
    }
}
