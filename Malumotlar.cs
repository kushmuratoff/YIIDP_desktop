using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
namespace YIIDP
{
    public partial class Malumotlar : Form
    {
        public Malumotlar()
        {
            InitializeComponent();
        }
        int ind = 0;
        bool wordni = false;

        private void Malumotlar_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB.db.Query("select AllUsers.Id, AllUsers.Fullname,Nationalities.NType,AllUsers.Phone,PassportDetails.Manzil,PassportDetails.Images,UsersIdeas.Descriptions,UsersIdeas.Loyha,UsersIdeas.Vaqti,IdeaType.Typee from AllUsers,UsersIdeas,PassportDetails,IdeaType,Nationalities where AllUsers.Id=PassportDetails.UserId and PassportDetails.Id=UsersIdeas.UserPasId and Nationalities.Id=PassportDetails.NationId and IdeaType.Id=UsersIdeas.IdeaTypeId");
            ind = dataGridView1.CurrentRow.Index;
            ekranga();
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ind = dataGridView1.CurrentRow.Index;
            ekranga();
           // MessageBox.Show("1");
                    }
        public void ekranga()
        {
            try
            {
                var id_update = dataGridView1.Rows[ind].Cells["Id"].Value.ToString();
             //   MessageBox.Show(id_update);

                DataTable dt = DB.db.Query("select AllUsers.Id, AllUsers.Fullname,Nationalities.NType,AllUsers.Phone,PassportDetails.Manzil,PassportDetails.Images,UsersIdeas.Descriptions,UsersIdeas.Loyha,UsersIdeas.Vaqti,IdeaType.Typee from AllUsers,UsersIdeas,PassportDetails,IdeaType,Nationalities where AllUsers.Id=PassportDetails.UserId and Nationalities.Id=PassportDetails.NationId and PassportDetails.Id=UsersIdeas.UserPasId and IdeaType.Id=UsersIdeas.IdeaTypeId and AllUsers.Id=" + id_update + "");
                pictureBox1.Image = null;
                //  text_univers.Text = dt.Rows[0]["Name"].ToString();
               // MessageBox.Show(dt.Rows[0]["Fullname"].ToString());
                if (dt.Rows[0]["Images"].ToString().Length > 0)
                {
                    Image img = Image.FromFile(dt.Rows[0]["Images"].ToString());
                    Bitmap b = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = b;

                }
                if (dt.Rows[0]["Loyha"].ToString().Length > 0 && wordni == true)
                {
                    string fayli = dt.Rows[0]["Loyha"].ToString();
                    int joyii = 0;
                    for (int i = 0; i < fayli.Length; i++)
                    {
                        if (fayli[i] == '.') { joyii = i; }
                    }
                    fayli = fayli.Substring(joyii + 1, fayli.Length - joyii - 1);
                  //  MessageBox.Show(fayli);
                    if (fayli == "pdf")
                    {

                        object objMissing = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Word._Application objWord;
                        Microsoft.Office.Interop.Word._Document objDoc;
                        objWord = new Microsoft.Office.Interop.Word.Application();
                        string ss = dt.Rows[0]["Loyha"].ToString();
                        string joyi = "D:\\Test.docx";
                        //object fileName = @"D:\Test.docx";
                        object fileName = ss;
                        // MessageBox.Show(ss);

                        //   object fileName = @joyi;
                        try
                        {
                            objDoc = objWord.Documents.Open(ref fileName,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing);
                            wordni = false;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

                    }
                    else if (fayli == "docx")
                    // MessageBox.Show(dt.Rows[0]["Loyha"].ToString());
                    {
                        object objMissing = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Word._Application objWord;
                        Microsoft.Office.Interop.Word._Document objDoc;
                        objWord = new Microsoft.Office.Interop.Word.Application();
                        string ss = dt.Rows[0]["Loyha"].ToString();
                        string joyi = "D:\\Test.docx";
                        //object fileName = @"D:\Test.docx";
                        object fileName = ss;
                        // MessageBox.Show(ss);

                        //   object fileName = @joyi;
                        try
                        {
                            objDoc = objWord.Documents.Open(ref fileName,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing);
                            wordni = false;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
                    }
                }
                //  b.Width = pictureBox1.Width;
                //img.Height = pictureBox1.Height;
                Ism.Text = dt.Rows[0]["Fullname"].ToString();
                Vaqt.Text = dt.Rows[0]["Vaqti"].ToString();
                Tel.Text = dt.Rows[0]["Phone"].ToString();
                Idea_t.Text = dt.Rows[0]["Typee"].ToString();
                richTextBox1.Text = dt.Rows[0]["Descriptions"].ToString();
                Manzil.Text = dt.Rows[0]["Manzil"].ToString();



                //update = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            wordni = true;
            ekranga();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string izlash = "";
                switch (comboBox1.SelectedIndex)
                {

                    case 0: {  izlash = "AllUsers.Fullname"; } break;
                    case 1: izlash = "IdeaType.Typee"; break;
                    case 2: izlash = "AllUsers.Phone"; break;
                    case 3: izlash = "PassportDetails.Manzil"; break;
                    case 4: izlash = "UsersIdeas.Descriptions"; break;
                    case 5: izlash = "UsersIdeas.Vaqti"; break;
                    case 6: izlash = "Nationalities.NType"; break;



                }

                dataGridView1.DataSource = DB.db.Query("select AllUsers.Id, AllUsers.Fullname,Nationalities.NType,AllUsers.Phone,PassportDetails.Manzil,PassportDetails.Images,UsersIdeas.Descriptions,UsersIdeas.Loyha,UsersIdeas.Vaqti,IdeaType.Typee from AllUsers,UsersIdeas,PassportDetails,IdeaType,Nationalities where AllUsers.Id=PassportDetails.UserId and Nationalities.Id=PassportDetails.NationId and PassportDetails.Id=UsersIdeas.UserPasId and IdeaType.Id=UsersIdeas.IdeaTypeId and " + izlash + " like '%" + textBox1.Text + "%'");
            }
            else
            {
                MessageBox.Show("Qidirish kerak bo'lgan kategoryani tanlang!!!");
                textBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==5)
            {
                label7.Visible = true;
            }
            else { label7.Visible = false; }
        }



    }
}
