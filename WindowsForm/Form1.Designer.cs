namespace WindowsForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.botonIniciar = new System.Windows.Forms.Button();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.pgProcesamiento = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Location = new System.Drawing.Point(245, 333);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(2);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(116, 23);
            this.botonIniciar.TabIndex = 0;
            this.botonIniciar.Text = "Iniciar Proceso";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // loadingGif
            // 
            this.loadingGif.Image = ((System.Drawing.Image)(resources.GetObject("loadingGif.Image")));
            this.loadingGif.Location = new System.Drawing.Point(255, 104);
            this.loadingGif.Margin = new System.Windows.Forms.Padding(2);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(96, 109);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGif.TabIndex = 1;
            this.loadingGif.TabStop = false;
            this.loadingGif.Visible = false;
            this.loadingGif.Click += new System.EventHandler(this.loadingGif_Click);
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(255, 293);
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(100, 20);
            this.nombreInput.TabIndex = 2;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(256, 260);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(95, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Ingresa un nombre";
            // 
            // pgProcesamiento
            // 
            this.pgProcesamiento.Location = new System.Drawing.Point(255, 218);
            this.pgProcesamiento.Name = "pgProcesamiento";
            this.pgProcesamiento.Size = new System.Drawing.Size(100, 23);
            this.pgProcesamiento.TabIndex = 4;
            this.pgProcesamiento.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(513, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar Operación";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pgProcesamiento);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.nombreInput);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.botonIniciar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.PictureBox loadingGif;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.ProgressBar pgProcesamiento;
        private System.Windows.Forms.Button btnCancelar;
    }
}

