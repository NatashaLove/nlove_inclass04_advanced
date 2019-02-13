using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_GUI
{
    public partial class PersonalInformation : Form
    {
        public PersonalInformation()
        {
            InitializeComponent();
        }

        public PersonalInformation(string ID)
        {
            InitializeComponent();
            txtID.Text = ID;
        }

        private void ClearFields()
        {
            if(MessageBox.Show("Are you sure you want to clear the form?", "Confirm Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtErrors.Text = "";
                txtFirstName.Text = "";
                txtMidInit.Text = "";
                txtLastName.Text = "";
                txtAge.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit this form?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtErrors.Text = "";
            bool goodForm = true;
            string id, firstName, midInit, lastName;
            int age = 0;
            StringBuilder sb = new StringBuilder();

            Person p;

            id = txtID.Text;

            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                firstName = "";
                sb.Append("First name cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                firstName = txtFirstName.Text;
            }

            midInit = (String.IsNullOrWhiteSpace(txtMidInit.Text)) ? " " : txtMidInit.Text;

            if(String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lastName = "";
                sb.Append("Last name cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                lastName = txtLastName.Text;
            }

            if(String.IsNullOrWhiteSpace(txtAge.Text))
            {
                sb.Append("Age cannot be blank.\n");
                goodForm = false;
            }
            else
            {
                if(!(Int32.TryParse(txtAge.Text, out age)))
                {
                    sb.Append("Age must be numeric.\n");
                    goodForm = false;
                }
            }

            if(goodForm)
            {
                try
                {
                    if (radStudent.Checked)
                    {
                        p = new Student(id, firstName, midInit, lastName, age);
                    }
                    else
                    {
                        p = new Employee(id, firstName, midInit, lastName, age);
                    }

                    MessageBox.Show(p.DisplayInformation());
                }
                catch (AgeBelowZeroException ex)
                {
                    txtErrors.Text = ex.Message + "\n";
                }
                catch (Exception ex)
                {
                    txtErrors.Text = ex.Message + "\n";
                }
            }
            else
            {
                txtErrors.Text = sb.ToString();
            }
        }
    }
}
