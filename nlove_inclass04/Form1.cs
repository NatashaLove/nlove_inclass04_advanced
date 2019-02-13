using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// lets to use Trial namespace directly (don't need to put Trial. Thing. etc..)
// can't do "using Thing /class" - only namespaces.
using Trial;
using System.IO;

namespace nlove_inclass04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //when you click on button Sub,it - it creates a new object (with #5)
        //for that in design form in event handler - choose for property click - the method below:
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //calling Thing through the namespace it belongs to - create new object thing
            Trial.Thing thing = new Trial.Thing(5);
            // thing-object; Number - property; Tostring - method
            txtText.Text = thing.Number.ToString();

            //create fileStream object with args/properties to be able to use data from a file
            //or write into / read from (print out) it
            FileStream f = new FileStream("file.text", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            // streamWriter is used to write into the file.txt
            StreamWriter s = new StreamWriter(f);

            //method to write into streamWriter object (s):
            s.WriteLine(thing.Number.ToString());

            //after the method "file.txt" must be created/updated and contain "5"

            // always close the objects: streamwriter and filestream - after being done with them
            s.Close();
            f.Close();

        }
    }
}
