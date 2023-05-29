using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string path = "ElectronicArchive.xml";
        List<PaperWork> final = new List<PaperWork>();
        public Form1()
        {
            
            InitializeComponent();
            GetAllPaperworks();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            PaperWork _paperwork = OurPaperwork();
            if (LINQ.Checked)
            {
                IStrategy CurrentStrategy = new Linq(path);
                final = CurrentStrategy.Algorithm(_paperwork, path);
                Output(final);
            }
            
            if (SAX.Checked)
            {
                IStrategy CurrentStrategy = new Sax(path);
                final = CurrentStrategy.Algorithm(_paperwork, path);
                Output(final);
            }
        }
        private PaperWork OurPaperwork()
        {
            List<string> info = new List<string> { null, null, null, null, null, null };
            if (CourseCheckBox.Checked) info[0] = Convert.ToString(CourseBox.Text);
            if (GroupCheckBox.Checked) info[1] = Convert.ToString(GroupBox.Text);
            if (AuditoryCheckBox.Checked) info[2] = Convert.ToString(AuditoryBox.Text);
            if (SurnameCheckBox.Checked) info[3] = Convert.ToString(SurnameBox.Text);
            if (NameCheckBox.Checked) info[4] = Convert.ToString(NameBox.Text);
            if (PhoneNumberCheckBox.Checked) info[5] = Convert.ToString(PhoneNumberBox.Text);
            PaperWork IdealPaperwork = new PaperWork(info);
            return IdealPaperwork;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            CourseCheckBox.Checked = false;
            GroupCheckBox.Checked = false;
            SurnameCheckBox.Checked = false;
            NameCheckBox.Checked = false;
            AuditoryCheckBox.Checked = false;
            PhoneNumberCheckBox.Checked = false;
            CourseBox.Text = null;
            GroupBox.Text = null;
            SurnameBox.Text = null;
            AuditoryBox.Text = null;
            NameBox.Text = null;
            PhoneNumberBox.Text = null;
        }

        void Output(List <PaperWork> final)
        {
            int i = 1;
            
            foreach (PaperWork student  in final)
            {
                richTextBox1.AppendText("~~~~~~~~~~~~( " + i++ + " )~~~~~~~~~~~~" + "\n");
                richTextBox1.AppendText("Course: " + student.Course + "\n");
                richTextBox1.AppendText("Group: " + student.Group + "\n");
                richTextBox1.AppendText("Auditory: " + student.Auditory + "\n");
                richTextBox1.AppendText("Surname: " + student.Surname + "\n");
                richTextBox1.AppendText("Name: " + student.Name + "\n");
                richTextBox1.AppendText("PhoneNumber: " + student.PhoneNumber + "\n");
               // richTextBox1.AppendText("---------------------------\n");


            }
        }
        public void GetAllPaperworks()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ElectronicArchive.xml");
            XmlNodeList elem = doc.SelectNodes("//speciality");
            foreach(XmlNode e in elem)
            {
                XmlNodeList list1 = e.ChildNodes;
                foreach (XmlNode el in list1)
                {
                    XmlNodeList list2 = el.ChildNodes;
                    foreach (XmlNode ell in list2)
                    {
                        string course = ell.ParentNode.ParentNode.Attributes.GetNamedItem("COURSE").Value;
                        if (!CourseBox.Items.Contains(course))
                            CourseBox.Items.Add(course);
                        string group = ell.ParentNode.Attributes.GetNamedItem("GROUP").Value;
                        if (!GroupBox.Items.Contains(group))
                            GroupBox.Items.Add(group);
                        string room = ell.Attributes.GetNamedItem("AUDITORY").Value;
                        if (!AuditoryBox.Items.Contains(room))
                            AuditoryBox.Items.Add(room);
                        string surname = ell.Attributes.GetNamedItem("SURNAME").Value;
                        if (!SurnameBox.Items.Contains(surname))
                            SurnameBox.Items.Add(surname);
                        string name = ell.Attributes.GetNamedItem("NAME").Value;
                        if (!NameBox.Items.Contains(name))
                            NameBox.Items.Add(name);
                        string phonenumber = ell.Attributes.GetNamedItem("PHONENUMBER").Value;
                        if (!PhoneNumberBox.Items.Contains(phonenumber))
                            PhoneNumberBox.Items.Add(phonenumber);
                        /*
                        GroupBox1.Items.Add(ell.ParentNode.Attributes.GetNamedItem("TYPE").Value);
                        DateOfCreationBox.Items.Add(ell.Attributes.GetNamedItem("DATEOFCREATION").Value);
                        SurnameBox.Items.Add(ell.Attributes.GetNamedItem("NAME").Value);
                        NameBox.Items.Add(ell.Attributes.GetNamedItem("AUTHOR").Value);
                        PhoneBox.Items.Add(ell.Attributes.GetNamedItem("AMOUNT").Value);
                        */

                    }
                }
            }
        }

        private void TransformToHTML_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("TransformationFile.xslt");
            string input = @"ElectronicArchive.xml";
            string output = @"information.html";
            xslt.Transform(input, output);
        }

        private void PhoneNumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
