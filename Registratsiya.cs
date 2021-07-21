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

namespace YIIDP
{
    public partial class Registratsiya : Form
    {
        public Registratsiya()
        {
            InitializeComponent();
        }
        string Rasm_nomi = "";
        string Fayl_nomi = "";

        private void Registratsiya_Load(object sender, EventArgs e)
        {
            Ish_Joyi_label.Visible = false;
            text_ish_joyi.Visible = false;
            groupBox_p_details.Enabled = false;
            groupBox1.Enabled= false;
            DataTable dt = DB.db.Query("SELECT * FROM Universities ");
            //fanlarni olish
            comboBox1_unver.DataSource = dt;
            comboBox1_unver.DisplayMember = "Name";
            comboBox1_unver.ValueMember = "Id";
           /* dt = DB.db.Query("select * from AllUsers where AllUsers.Id=(select Max(AllUsers.Id) from AllUsers) ");

            dt = DB.db.Query("select * from AllUsers where AllUsers.Id=(select Max(AllUsers.Id) from AllUsers) ");
            //fanlarni olish
            comboBox_Fish.DataSource = dt;
            comboBox_Fish.DisplayMember = "Fullname";
            comboBox_Fish.ValueMember = "Id";
            dt = DB.db.Query("select * from Regions");
            //fanlarni olish
            comboBox_viloyat.DataSource = dt;
            comboBox_viloyat.DisplayMember = "RName";
            comboBox_viloyat.ValueMember = "Id";
            dt = DB.db.Query("select * from Nationalities");
            //fanlarni olish
            comboBox_millat.DataSource = dt;
            comboBox_millat.DisplayMember = "NType";
            comboBox_millat.ValueMember = "Id";
            dt = DB.db.Query("select * from PassportDetails where PassportDetails.Id=(select Max(PassportDetails.Id) from PassportDetails) ");
            //fanlarni olish
            comboBox_ps_d.DataSource = dt;
            comboBox_ps_d.DisplayMember = "UserId";
            comboBox_ps_d.ValueMember = "Id";

            dt = DB.db.Query("select * from IdeaType");
            //fanlarni olish
            comboBox_Idea_turi.DataSource = dt;
            comboBox_Idea_turi.DisplayMember = "Typee";
            comboBox_Idea_turi.ValueMember = "Id";*/

            Rasm_nomi = "";
            Fayl_nomi = "";
                           
          }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Uqish_j_label.Visible = true;
            comboBox1_unver.Show();
            //comboBox1_unver.Visible = true;
            Kurs_label.Show();
            // Kurs_label.Visible = true;
            text_kurs.Show();
           // text_kurs.Visible = true;
            Ish_Joyi_label.Hide();
           // Ish_Joyi_label.Visible = false;
           // text_ish_joyi.Visible = false;
            text_ish_joyi.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Ish_Joyi_label.Visible = true;
            text_ish_joyi.Visible = true;
            Uqish_j_label.Visible = false;
            comboBox1_unver.Visible = false;
            Kurs_label.Visible = false;
            text_kurs.Visible = false;
        }

