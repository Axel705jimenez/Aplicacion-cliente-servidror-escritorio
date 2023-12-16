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
using System.Data.SqlClient;

namespace ProyectoMaestroDetalle
{
    partial class MenuOpciones
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
            this.btnAccreditationControl = new System.Windows.Forms.Button();
            this.btnAttendanceRecord = new System.Windows.Forms.Button();
            this.btnClubStudent = new System.Windows.Forms.Button();
            this.btnClub = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnClubSchedule = new System.Windows.Forms.Button();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnFacility = new System.Windows.Forms.Button();
            this.btnExtracurricularScholarship = new System.Windows.Forms.Button();
            this.btnExpenseType = new System.Windows.Forms.Button();
            this.btnExpeneses = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnMaterialLoan = new System.Windows.Forms.Button();
            this.TypeOfEmployee = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccreditationControl
            // 
            this.btnAccreditationControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAccreditationControl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccreditationControl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccreditationControl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccreditationControl.Location = new System.Drawing.Point(-4, -3);
            this.btnAccreditationControl.Name = "btnAccreditationControl";
            this.btnAccreditationControl.Size = new System.Drawing.Size(387, 51);
            this.btnAccreditationControl.TabIndex = 0;
            this.btnAccreditationControl.Text = "AccreditationControl";
            this.btnAccreditationControl.UseVisualStyleBackColor = false;
            this.btnAccreditationControl.Click += new System.EventHandler(this.btnAccreditationControl_Click);
            // 
            // btnAttendanceRecord
            // 
            this.btnAttendanceRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAttendanceRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAttendanceRecord.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendanceRecord.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAttendanceRecord.Location = new System.Drawing.Point(389, -3);
            this.btnAttendanceRecord.Name = "btnAttendanceRecord";
            this.btnAttendanceRecord.Size = new System.Drawing.Size(387, 51);
            this.btnAttendanceRecord.TabIndex = 1;
            this.btnAttendanceRecord.Text = "AttendanceRecord";
            this.btnAttendanceRecord.UseVisualStyleBackColor = false;
            this.btnAttendanceRecord.Click += new System.EventHandler(this.btnAttendanceRecord_Click);
            // 
            // btnClubStudent
            // 
            this.btnClubStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClubStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClubStudent.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClubStudent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClubStudent.Location = new System.Drawing.Point(389, 54);
            this.btnClubStudent.Name = "btnClubStudent";
            this.btnClubStudent.Size = new System.Drawing.Size(387, 51);
            this.btnClubStudent.TabIndex = 3;
            this.btnClubStudent.Text = "ClubStudent";
            this.btnClubStudent.UseVisualStyleBackColor = false;
            this.btnClubStudent.Click += new System.EventHandler(this.btnClubStudent_Click);
            // 
            // btnClub
            // 
            this.btnClub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClub.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClub.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClub.Location = new System.Drawing.Point(-4, 54);
            this.btnClub.Name = "btnClub";
            this.btnClub.Size = new System.Drawing.Size(387, 51);
            this.btnClub.TabIndex = 2;
            this.btnClub.Text = "Club";
            this.btnClub.UseVisualStyleBackColor = false;
            this.btnClub.Click += new System.EventHandler(this.btnClub_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployee.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEmployee.Location = new System.Drawing.Point(389, 111);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(387, 51);
            this.btnEmployee.TabIndex = 5;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnClubSchedule
            // 
            this.btnClubSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClubSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClubSchedule.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClubSchedule.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClubSchedule.Location = new System.Drawing.Point(-4, 111);
            this.btnClubSchedule.Name = "btnClubSchedule";
            this.btnClubSchedule.Size = new System.Drawing.Size(387, 51);
            this.btnClubSchedule.TabIndex = 4;
            this.btnClubSchedule.Text = "ClubSchedule";
            this.btnClubSchedule.UseVisualStyleBackColor = false;
            // 
            // btnMaterial
            // 
            this.btnMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaterial.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMaterial.Location = new System.Drawing.Point(389, 282);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(387, 51);
            this.btnMaterial.TabIndex = 11;
            this.btnMaterial.Text = "Material";
            this.btnMaterial.UseVisualStyleBackColor = false;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnFacility
            // 
            this.btnFacility.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFacility.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacility.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacility.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFacility.Location = new System.Drawing.Point(-4, 282);
            this.btnFacility.Name = "btnFacility";
            this.btnFacility.Size = new System.Drawing.Size(387, 51);
            this.btnFacility.TabIndex = 10;
            this.btnFacility.Text = "Facility";
            this.btnFacility.UseVisualStyleBackColor = false;
            this.btnFacility.Click += new System.EventHandler(this.btnFacility_Click);
            // 
            // btnExtracurricularScholarship
            // 
            this.btnExtracurricularScholarship.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExtracurricularScholarship.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtracurricularScholarship.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtracurricularScholarship.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExtracurricularScholarship.Location = new System.Drawing.Point(389, 225);
            this.btnExtracurricularScholarship.Name = "btnExtracurricularScholarship";
            this.btnExtracurricularScholarship.Size = new System.Drawing.Size(387, 51);
            this.btnExtracurricularScholarship.TabIndex = 9;
            this.btnExtracurricularScholarship.Text = "ExtraCurricularScholarship";
            this.btnExtracurricularScholarship.UseVisualStyleBackColor = false;
            this.btnExtracurricularScholarship.Click += new System.EventHandler(this.btnExtracurricularScholarship_Click);
            // 
            // btnExpenseType
            // 
            this.btnExpenseType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExpenseType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpenseType.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExpenseType.Location = new System.Drawing.Point(-4, 225);
            this.btnExpenseType.Name = "btnExpenseType";
            this.btnExpenseType.Size = new System.Drawing.Size(387, 51);
            this.btnExpenseType.TabIndex = 8;
            this.btnExpenseType.Text = "ExpenseType ";
            this.btnExpenseType.UseVisualStyleBackColor = false;
            this.btnExpenseType.Click += new System.EventHandler(this.btnExpenseType_Click);
            // 
            // btnExpeneses
            // 
            this.btnExpeneses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExpeneses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpeneses.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpeneses.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExpeneses.Location = new System.Drawing.Point(389, 168);
            this.btnExpeneses.Name = "btnExpeneses";
            this.btnExpeneses.Size = new System.Drawing.Size(387, 51);
            this.btnExpeneses.TabIndex = 7;
            this.btnExpeneses.Text = "Expenses";
            this.btnExpeneses.UseVisualStyleBackColor = false;
            this.btnExpeneses.Click += new System.EventHandler(this.btnExpeneses_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEvent.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEvent.Location = new System.Drawing.Point(-4, 168);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(387, 51);
            this.btnEvent.TabIndex = 6;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = false;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudent.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStudent.Location = new System.Drawing.Point(389, 339);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(387, 51);
            this.btnStudent.TabIndex = 13;
            this.btnStudent.Text = "MaterialType";
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnMaterialLoan
            // 
            this.btnMaterialLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMaterialLoan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaterialLoan.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialLoan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMaterialLoan.Location = new System.Drawing.Point(-4, 339);
            this.btnMaterialLoan.Name = "btnMaterialLoan";
            this.btnMaterialLoan.Size = new System.Drawing.Size(387, 51);
            this.btnMaterialLoan.TabIndex = 12;
            this.btnMaterialLoan.Text = "MaterialLoan";
            this.btnMaterialLoan.UseVisualStyleBackColor = false;
            this.btnMaterialLoan.Click += new System.EventHandler(this.btnMaterialLoan_Click);
            // 
            // TypeOfEmployee
            // 
            this.TypeOfEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TypeOfEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TypeOfEmployee.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeOfEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TypeOfEmployee.Location = new System.Drawing.Point(202, 396);
            this.TypeOfEmployee.Name = "TypeOfEmployee";
            this.TypeOfEmployee.Size = new System.Drawing.Size(387, 51);
            this.TypeOfEmployee.TabIndex = 14;
            this.TypeOfEmployee.Text = "Student";
            this.TypeOfEmployee.UseVisualStyleBackColor = false;
            this.TypeOfEmployee.Click += new System.EventHandler(this.TypeOfEmployee_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProyectoMaestroDetalle.Properties.Resources.programacion_computadora_y_lentes_8000x4521_xtrafondos_com;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // MenuOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(775, 448);
            this.Controls.Add(this.TypeOfEmployee);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnMaterialLoan);
            this.Controls.Add(this.btnMaterial);
            this.Controls.Add(this.btnFacility);
            this.Controls.Add(this.btnExtracurricularScholarship);
            this.Controls.Add(this.btnExpenseType);
            this.Controls.Add(this.btnExpeneses);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnClubSchedule);
            this.Controls.Add(this.btnClubStudent);
            this.Controls.Add(this.btnClub);
            this.Controls.Add(this.btnAttendanceRecord);
            this.Controls.Add(this.btnAccreditationControl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MenuOpciones";
            this.Text = "Menu4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAccreditationControl;
        private Button btnAttendanceRecord;
        private Button btnClubStudent;
        private Button btnClub;
        private Button btnEmployee;
        private Button btnClubSchedule;
        private Button btnMaterial;
        private Button btnFacility;
        private Button btnExtracurricularScholarship;
        private Button btnExpenseType;
        private Button btnExpeneses;
        private Button btnEvent;
        private Button btnStudent;
        private Button btnMaterialLoan;
        private Button TypeOfEmployee;
        private PictureBox pictureBox1;
    }
}