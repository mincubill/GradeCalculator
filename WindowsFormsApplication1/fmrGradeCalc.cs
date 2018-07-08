using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class frmGradeCalc : Form
    {
        private decimal grade1, grade2, grade3, grade4, grade5, grade6, grade7, val1, val2, val3, val4, val5, val6, val7 = 0;
        private decimal gradePresen, valPresen, gradeEx, valEx, gradeFinal = 0;
        private int h2, h3, h4, h5, h6, h7, ori, sep;
        public frmGradeCalc()
        {
            InitializeComponent();
            h2 = txtGrade2.Height;
            h3 = txtGrade3.Height;
            h4 = txtGrade4.Height;
            h5 = txtGrade5.Height;
            h6 = txtGrade6.Height;
            h7 = txtGrade7.Height;
            ori = this.Height;
        }
        private void frmGradeCalc_Load(object sender, EventArgs e)
        {
            txtGrade1.Text = 0.ToString();
            txtGrade2.Text = 0.ToString();
            txtGrade3.Text = 0.ToString();
            txtGrade4.Text = 0.ToString();
            txtGrade5.Text = 0.ToString();
            txtGrade6.Text = 0.ToString();
            txtGrade7.Text = 0.ToString();
            txtVal1.Text = 0.ToString();
            txtVal2.Text = 0.ToString();
            txtVal3.Text = 0.ToString();
            txtVal4.Text = 0.ToString();
            txtVal5.Text = 0.ToString();
            txtVal6.Text = 0.ToString();
            txtVal7.Text = 0.ToString();
            txtValPresen.Text = 0.ToString();
            txtValEx.Text = 0.ToString();

            cbGrades.SelectedIndex = 0;

            lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = false;
            lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = false;
            lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = false;
            lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = false;
            lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
            lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
        }
        private void cbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowControls(Convert.ToInt32(cbGrades.Text));
        }
        public void UpdateGrade()
        {
            grade1 = Convert.ToDecimal(txtGrade1.Text);
            grade2 = Convert.ToDecimal(txtGrade2.Text);
            grade3 = Convert.ToDecimal(txtGrade3.Text);
            grade4 = Convert.ToDecimal(txtGrade4.Text);
            grade5 = Convert.ToDecimal(txtGrade5.Text);
            grade6 = Convert.ToDecimal(txtGrade6.Text);
            grade7 = Convert.ToDecimal(txtGrade7.Text);
            val1 = Convert.ToDecimal(txtVal1.Text);
            val2 = Convert.ToDecimal(txtVal2.Text);
            val3 = Convert.ToDecimal(txtVal3.Text);
            val4 = Convert.ToDecimal(txtVal4.Text);
            val5 = Convert.ToDecimal(txtVal5.Text);
            val6 = Convert.ToDecimal(txtVal6.Text);
            val7 = Convert.ToDecimal(txtVal7.Text);
            //Calculo de nota de presentacion y check del total de los porcentajes
            if (CheckTotalVal() == false)
            {
                MessageBox.Show("El porcentaje total es superior o inferior a 100", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (grade1 > 7 || grade2 > 7 || grade3 > 7 || grade4 > 7 || grade5 > 7 || grade6 > 7 || grade7 > 7 || gradePresen > 7)
                {
                    grade1 /= 10;
                    grade2 /= 10;
                    grade3 /= 10;
                    grade4 /= 10;
                    grade5 /= 10;
                    grade6 /= 10;
                    grade7 /= 10;
                    gradePresen /= 10;
	                gradeEx /= 10;
                    txtGrade1.Text = grade1.ToString();
                    txtGrade2.Text = grade2.ToString();
                    txtGrade3.Text = grade3.ToString();
                    txtGrade4.Text = grade4.ToString();
                    txtGrade5.Text = grade5.ToString();
                    txtGrade6.Text = grade6.ToString();
                    txtGrade7.Text = grade7.ToString();
                }
                var grade1Total = grade1 * (val1 / 100);
                var grade2Total = grade2 * (val2 / 100);
                var grade3Total = grade3 * (val3 / 100);
                var grade4Total = grade4 * (val4 / 100);
                var grade5Total = grade5 * (val5 / 100);
                var grade6Total = grade6 * (val6 / 100);
                var grade7Total = grade7 * (val7 / 100);
                gradePresen = (grade1Total + grade2Total + grade3Total + grade4Total + grade5Total + grade6Total + grade7Total);
                txtGradePresen.Text = gradePresen.ToString();
                //Calculo de nota final
                CheckNullEmpty();
                valPresen = Convert.ToDecimal(txtValPresen.Text);
                gradeEx = Convert.ToDecimal(txtGradeEx.Text);
	            if (gradeEx > 7)
	            {
		            gradeEx /= 10;
                    txtGradeEx.Text = gradeEx.ToString();
                }
                valEx = Convert.ToDecimal(txtValEx.Text);
                gradeFinal = gradePresen * (valPresen / 100) + gradeEx * (valEx / 100);
                txtGradeFinal.Text = gradeFinal.ToString();
            }
        }
        public void CheckNullEmpty()
        {
            if (string.IsNullOrWhiteSpace(txtValPresen.Text))
            {
                txtValPresen.Text = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(txtGradeEx.Text))
            {
                txtGradeEx.Text = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(txtValEx.Text))
            {
                txtValEx.Text = 0.ToString();
            }
        }
        public bool CheckTotalVal()
        {
            var totalVal = val1 + val2 + val3 + val4 + val5 + val6 + val7;
            if (totalVal == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            UpdateGrade();
        }
        private void txtGrade1_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtGrade1.Text))
            {
                txtGrade1.Text = 0.ToString();
                txtGrade1.SelectAll();
            }
            if (Convert.ToDecimal(txtGrade1.Text) > 70)
            {
                MessageBox.Show("El valor no puede ser superior a 70", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtGrade1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        private void ShowControls(int val)
        {
            switch (val)
            {
                case 1:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = false;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = false;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = false;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = false;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
                    this.Height = ori - h7 - h6 - h5 - h4 - h3 - h2 - 35;

                    break;
                case 2:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = false;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = false;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = false;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
                    this.Height = ori - h7 - h6 - h5 - h4 - h3 - 30;
                    break;
                case 3:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = true;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = false;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = false;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
                    this.Height = ori - h7 - h6 - h5 - h4 - 25;
                    break;
                case 4:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = true;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = true;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = false;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
                    this.Height = ori - h7 - h6 - h5 - 20;
                    break;
                case 5:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = true;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = true;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = true;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = false;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
                    this.Height = ori - h7 - h6 - 15;
                    break;
                case 6:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = true;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = true;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = true;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = true;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = false;
		            this.Height = ori - h7 - 10;
                    break;
                case 7:
                    lblGrade2.Visible = lblVal2.Visible = txtGrade2.Visible = txtVal2.Visible = true;
                    lblGrade3.Visible = lblVal3.Visible = txtGrade3.Visible = txtVal3.Visible = true;
                    lblGrade4.Visible = lblVal4.Visible = txtGrade4.Visible = txtVal4.Visible = true;
                    lblGrade5.Visible = lblVal5.Visible = txtGrade5.Visible = txtVal5.Visible = true;
                    lblGrade6.Visible = lblVal6.Visible = txtGrade6.Visible = txtVal6.Visible = true;
                    lblGrade7.Visible = lblVal7.Visible = txtGrade7.Visible = txtVal7.Visible = true;
                    this.Height = ori;
                    break;
            }
        }
        private decimal SugestedGrade()
        {
            decimal sug = 0;
            decimal valEx = Convert.ToDecimal(txtValEx);
            while (gradeFinal < 4)
            {
                
            }
            return sug;
        }
    }
}
