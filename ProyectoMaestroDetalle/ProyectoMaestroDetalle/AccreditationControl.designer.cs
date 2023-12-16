using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoMaestroDetalle
{
    partial class AccreditationControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccreditationControl));
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btninsertar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyNamelbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.txtServiceHours = new System.Windows.Forms.TextBox();
            this.cmbidStudent = new System.Windows.Forms.ComboBox();
            this.cmbidClub = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificar.Location = new System.Drawing.Point(373, 48);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 34);
            this.btnModificar.TabIndex = 63;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEliminar.Location = new System.Drawing.Point(724, 51);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 34);
            this.btnEliminar.TabIndex = 62;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btninsertar
            // 
            this.btninsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btninsertar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btninsertar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btninsertar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btninsertar.Location = new System.Drawing.Point(12, 48);
            this.btninsertar.Name = "btninsertar";
            this.btninsertar.Size = new System.Drawing.Size(100, 34);
            this.btninsertar.TabIndex = 61;
            this.btninsertar.Text = "AGREGAR";
            this.btninsertar.UseVisualStyleBackColor = false;
            this.btninsertar.Click += new System.EventHandler(this.btninsertar_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(501, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "idStudent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(174, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "ServiceHours";
            // 
            // CompanyNamelbl
            // 
            this.CompanyNamelbl.AutoSize = true;
            this.CompanyNamelbl.BackColor = System.Drawing.Color.Black;
            this.CompanyNamelbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CompanyNamelbl.Location = new System.Drawing.Point(10, 5);
            this.CompanyNamelbl.Name = "CompanyNamelbl";
            this.CompanyNamelbl.Size = new System.Drawing.Size(39, 13);
            this.CompanyNamelbl.TabIndex = 44;
            this.CompanyNamelbl.Text = "Credits";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(812, 282);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtCredits
            // 
            this.txtCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCredits.Location = new System.Drawing.Point(10, 21);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(159, 20);
            this.txtCredits.TabIndex = 42;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Blue;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(11, 378);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(100, 34);
            this.btnMenu.TabIndex = 189;
            this.btnMenu.Text = "IR AL MENÚ";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtServiceHours
            // 
            this.txtServiceHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtServiceHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceHours.Location = new System.Drawing.Point(175, 21);
            this.txtServiceHours.Name = "txtServiceHours";
            this.txtServiceHours.Size = new System.Drawing.Size(159, 20);
            this.txtServiceHours.TabIndex = 190;
            // 
            // cmbidStudent
            // 
            this.cmbidStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbidStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbidStudent.FormattingEnabled = true;
            this.cmbidStudent.Location = new System.Drawing.Point(504, 21);
            this.cmbidStudent.Name = "cmbidStudent";
            this.cmbidStudent.Size = new System.Drawing.Size(153, 21);
            this.cmbidStudent.TabIndex = 191;
            // 
            // cmbidClub
            // 
            this.cmbidClub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbidClub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbidClub.FormattingEnabled = true;
            this.cmbidClub.Location = new System.Drawing.Point(338, 21);
            this.cmbidClub.Name = "cmbidClub";
            this.cmbidClub.Size = new System.Drawing.Size(159, 21);
            this.cmbidClub.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(338, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "idClub";
            // 
            // AccreditationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 416);
            this.Controls.Add(this.cmbidStudent);
            this.Controls.Add(this.txtServiceHours);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.cmbidClub);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btninsertar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompanyNamelbl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtCredits);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccreditationControl";
            this.Text = "AccreditationControl";
            this.Load += new System.EventHandler(this.Products_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnModificar;
        private Button btnEliminar;
        private Button btninsertar;
        private Label label5;
        private Label label2;
        private Label CompanyNamelbl;
        private DataGridView dataGridView1;
        private TextBox txtCredits;
        private Button btnMenu;
        private TextBox txtServiceHours;
        private ComboBox cmbidStudent;
        private ComboBox cmbidClub;
        private Label label1;
    }
}