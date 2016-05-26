using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sql2excel.helpers {
    /// <summary>
    /// Permite redireccionar un stream de texto a un
    /// control de tipo <c>TextBox</c>
    /// </summary>
    /// <remarks>
    /// <para>La utilidad principal es redireccionar la
    /// salida estándar a un control de texto, asignando
    /// el <c>TextBoxWriter</c> a la salida de la consola
    /// mediante el método <c>Console.SetOut()</c>.
    /// </para>
    /// </remarks>
    class TextBoxWriter : System.IO.TextWriter {

        private TextBoxBase _control;
        private StringBuilder _builder;

        /// <summary>
        /// Constructor básico
        /// </summary>
        /// <param name="control">El TextBox donde se
        /// mostrará el texto.</param>
        public TextBoxWriter(TextBox control)
            : base() {
            _control = control;
            _control.HandleCreated += new EventHandler(control_HandleCreated);
        }

        /// <summary>
        /// Responde al evento de creación del <c>TextBox</c>
        /// volcando todo el texto almacenado en el buffer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void control_HandleCreated(object sender, EventArgs e) {
            if (_builder != null) {
                _control.AppendText(_builder.ToString());
                _builder = null;
            }
        }

        /// <summary>
        /// Escribe un carácter en el <c>TextBox</c>
        /// </summary>
        /// <param name="value"></param>
        public override void Write(char value) {
            Write(value.ToString());
        }

        /// <summary>
        /// Escribe una cadena de texto en el <c>TextBox</c>.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value) {
            if (_control.IsHandleCreated)
                AppendText(value);
            else
                BufferText(value);
        }

        /// <summary>
        /// Escribe una cadena en el <c>TextBox</c> y añade
        /// un salto de línea al final.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value) {
            Write(value + Environment.NewLine);
        }

        /// <summary>
        /// Guarda el texto en el buffer.
        /// </summary>
        /// <param name="text"></param>
        private void BufferText(string text) {
            if (_builder == null)
                _builder = new StringBuilder();
            _builder.Append(text);
        }

        /// <summary>
        /// Agrega texto al control
        /// </summary>
        /// <param name="text"></param>
        private void AppendText(string text) {
            if (_builder != null) {
                _control.Invoke((MethodInvoker)delegate {
                    _control.AppendText(_builder.ToString());
                });
                _builder = null;
            }
            _control.Invoke((MethodInvoker)delegate {
                _control.AppendText(text);
            });
        }

        /// <summary>
        /// Devuelve la codificación usada para los textos.
        /// </summary>
        public override Encoding Encoding {
            get {
                return Encoding.Default;
            }
        }
    }
}