        private void saq_all_user_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(text_fish.TextLength==0)
                {
                    MessageBox.Show("Familya Ismingizni kiriting!!!");
                }
                //else if(text_email.TextLength==0)
                //{
                //    MessageBox.Show("E-mailingizni kiriting!!!");
                //}
                else if (text_tel.TextLength == 0)
                {
                    MessageBox.Show("Telefon nomeringizni kiriting!!!");
                }
                else
                {
                    try
                    {
                         string zapros = "";
                        if(radioButton2.Checked==true)                        
                            {
                                zapros += "insert into AllUsers (Fullname,UsTypeId,Email,Phone,Ish_joyi) values('" + Convert.ToString(text_fish.Text) + "','" + 2 + "','" + text_email.Text + "','" + text_tel.Text + "','" + text_ish_joyi.Text + "')";
                            }
                        else {
                           // MessageBox.Show(text_fish.Text);
                            int iduni=Convert.ToInt16(comboBox1_unver.SelectedValue);
                           // MessageBox.Show(iduni.ToString());//= comboBox1_unver.SelectedValue;
                            zapros += "insert into AllUsers (Fullname,UsTypeId,Email,Phone,UnId,Course) values('" + text_fish.Text+ "','" + 1 + "','" + text_email.Text + "','" + text_tel.Text + "','" + iduni + "','" + text_kurs.Text + "')";
                        }
                        if (DB.db.SetCommand(zapros) == 1)
                        {
                            MessageBox.Show("Saqlandi");
                            groupBox_p_details.Enabled = true;
                            groupBox_User.Enabled = false;
                            DataTable dt = DB.db.Query("select * from AllUsers where AllUsers.Id=(select Max(AllUsers.Id) from AllUsers) ");
                            //fanlarni olish
                            comboBox_Fish.DataSource = dt;
                            comboBox_Fish.DisplayMember = "Fullname";
                            comboBox_Fish.ValueMember = "Id";
                            dt = DB.db.Query("select * from Regions");
                            //fanlarni olish
                            comboBox_viloyat.DataSource = dt;
                            comboBox_viloyat.DisplayMember = "RName";
                            comboBox_viloyat.ValueMember = "Id";
                            dt = DB.db.Query("select * from Nationalities");
                            //fanlarni olish
                            comboBox_millat.DataSource = dt;
                            comboBox_millat.DisplayMember = "NType";
                            comboBox_millat.ValueMember = "Id";

                            Rasm_nomi = "";
                           
                          //  MessageBox.Show(comboBox_millat.SelectedIndex.ToString(), comboBox_Fish.SelectedValue.ToString());
                            //text_vil_nomi.Clear();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

      

        private void saq_passp_details_Click(object sender, EventArgs e)
        {
            try
            {
                
                try
                {
                    string zapros = "";

                    zapros += "insert into PassportDetails (UserId,Passport_Ser,Pass_Nom,Date_B,RegId,NationId,Manzil,Images) values('" + comboBox_Fish.SelectedValue + "','" + textBox_Nomer.Text + "','" + textBox_seria.Text + "','" + dateTimePicker1.Value + "','" + comboBox_viloyat.SelectedValue + "','" + comboBox_millat.SelectedValue + "','" + textBox_manzil.Text + "','" + Rasm_nomi + "')";

                    if (DB.db.SetCommand(zapros) == 1)
                    {
                        MessageBox.Show("Saqlandi");
                        DataTable dt = DB.db.Query("select * from PassportDetails where PassportDetails.Id=(select Max(PassportDetails.Id) from PassportDetails) ");
                        //fanlarni olish
                        comboBox_ps_d.DataSource = dt;
                        comboBox_ps_d.DisplayMember = "UserId";
                        comboBox_ps_d.ValueMember = "Id";

                        dt = DB.db.Query("select * from IdeaType");
                        //fanlarni olish
                        comboBox_Idea_turi.DataSource = dt;
                        comboBox_Idea_turi.DisplayMember = "Typee";
                        comboBox_Idea_turi.ValueMember = "Id";



                        groupBox_p_details.Enabled = false;
                        groupBox1.Enabled = true;
                        Rasm_nomi = "";
          
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
           
            catch
            {

            }
        }

        private void saq_Idea__Click(object sender, EventArgs e)
        {
            
                try
                {
                    DateTime vaqt = DateTime.Now;
                    string zapros = "";
                    zapros += " insert into UsersIdeas (UserPasId,IdeaTypeId,Descriptions,Vaqti,Loyha) values('" + comboBox_ps_d.SelectedValue + "','" + comboBox_Idea_turi.SelectedValue + "','" + richTextBox1.Text + "','" + vaqt + "','" + Fayl_nomi + "' )";
              // zapros += "insert into AllUsers (Fullname,UsTypeId,Email,Phone,Ish_joyi) values('" + text_fish.Text + "','" + 2 + "','" + text_email.Text + "','" + text_tel.Text + "','" + text_ish_joyi.Text + "')";
                    if(DB.db.SetCommand(zapros)==1)
                    {
                        MessageBox.Show("saqlandi");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        private void Rasm_btn_Click(object sender, EventArgs e)
        {
           // if (textBox_Nomer.Text != "" && textBox_seria.Text != "")
            {
                try
                {
                    OpenFileDialog fayl = new OpenFileDialog();
                    fayl.Filter = "jpg fayl|*.jpg|png fayl|*.png";

                    if (fayl.ShowDialog() == DialogResult.OK)
                    {

                        int k = 0;
                        for (int i = 0; i < fayl.FileName.Length; i++)
                        {
                            if (fayl.FileName[i] == '.') { k = i; }
                        }

                        Rasm_nomi = comboBox_Fish.SelectedValue.ToString() + fayl.FileName.Substring(k, fayl.FileName.Length - k);
                        string ff = "D:\\YIIDP_Baza\\Rasm\\" + Rasm_nomi;
                       // MessageBox.Show(ff);

                        File.Copy(fayl.FileName, ff, true);
                        //MessageBox.Show(ff);
                        Rasm_btn.Text = "Rasm tanlandi";
                        Rasm_nomi = ff;
                    }
                    else { Rasm_btn.Text = "Rasm tanlanmadi"; }

                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
           // else { MessageBox.Show("Ma'lumotlar to'liq kiritilmadi"); }
        }

        private void Fayl_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fayl = new OpenFileDialog();
                fayl.Filter = "word fayl|*.docx|pp fayl|*.pptx|pdf fayl|*.pdf|rasm fayl|*.jpg";

                if (fayl.ShowDialog() == DialogResult.OK)
                {

                    int k = 0;
                    for (int i = 0; i < fayl.FileName.Length; i++)
                    {
                        if (fayl.FileName[i] == '.') { k = i; }
                    }

                    Fayl_nomi = comboBox_Fish.SelectedValue.ToString() + fayl.FileName.Substring(k, fayl.FileName.Length - k);
                    string ff = "D:\\YIIDP_Baza\\Loyhasi\\" + Fayl_nomi;
                   
                    File.Copy(fayl.FileName, ff, true);
                  
                    Fayl_nomi = ff;
                    Rasm_btn.Text = "Fayl tanlandi";
                }
                else { Rasm_btn.Text = "Fayl tanlanmadi"; }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

      

    }
}
