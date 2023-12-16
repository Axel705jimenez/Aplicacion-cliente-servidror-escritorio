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
	public partial class MenuOpciones : Form
	{
		public MenuOpciones()
		{
			InitializeComponent();
		}



        private void btnAccreditationControl_Click(object sender, EventArgs e)
        {
            AccreditationControl p = new AccreditationControl();
            p.Show();
            this.Hide();
        }

        private void btnAttendanceRecord_Click(object sender, EventArgs e)
        {
            AttendanceRecord c = new AttendanceRecord();
            c.Show();
            this.Hide();
        }

        private void btnClub_Click(object sender, EventArgs e)
        {
            Club em = new Club();
            em.Show();
            this.Hide();
        }

        private void btnClubStudent_Click(object sender, EventArgs e)
        {
            ClubStudent cs = new ClubStudent();
            cs.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.Show();
            this.Hide();
        }

        private void btnExpeneses_Click(object sender, EventArgs e)
        {
            Expenses exp = new Expenses();
            exp.Show();
            this.Hide();
        }

        private void btnExpenseType_Click(object sender, EventArgs e)
        {
            Expensetype expt = new Expensetype();
            expt.Show();
            this.Hide();
        }

        private void btnExtracurricularScholarship_Click(object sender, EventArgs e)
        {
            ExtracurricularScholarship extra = new ExtracurricularScholarship();
            extra.Show();
            this.Hide();
        }

        private void btnFacility_Click(object sender, EventArgs e)
        {
            Facility fa = new Facility();
            fa.Show();
            this.Hide();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            Material mat = new Material();
            mat.Show();
            this.Hide();
        }

        private void btnMaterialLoan_Click(object sender, EventArgs e)
        {
            MaterialLoan mattt = new MaterialLoan();
            mattt.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            MaterialType matt = new MaterialType();
            matt.Show();
            this.Hide();
        }

        private void TypeOfEmployee_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
