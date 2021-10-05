
namespace Gerstor_De_Particiones_De_Memoria
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
            this.listPending = new System.Windows.Forms.ListBox();
            this.listProcessActive = new System.Windows.Forms.ListBox();
            this.comboMemoryModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAssignAlgortihm = new System.Windows.Forms.ComboBox();
            this.buttonAddProcess = new System.Windows.Forms.Button();
            this.buttonQuitProcess = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelRam = new System.Windows.Forms.Panel();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listPending
            // 
            this.listPending.FormattingEnabled = true;
            this.listPending.IntegralHeight = false;
            this.listPending.Items.AddRange(new object[] {
            "Calculadora (128KB)",
            "Chrome (8192KB)",
            "Explorador (512KB)",
            "NotePad (2048KB)",
            "Paint (512KB)",
            "PowerPoint (2048KB)",
            "Recortes (256KB)",
            "Skype (4096KB)",
            "Teams (4096KB)",
            "Word (1024KB)"});
            this.listPending.Location = new System.Drawing.Point(112, 132);
            this.listPending.Name = "listPending";
            this.listPending.Size = new System.Drawing.Size(140, 121);
            this.listPending.TabIndex = 1;
            // 
            // listProcessActive
            // 
            this.listProcessActive.FormattingEnabled = true;
            this.listProcessActive.Location = new System.Drawing.Point(112, 304);
            this.listProcessActive.Name = "listProcessActive";
            this.listProcessActive.Size = new System.Drawing.Size(140, 121);
            this.listProcessActive.TabIndex = 2;
            // 
            // comboMemoryModel
            // 
            this.comboMemoryModel.FormattingEnabled = true;
            this.comboMemoryModel.Location = new System.Drawing.Point(112, 462);
            this.comboMemoryModel.Name = "comboMemoryModel";
            this.comboMemoryModel.Size = new System.Drawing.Size(140, 21);
            this.comboMemoryModel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modelo de memoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Algoritmo de asignación";
            // 
            // comboAssignAlgortihm
            // 
            this.comboAssignAlgortihm.FormattingEnabled = true;
            this.comboAssignAlgortihm.Location = new System.Drawing.Point(112, 515);
            this.comboAssignAlgortihm.Name = "comboAssignAlgortihm";
            this.comboAssignAlgortihm.Size = new System.Drawing.Size(140, 21);
            this.comboAssignAlgortihm.TabIndex = 6;
            // 
            // buttonAddProcess
            // 
            this.buttonAddProcess.Location = new System.Drawing.Point(258, 179);
            this.buttonAddProcess.Name = "buttonAddProcess";
            this.buttonAddProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProcess.TabIndex = 8;
            this.buttonAddProcess.Text = "Agregar";
            this.buttonAddProcess.UseVisualStyleBackColor = true;
            this.buttonAddProcess.Click += new System.EventHandler(this.buttonAddProcess_Click);
            // 
            // buttonQuitProcess
            // 
            this.buttonQuitProcess.Location = new System.Drawing.Point(258, 350);
            this.buttonQuitProcess.Name = "buttonQuitProcess";
            this.buttonQuitProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonQuitProcess.TabIndex = 9;
            this.buttonQuitProcess.Text = "Terminar";
            this.buttonQuitProcess.UseVisualStyleBackColor = true;
            this.buttonQuitProcess.Click += new System.EventHandler(this.buttonQuitProcess_Click);
            // 
            // panelRam
            // 
            this.panelRam.Location = new System.Drawing.Point(354, 93);
            this.panelRam.Name = "panelRam";
            this.panelRam.Size = new System.Drawing.Size(1050, 250);
            this.panelRam.TabIndex = 10;
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(258, 489);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonDraw.TabIndex = 12;
            this.buttonDraw.Text = "Aplicar";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 626);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.panelRam);
            this.Controls.Add(this.buttonQuitProcess);
            this.Controls.Add(this.buttonAddProcess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAssignAlgortihm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboMemoryModel);
            this.Controls.Add(this.listProcessActive);
            this.Controls.Add(this.listPending);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listPending;
        private System.Windows.Forms.ListBox listProcessActive;
        private System.Windows.Forms.ComboBox comboMemoryModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAssignAlgortihm;
        private System.Windows.Forms.Button buttonAddProcess;
        private System.Windows.Forms.Button buttonQuitProcess;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelRam;
        private System.Windows.Forms.Button buttonDraw;
    }
}

