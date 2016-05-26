using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sql2excel.models {
    /// <summary>
    /// Gestiona una actualización unitaria
    /// </summary>
    class Actualizacion {

        private String _hoja;
        /// <summary>
        /// Nombre de la hoja del libro a actualizar
        /// </summary>
        public String Hoja {
            get {
                return _hoja;
            }
            set {
                _hoja = value;
            }
        }

        private String _celdaInicio;
        /// <summary>
        /// Indica la primera celda a modificar con los resultados
        /// obtenidos de la base de datos
        /// </summary>
        public String CeldaInicio {
            get {
                return _celdaInicio;
            }
            set {
                _celdaInicio = value;
            }
        }

        private String _sql;
        /// <summary>
        /// Sentencia SQL a ejecutar para obtener los datos
        /// </summary>
        public String SQL {
            get {
                return _sql;
            }
            set {
                _sql = value;
            }
        }

        private bool _trasponer = false;
        /// <summary>
        /// Indica si los datos han de trasponerse, es decir, 
        /// cambiar filas por columnas. El valor por defecto es
        /// <c>false</c>.
        /// </summary>
        public bool Trasponer {
            get {
                return _trasponer;
            }
            set {
                _trasponer = value;
            }
        }


    }
}
