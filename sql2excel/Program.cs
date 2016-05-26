using System;
using System.Collections.Generic;
using System.IO;
using log4net.Core;
using NDesk.Options;
using Newtonsoft.Json;
using sql2excel.gui;
using sql2excel.models;


namespace sql2excel {

    class Program {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(string.Format("{0}({1})", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args) {

            // Carga la configuración de log4net desde App.congif
            log4net.Config.XmlConfigurator.Configure();
            if (log.IsDebugEnabled) { log.Debug("Configurado log4net."); }

            Console.WriteLine();

            bool showHelp = false;
            bool showGui = false;
            int errorLevel = 0;
            string server = String.Empty;
            string db = String.Empty;
            string fileConf = String.Empty;

            var p = new OptionSet() {
                { "g|gui",
                    "En lugar de lanzar el proceso, muestra la interfaz gráfica para un uso manual.",
                    v => showGui = (v!=null) },
                {"v|verbose=","Especifica el nivel de detalle del archivo LOG ignorando la " +
                    "configuración definida en el archivo .CONGIF.\n" +
                    "\t5 - Todos los niveles: DEBUG, INFO, WARN, ERROR, FATAL\n" +
                    "\t4 - INFO, WARN, ERROR, FATAL\n" +
                    "\t3 - WARN, ERROR, FATAL\n" + 
                    "\t2 - ERROR, FATAL\n" +
                    "\t1 - FATAL\n",
                    v => errorLevel = Int32.Parse(v)},
                {"s|server=","Servidor SQL Server para la conexión",
                    v => server = v},
                {"d|database=","Nombre de la base de datos de inicio en el servidor SQL Server para la conexión",
                    v => db = v},
                {"c|config=","Ruta completa del archivo JSON de configuración de las actualizaciones",
                    v => fileConf = v},
                { "h|help",  "Muestra las opciones de la línea de comandos", 
                    v => showHelp = (v != null) }
            };

            List<string> extra;
            try {
                log.Debug("Parseando los argumentos");
                extra = p.Parse(args);
            } catch (Exception ex) {
                log.Fatal("Argumentos de la línea de comandos no válidos", ex);
                ShowHelp(p);
            }

            switch (errorLevel) {
                case 0:
                    // se utiliza el nivel establecido en la configuración de la app.
                    break;
                case 1: log.Logger.Repository.Threshold = Level.Fatal;
                    break;
                case 2: log.Logger.Repository.Threshold = Level.Error;
                    break;
                case 3: log.Logger.Repository.Threshold = Level.Warn;
                    break;
                case 4: log.Logger.Repository.Threshold = Level.Info;
                    break;
                case 5: log.Logger.Repository.Threshold = Level.Debug;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("El parámetro -verbose solamente puede tener los valores [0-5]");
                    Console.WriteLine("Utiliza sql2excel -h para obtener más detalles");
                    Console.WriteLine();
                    break;
            }

            if (log.IsDebugEnabled) {
                log.DebugFormat("Nivel de mensajes establecido a {0}", log.Logger.Repository.Threshold.DisplayName);
            }

            if (showHelp) {
                log.Debug("Mostrando ayuda");
                ShowHelp(p);
                return 0;
            } else if (showGui) {
                if (log.IsDebugEnabled) { log.Debug("Iniciando entorno gráfico según el parámetro de la línea de comandos -g"); }
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new MainForm());
                return 0;
            } else {
                if (log.IsDebugEnabled) { log.Debug("Iniciando en modo comandos sin entorno gráfico"); }
                Console.WriteLine();

                // 1. Cargar el archivo de configuración
                if (String.IsNullOrWhiteSpace(fileConf)) {
                    log.Fatal("No se ha especificado archivo de configuración");
                    return 1;
                }

                String conf = String.Empty;

                try {
                    log.Info("Cargando archivo de actualizaciones");
                    using (StreamReader reader = new StreamReader(fileConf)) {
                        conf = reader.ReadToEnd();
                    }
                } catch (Exception ex) {
                    log.Fatal("No se ha podido leer el archivo de configuración", ex);
                }

                ArchivoExcel excel = JsonConvert.DeserializeObject<ArchivoExcel>(conf);

                // 2. Cargar configuración de conexión y realizar prueba
                if (String.IsNullOrWhiteSpace(server)) {
                    log.Fatal("No se ha especificado un servidor SQL Server");
                    return 2;
                }

                if (String.IsNullOrWhiteSpace(db)) {
                    log.Fatal("No se ha especificado una base de datos");
                    return 3;
                }

                Conexion conexion = new Conexion {
                    Servidor = server,
                    BaseDatos = db
                };

                log.InfoFormat("Probando la conexión a {0}/{1}", server, db);
                if (conexion.Probar() == false) {
                    log.Fatal("Ha fallado la prueba de conexión a la base de datos");
                    return 4;
                }

                // 3. Aplicamos las actualizaciones
                try {
                    log.Info("Aplicando actualizaciones");
                    excel.ActualizarDatos(conexion);
                } catch (Exception ex) {
                    log.Fatal("Error al actualizar los datos", ex);
                    return 5;
                }

                // 4. Salimos sin errores
                log.Info("Proceso terminado");
                return 0;
            }

        }

        private static void ShowHelp(OptionSet options) {
            Console.WriteLine("Actualiza datos en un documento excel existente a partir de un conjunto de consultas SQL.");
            Console.WriteLine("La configuración general se realiza en el fichero app.config.");
            Console.WriteLine("Las consultas se toman de un fichero .json. Para ver la estructura del archivo inpecciona el archivo input.json");
            Console.WriteLine();
            Console.WriteLine("Uso: sql2excel [OPCIONES]");
            Console.WriteLine();
            Console.WriteLine("Opciones:");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
