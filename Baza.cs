using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YIIDP
{
    public partial class Baza : Form
    {
        private bool update;
        private string id_update;
        int turi = 0;
        public Baza()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            groupBox1.Visible = false;
            Viloyat_gp.Visible = false;
            Idea_gp.Visible = false;
            Millatlar_gp.Visible = false;
        }

        private void universitetlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turi = 1;
            groupBox1.Visible = true;
            Viloyat_gp.Visible = false;
            Idea_gp.Visible = false;
            Millatlar_gp.Visible = false;

            dataGridView1.Visible = true;
            refresh_univer();
        }
        private void viloyatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turi = 2;
            Viloyat_gp.Visible = true;
            Idea_gp.Visible = false;
            groupBox1.Visible = false;
            Millatlar_gp.Visible = false;

            dataGridView1.Visible = true;
            refresh_viloyat();
        }
        private void goyasoxalariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turi = 3;
            dataGridView1.Visible = true;
            groupBox1.Hide();
            Idea_gp.Show();
            Viloyat_gp.Hide();
            Millatlar_gp.Hide();              
         
                        refresh_idea_t();
        }
        private void millatlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            turi = 4;
            dataGridView1.Visible = true;
            Millatlar_gp.Visible = true;
            Idea_gp.Visible = false;

            Viloyat_gp.Visible = false;

            refresh_millat();
        }
        private void foydalanuvchiMalumotlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turi = 5;
            dataGridView1.Visible = true;
            Foy_mal_g_b.Visible = true;

            Millatlar_gp.Visible = false;
            Idea_gp.Visible = false;

            Viloyat_gp.Visible = false;
            refresh_foydalanuvchi_malumot();
        }
        public void refresh_univer()
        {
            dataGridView1.DataSource = DB.db.Query("select * from Universities");
        }
        public void refresh_viloyat()
        {
            dataGridView1.DataSource = DB.db.Query("select * from Regions");
        }
        public void refresh_idea_t()
        {
            dataGridView1.DataSource = DB.db.Query("select * from IdeaType");
        }
        public void refresh_millat()
        {
            dataGridView1.DataSource = DB.db.Query("select * from Nationalities");
        }
        public void refresh_foydalanuvchi_malumot()
        {
            dataGridView1.DataSource = DB.db.Query("select PassportDetails.Id,AllUsers.Fullname,PassportDetails.Passport_Ser,PassportDetails.Pass_Nom,PassportDetails.Date_B,Regions.RName,Nationalities.NType,PassportDetails.Manzil,PassportDetails.Images from AllUsers,PassportDetails,Regions,Nationalities where AllUsers.Id=PassportDetails.UserId and Nationalities.Id=PassportDetails.NationId and Regions.Id=PassportDetails.RegId");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            switch(turi)
            {
                case 1:
                    {
                        //MessageBox.Show(turi.ToString());
                    id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
                    DataTable dt = DB.db.Query("select * from Universities where ID=" + id_update + "");
                    text_univers.Text = dt.Rows[0]["Name"].ToString();
                    update = true;
                }; break;
                case 2: {
                    //MessageBox.Show(turi.ToString());

                    id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
                    DataTable dt = DB.db.Query("select * from Regions where Id=" + id_update + "");
                    text_vil_nomi.Text = dt.Rows[0]["RName"].ToString();
                    update = true;
                }; break;
                case 3:
                    {
                        //MessageBox.Show(turi.ToString());

                        id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
                        DataTable dt = DB.db.Query("select * from IdeaType where Id=" + id_update + "");
                        text_idea_nomi.Text = dt.Rows[0]["Typee"].ToString();
                        update = true;
                    }; break;
                case 4:
                    {
                        //MessageBox.Show(turi.ToString());

                        id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
                        DataTable dt = DB.db.Query("select * from Nationalities where Id=" + id_update + "");
                        text_mill_nomi.Text = dt.Rows[0]["NType"].ToString();
                        update = true;
                    }; break;
                case 5:
                    {
                        //MessageBox.Show(turi.ToString());

                        id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
                        DataTable dt = DB.db.Query("select PassportDetails.Id,AllUsers.Fullname,PassportDetails.Passport_Ser,PassportDetails.Pass_Nom,PassportDetails.Date_B,Regions.RName,Nationalities.NType,PassportDetails.Manzil,PassportDetails.Images from AllUsers,PassportDetails,Regions,Nationalities where AllUsers.Id=PassportDetails.UserId and Nationalities.Id=PassportDetails.NationId and Regions.Id=PassportDetails.RegId and PassportDetails.Id=" + id_update + "");
                        f_m_p_s.Text = dt.Rows[0]["Pass_Nom"].ToString();
                        f_m_p_n.Text = dt.Rows[0]["Passport_Ser"].ToString();
                        f_m_t_s.Value = Convert.ToDateTime(dt.Rows[0]["Date_B"].ToString());
                        DataTable dt1 = DB.db.Query("SELECT * FROM Regions");
                        //fanlarni olish
                       // comboBox1_unver.DataSource = dt1;
                        //comboBox1_unver.DisplayMember = "Name";
                        //comboBox1_unver.ValueMember = "Id";
                       
                        f_m_vil.DataSource = dt1;
                        f_m_vil.DisplayMember = "RName";
                        f_m_vil.ValueMember = "Id";
                        
                        //f_m_vil.SelectedValue = dt.Rows[0]["RName"].ToString();
                       // f_m_vil.SelectedItem = dt.Rows[0]["RName"].ToString();
                      MessageBox.Show(dt.Rows[0]["RName"].ToString()); 
                   //     MessageBox.Show(f_m_vil.SelectedItem.ToString());
                      // f_m_vil.ValueMember = dt.Rows[0]["RName"].ToString();
                     //  f_m_vil.SelectedValue = dt.Rows[0]["RName"].ToString();

                        update = true;
                    }; break;
            }
            
        }

        private void saqlash_univers_Click(object sender, EventArgs e)
        {
            if (update)
            {
                try
                {

                    string zapros = "";
                    zapros += "update Universities set";
                    zapros += " Name= '" + text_univers.Text + "'";
                    zapros += "where ID=" + id_update;
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("o'zgartirildi");
                        update = false;
                        text_univers.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {

                    string zapros = "";
                    zapros += "insert into Universities (Name) values('" + text_univers.Text + "')";
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("qo'shildi");
                        update = false;
                        text_univers.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            } refresh_univer();
        }
        private void Saq_vil_nomi_Click(object sender, EventArgs e)
        {
            if (update)
            {
                try
                {

                    string zapros = "";
                    zapros += "update Regions set";
                    zapros += " RName= '" + text_vil_nomi.Text + "'";
                    zapros += "where Id=" + id_update;
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("o'zgartirildi");
                        update = false;
                        text_vil_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {

                    string zapros = "";
                    zapros += "insert into Regions (RName) values('" + text_vil_nomi.Text + "')";
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("qo'shildi");
                        update = false;
                        text_vil_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            } refresh_viloyat();
        }
        private void Idea_saq_btn_Click(object sender, EventArgs e)
        {
            if (update)
            {
                try
                {

                    string zapros = "";
                    zapros += "update IdeaType set";
                    zapros += " Typee= '" + text_idea_nomi.Text + "'";
                    zapros += "where Id=" + id_update;
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("o'zgartirildi");
                        update = false;
                        text_idea_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {

                    string zapros = "";
                    zapros += "insert into IdeaType (Typee) values('" + text_idea_nomi.Text + "')";
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("qo'shildi");
                        update = false;
                        text_idea_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            } refresh_idea_t();
        }
        private void saq_mill_btn_Click(object sender, EventArgs e)
        {
            if (update)
            {
                try
                {

                    string zapros = "";
                    zapros += "update Nationalities set";
                    zapros += " NType= '" + text_mill_nomi.Text + "'";
                    zapros += "where Id=" + id_update;
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("o'zgartirildi");
                        update = false;
                        text_mill_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {

                    string zapros = "";
                    zapros += "insert into Nationalities (NType) values('" + text_mill_nomi.Text + "')";
                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("qo'shildi");
                        update = false;
                        text_mill_nomi.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            } refresh_millat();
        }



        private void univers_del_btn_Click(object sender, EventArgs e)
        {
            id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString();
            string zapros = "";
            try
            {
                zapros += "delete from Universities where ID= " + id_update + "";
                if (DB.db.SetCommand(zapros) == 1)
                {
                    MessageBox.Show("O'chirildi");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            refresh_univer();
        }
        private void Del_vil_nomi_Click(object sender, EventArgs e)
        {
            id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
            string zapros = "";
            try
            {
                zapros += "delete from Regions where Id= " + id_update + "";
                if (DB.db.SetCommand(zapros) == 1)
                {
                    MessageBox.Show("O'chirildi");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            refresh_viloyat();
        }
        private void del_Idea_btn_Click(object sender, EventArgs e)
        {
            id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
            string zapros = "";
            try
            {
                zapros += "delete from IdeaType where Id= " + id_update + "";
                if (DB.db.SetCommand(zapros) == 1)
                {
                    MessageBox.Show("O'chirildi");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            refresh_idea_t();
        }
        private void del_mill_btn_Click(object sender, EventArgs e)
        {
            id_update = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString();
            string zapros = "";
            try
            {
                zapros += "delete from Nationalities where Id= " + id_update + "";
                if (DB.db.SetCommand(zapros) == 1)
                {
                    MessageBox.Show("O'chirildi");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            refresh_millat();
            
        }



        private void unvers_Qidrish_TextChanged(object sender, EventArgs e)
        {
            string nom = "Name like '%" + unvers_Qidrish.Text + "%'";
          
            dataGridView1.DataSource = DB.db.Query("select * from Universities where  " + nom + "");
        }
        private void Qidir_vil_nomi_TextChanged(object sender, EventArgs e)
        {
            string nom = "RName like '%" + Qidir_vil_nomi.Text + "%'";
          
            dataGridView1.DataSource = DB.db.Query("select * from Regions where  " + nom + "");
        }
        private void text_idea_qidr_TextChanged(object sender, EventArgs e)
        {
            string nom = "Typee like '%" + text_idea_qidr.Text + "%'";
           
            dataGridView1.DataSource = DB.db.Query("select * from IdeaType where  " + nom + "");
        }
        private void qidir_mill_nomi_TextChanged(object sender, EventArgs e)
        {
            string nom = "NType like '%" + qidir_mill_nomi.Text + "%'";
           
            dataGridView1.DataSource = DB.db.Query("select * from Nationalities where  " + nom + "");
        }

        private void malumotlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Malumotlar malumot = new Malumotlar();
            this.Hide();
            malumot.ShowDialog();
            this.Show();
        }

        private void Baza_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
        }

        private void f_m_vil_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var t in f_m_vil.Items)
            {
                MessageBox.Show(t.ToString());
            }
        }

       

       
       

       

       

       

       

       

       

       

       


    }
}
