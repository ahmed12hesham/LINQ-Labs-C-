using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab3
{
    public partial class Form1 : Form
    {
        Model1 Ent = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

           foreach(department dpt in Ent.departments)
            {
                comboBox1.Items.Add(dpt.id.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);
            department dept = (
                                from d in Ent.departments
                                where d.id == ID
                                select d).First();
            textBox1.Text = dept.id.ToString();
            textBox2.Text = dept.name;
            comboBox2.Items.Clear();

            foreach (worker emp in dept.empolyees)
            {
                comboBox2.Items.Add(emp.id);
            }
           /* var Emp = from em in Ent.empolyees
                      where em.id == ID
                      select em;

            foreach(worker m in Emp)
            {
                comboBox2.Items.Add(m.id);
            }*/
            textBox3.Text = textBox4.Text = comboBox2.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox2.Text);
            worker emp = Ent.empolyees.Find(ID);
            textBox3.Text = emp.id.ToString();
            textBox4.Text = emp.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            department Dept = new department();
            try
            { 
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    department dpt = Ent.departments.Find(int.Parse(textBox1.Text));
                    if (dpt == null)
                    {
                        Dept.id = int.Parse(textBox1.Text);
                        Dept.name = textBox2.Text;
                        Ent.departments.Add(Dept);
                        Ent.SaveChanges();
                        comboBox1.Items.Add(textBox1.Text);
                        textBox1.Text = textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("DEpartment is available !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            department Dept = Ent.departments.Find(int.Parse(textBox1.Text));
            if (Dept != null)
            {
                Dept.name = textBox2.Text;
                Ent.SaveChanges();
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Not Available Department !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            department Dept = Ent.departments.Find(int.Parse(textBox1.Text));
            if (Dept != null)
            {
                /*foreach(worker w in Dept.empolyees)
                {
                    Ent.empolyees.Remove(w);
                }*/
                Ent.SaveChanges();
                Ent.departments.Remove(Dept);

                Ent.SaveChanges();
                foreach(worker emp in Ent.empolyees)
                {
                    if(emp.deptid == null)
                    {
                        Ent.empolyees.Remove(emp);
                        comboBox2.Items.Remove(emp.id);
                    }
                }
            }
            else
            {
                MessageBox.Show("Not Available Department !");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            worker Emp = new worker();
            department Dept = Ent.departments.Find(int.Parse(textBox1.Text));
            
            if (Dept != null)
            {
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    worker Availableworker = Ent.empolyees.Find(int.Parse(textBox3.Text));
                    if (Availableworker == null)
                    {
                        Emp.id = int.Parse(textBox3.Text);
                        Emp.name = textBox4.Text;
                        Emp.deptid = int.Parse(textBox1.Text);
                        Ent.empolyees.Add(Emp);
                        Ent.SaveChanges();
                        textBox3.Text = textBox4.Text = "";
                        comboBox2.Items.Add(textBox3.Text);
                    }
                    else
                    {
                        MessageBox.Show("Employee Exit !");
                    }
                }
                else
                {
                    MessageBox.Show("Empty Employee Data");
                }
            }
            else
            {
                MessageBox.Show("DEpartment is available !");
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            worker Emp = Ent.empolyees.Find(int.Parse(textBox3.Text));
            if(Emp != null)
            {
                Emp.name = textBox4.Text;
                Ent.SaveChanges();
                textBox3.Text = textBox4.Text ="";
            }
            else
            {
                MessageBox.Show("not available employee");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            worker Emp = Ent.empolyees.Find(int.Parse(textBox3.Text));
            if (Emp != null)
            {
                Ent.empolyees.Remove(Emp);
                Ent.SaveChanges();
                comboBox2.Items.Remove(textBox3.Text);
                textBox3.Text = textBox4.Text = "";
            }
        }
    }
}
