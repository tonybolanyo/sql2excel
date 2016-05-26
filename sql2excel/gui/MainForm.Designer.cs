namespace sql2excel.gui {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtLogConsole = new System.Windows.Forms.TextBox();
            this.propiedadesConexion = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblParametros = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.txtNumLineasConfig = new System.Windows.Forms.TextBox();
            this.lblArchivoConfiguracion = new System.Windows.Forms.Label();
            this.txtNumLineasConsola = new System.Windows.Forms.TextBox();
            this.lblConsola = new System.Windows.Forms.Label();
            this.cargarConfDlg = new System.Windows.Forms.OpenFileDialog();
            this.guardarConfDlg = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCargarConfiguracion = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarConfiguracion = new System.Windows.Forms.ToolStripButton();
            this.tsbGenerarExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpiarConsola = new System.Windows.Forms.ToolStripButton();
            this.tsbProbarConexion = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstadoConexion = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogConsole
            // 
            this.txtLogConsole.BackColor = System.Drawing.Color.Black;
            this.txtLogConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogConsole.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogConsole.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtLogConsole.Location = new System.Drawing.Point(50, 23);
            this.txtLogConsole.Multiline = true;
            this.txtLogConsole.Name = "txtLogConsole";
            this.txtLogConsole.ReadOnly = true;
            this.txtLogConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogConsole.Size = new System.Drawing.Size(617, 200);
            this.txtLogConsole.TabIndex = 0;
            // 
            // propiedadesConexion
            // 
            this.propiedadesConexion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propiedadesConexion.HelpBackColor = System.Drawing.Color.White;
            this.propiedadesConexion.Location = new System.Drawing.Point(0, 18);
            this.propiedadesConexion.Name = "propiedadesConexion";
            this.propiedadesConexion.Size = new System.Drawing.Size(222, 197);
            this.propiedadesConexion.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 67);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLogConsole);
            this.splitContainer1.Panel2.Controls.Add(this.txtNumLineasConsola);
            this.splitContainer1.Panel2.Controls.Add(this.lblConsola);
            this.splitContainer1.Size = new System.Drawing.Size(667, 442);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.propiedadesConexion);
            this.splitContainer2.Panel1.Controls.Add(this.lblParametros);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtArchivo);
            this.splitContainer2.Panel2.Controls.Add(this.txtNumLineasConfig);
            this.splitContainer2.Panel2.Controls.Add(this.lblArchivoConfiguracion);
            this.splitContainer2.Size = new System.Drawing.Size(667, 215);
            this.splitContainer2.SplitterDistance = 222;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.Location = new System.Drawing.Point(0, 0);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(86, 18);
            this.lblParametros.TabIndex = 6;
            this.lblParametros.Text = "Parámetros";
            // 
            // txtArchivo
            // 
            this.txtArchivo.BackColor = System.Drawing.Color.Black;
            this.txtArchivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArchivo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivo.ForeColor = System.Drawing.Color.White;
            this.txtArchivo.Location = new System.Drawing.Point(50, 23);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtArchivo.Size = new System.Drawing.Size(391, 192);
            this.txtArchivo.TabIndex = 0;
            this.txtArchivo.WordWrap = false;
            // 
            // txtNumLineasConfig
            // 
            this.txtNumLineasConfig.BackColor = System.Drawing.Color.DimGray;
            this.txtNumLineasConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumLineasConfig.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumLineasConfig.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.txtNumLineasConfig.Location = new System.Drawing.Point(0, 23);
            this.txtNumLineasConfig.Multiline = true;
            this.txtNumLineasConfig.Name = "txtNumLineasConfig";
            this.txtNumLineasConfig.ReadOnly = true;
            this.txtNumLineasConfig.ShortcutsEnabled = false;
            this.txtNumLineasConfig.Size = new System.Drawing.Size(50, 192);
            this.txtNumLineasConfig.TabIndex = 3;
            this.txtNumLineasConfig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumLineasConfig.WordWrap = false;
            // 
            // lblArchivoConfiguracion
            // 
            this.lblArchivoConfiguracion.AutoSize = true;
            this.lblArchivoConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArchivoConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivoConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.lblArchivoConfiguracion.Name = "lblArchivoConfiguracion";
            this.lblArchivoConfiguracion.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblArchivoConfiguracion.Size = new System.Drawing.Size(170, 23);
            this.lblArchivoConfiguracion.TabIndex = 1;
            this.lblArchivoConfiguracion.Text = "Archivo de configuración";
            // 
            // txtNumLineasConsola
            // 
            this.txtNumLineasConsola.BackColor = System.Drawing.Color.DimGray;
            this.txtNumLineasConsola.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNumLineasConsola.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumLineasConsola.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.txtNumLineasConsola.Location = new System.Drawing.Point(0, 23);
            this.txtNumLineasConsola.Multiline = true;
            this.txtNumLineasConsola.Name = "txtNumLineasConsola";
            this.txtNumLineasConsola.ReadOnly = true;
            this.txtNumLineasConsola.ShortcutsEnabled = false;
            this.txtNumLineasConsola.Size = new System.Drawing.Size(50, 200);
            this.txtNumLineasConsola.TabIndex = 2;
            this.txtNumLineasConsola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumLineasConsola.WordWrap = false;
            // 
            // lblConsola
            // 
            this.lblConsola.AutoSize = true;
            this.lblConsola.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConsola.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsola.Location = new System.Drawing.Point(0, 0);
            this.lblConsola.Name = "lblConsola";
            this.lblConsola.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblConsola.Size = new System.Drawing.Size(126, 23);
            this.lblConsola.TabIndex = 1;
            this.lblConsola.Text = "Consola de salida";
            // 
            // cargarConfDlg
            // 
            this.cargarConfDlg.DefaultExt = "*.json";
            this.cargarConfDlg.FileName = "ejemplo.json";
            this.cargarConfDlg.Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*";
            this.cargarConfDlg.Title = "Cargar archivo de actualizaciones";
            // 
            // guardarConfDlg
            // 
            this.guardarConfDlg.DefaultExt = "*.json";
            this.guardarConfDlg.FileName = "ejemplo.json";
            this.guardarConfDlg.Filter = "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*";
            this.guardarConfDlg.RestoreDirectory = true;
            this.guardarConfDlg.SupportMultiDottedExtensions = true;
            this.guardarConfDlg.Title = "Guardar archivo de actualizaciones";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCargarConfiguracion,
            this.tsbGuardarConfiguracion,
            this.tsbGenerarExcel,
            this.tsbLimpiarConsola,
            this.tsbProbarConexion});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(667, 67);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "barraHerramientas";
            // 
            // tsbCargarConfiguracion
            // 
            this.tsbCargarConfiguracion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCargarConfiguracion.Image = global::sql2excel.Properties.Resources.opened_folder_50;
            this.tsbCargarConfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCargarConfiguracion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCargarConfiguracion.Name = "tsbCargarConfiguracion";
            this.tsbCargarConfiguracion.Size = new System.Drawing.Size(54, 54);
            this.tsbCargarConfiguracion.Text = "Cargar archivo de configuración";
            this.tsbCargarConfiguracion.Click += new System.EventHandler(this.tsbCargarConfiguracion_Click);
            // 
            // tsbGuardarConfiguracion
            // 
            this.tsbGuardarConfiguracion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarConfiguracion.Image = global::sql2excel.Properties.Resources.save_as_50;
            this.tsbGuardarConfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGuardarConfiguracion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarConfiguracion.Name = "tsbGuardarConfiguracion";
            this.tsbGuardarConfiguracion.Size = new System.Drawing.Size(54, 54);
            this.tsbGuardarConfiguracion.Text = "Guardar archivo de configuración";
            this.tsbGuardarConfiguracion.Click += new System.EventHandler(this.tsbGuardarConfiguracion_Click);
            // 
            // tsbGenerarExcel
            // 
            this.tsbGenerarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGenerarExcel.Image = global::sql2excel.Properties.Resources.ms_excel_copyrighted_50;
            this.tsbGenerarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGenerarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenerarExcel.Name = "tsbGenerarExcel";
            this.tsbGenerarExcel.Size = new System.Drawing.Size(54, 54);
            this.tsbGenerarExcel.Text = "Generar excel";
            this.tsbGenerarExcel.Click += new System.EventHandler(this.tsbGenerarExcel_Click);
            // 
            // tsbLimpiarConsola
            // 
            this.tsbLimpiarConsola.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbLimpiarConsola.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLimpiarConsola.Image = global::sql2excel.Properties.Resources.broom_50;
            this.tsbLimpiarConsola.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLimpiarConsola.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpiarConsola.Name = "tsbLimpiarConsola";
            this.tsbLimpiarConsola.Size = new System.Drawing.Size(54, 54);
            this.tsbLimpiarConsola.Text = "Limpiar consola";
            this.tsbLimpiarConsola.Click += new System.EventHandler(this.tsbLimpiarConsola_Click);
            // 
            // tsbProbarConexion
            // 
            this.tsbProbarConexion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbProbarConexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProbarConexion.Image = global::sql2excel.Properties.Resources.accept_database_50;
            this.tsbProbarConexion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProbarConexion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProbarConexion.Name = "tsbProbarConexion";
            this.tsbProbarConexion.Size = new System.Drawing.Size(54, 54);
            this.tsbProbarConexion.Text = "Probar conexión";
            this.tsbProbarConexion.Click += new System.EventHandler(this.tsbProbarConexion_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblConexion,
            this.lblEstadoConexion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "Barra de estado";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(504, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Inactivo";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConexion
            // 
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(67, 17);
            this.lblConexion.Text = "Conexión:";
            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(81, 17);
            this.lblEstadoConexion.Text = "No probada";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 531);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.Text = "SQL a Excel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogConsole;
        private System.Windows.Forms.PropertyGrid propiedadesConexion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.OpenFileDialog cargarConfDlg;
        private System.Windows.Forms.SaveFileDialog guardarConfDlg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarConfiguracion;
        private System.Windows.Forms.ToolStripButton tsbCargarConfiguracion;
        private System.Windows.Forms.ToolStripButton tsbGenerarExcel;
        private System.Windows.Forms.ToolStripButton tsbLimpiarConsola;
        private System.Windows.Forms.Label lblArchivoConfiguracion;
        private System.Windows.Forms.Label lblConsola;
        private System.Windows.Forms.ToolStripButton tsbProbarConexion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblConexion;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoConexion;
        private System.Windows.Forms.TextBox txtNumLineasConsola;
        private System.Windows.Forms.TextBox txtNumLineasConfig;
        private System.Windows.Forms.Label lblParametros;
    }
}