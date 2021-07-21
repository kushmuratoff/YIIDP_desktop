using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace YIIDP
{
    public partial class Form1 : Form
    {
       
        
        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            DB.db = new cSQL();
            DB.db.cSQL_init(@"Data Source=ASUS; Initial Catalog=YIIDP; Integrated Security=True");
            DB.db.Connect();
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // if(textBox1.Text=="1"&&textBox2.Text=="1")
            {
               // MessageBox.Show("Parol To'g'ri");
                button1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
               
            }
           // else { MessageBox.Show("Parol Nato'g'ri"); }
            Baza baza = new Baza();
            this.Hide();
            baza.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void registratsiyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registratsiya reg = new Registratsiya();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

       
    }
}
