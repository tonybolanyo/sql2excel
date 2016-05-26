using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sql2excel.helpers {
    /// <summary>
    /// Ayuda con las listas
    /// </summary>
    class ListHelper {

        /// <summary>
        /// Convierte una lista de arrays en un array multidimensional
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrays"></param>
        /// <returns></returns>
        /// <remarks>Copiado de 
        /// http://stackoverflow.com/questions/9774901/how-to-convert-list-of-arrays-into-a-multidimensional-array
        /// </remarks>
        public static T[,] CreateRectangularArray<T>(IList<T[]> arrays) {
            // TODO: Validation and special-casing for arrays.Count == 0
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++) {
                var array = arrays[i];
                if (array.Length != minorLength) {
                    throw new ArgumentException
                        ("Todos los arrays deben tener el mismo tamaño");
                }
                for (int j = 0; j < minorLength; j++) {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }

        public static T[,] CreateRectangularArray<T>(IList<T[]> arrays, bool trasponer = false) {
            // TODO: Validation and special-casing for arrays.Count == 0
            int minorLength = arrays[0].Length;
            T[,] ret;
            if (trasponer) {
                ret = new T[minorLength, arrays.Count];
            } else {
                ret = new T[arrays.Count, minorLength];
            }
            for (int i = 0; i < arrays.Count; i++) {
                var array = arrays[i];
                if (array.Length != minorLength) {
                    throw new ArgumentException
                        ("Todos los arrays deben tener el mismo tamaño");
                }
                for (int j = 0; j < minorLength; j++) {
                    if (trasponer) {
                        ret[j, i] = array[j];
                    } else {
                        ret[i, j] = array[j];
                    }
                }
            }
            return ret;
        }


    }
}
