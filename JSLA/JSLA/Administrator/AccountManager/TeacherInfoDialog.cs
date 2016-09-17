using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA.Administrator.AccountManager
{
    public partial class TeacherInfoDialog : Form
    {
        private Database _db;
        private DialogType _type;
        private string _filepath;

        public enum DialogType { Add, Edit }
        public TeacherInfoDialog(Database db, DialogType dt, string[] values)
        {
            InitializeComponent();

            _db = db;

            switch (_type = dt)
            {
                case DialogType.Add:
                    generateTeacherId();

                    cbxStatus.SelectedItem = "Active";
                    cbxStatus.Enabled = false;
                    break;
                case DialogType.Edit:
                    tbxID.ReadOnly = false;
                    tbxID.Text = values[0];
                    tbxID.ReadOnly = true;
                    tbxLastname.Text = values[1];
                    tbxFirstname.Text = values[2];
                    tbxMiddlename.Text = values[3];
                    cbxGender.SelectedItem = values[4];
                    cbxStatus.SelectedItem = values[5];

                    object[,] result = _db.ScanRecords("tbl_teacherinfo", new string[] { "Avatar" }, "_id = '" + values[0] + '\'');
                    if (result[0, 0].ToString() != "")
                    {
                        byte[] data = (byte[])result[0, 0];
                        pbxAvatar.Image = Image.FromStream(new MemoryStream(data));
                    }
                    else
                        pbxAvatar.Image = null;

                    break;
            }
        }

        private void generateTeacherId()
        {
            object[,] result = _db.ScanRecords("tbl_teacherinfo", "_id");
            Random r = new Random();
            int id = r.Next(0, 499999999);

            for (int i = 0; i < result.GetLength(0); i++)
                if (result[i, 0].ToString() == id.ToString("D10"))
                {
                    i = -1;
                    id = r.Next(0, 499999999);
                }

            tbxID.Text = "1" + id.ToString("D10");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pbxAvatar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.ToArray();

            if (_type == DialogType.Add)
            {
                Random r = new Random();
                //byte[] data = File.ReadAllBytes(_filepath);

                _db.Command.CommandText = "insert into tbl_teacherinfo values('" +
                    tbxID.Text + "', '" +
                    tbxLastname.Text + "', '" +
                    tbxFirstname.Text + "', '" +
                    tbxMiddlename.Text + "', '" +
                    cbxGender.Text + "', '" +
                    cbxStatus.Text + "', ?data)";

                MySql.Data.MySqlClient.MySqlParameter dataparam = new MySql.Data.MySqlClient.MySqlParameter("?data", MySql.Data.MySqlClient.MySqlDbType.Blob, data.Length);
                dataparam.Value = data;
                _db.Command.Parameters.Add(dataparam);
                _db.Command.ExecuteNonQuery();

                _db.InsertRecord("tbl_accounts",
                    tbxID.Text,
                    r.Next(100000, 999999).ToString(),
                    "Teacher",
                    "0",
                    tbxID.Text,
                    "true"
                    );
                
                resetText();
            }
            else
            {
                _db.Command.CommandText =
                      "update tbl_studentinfo set Lastname = '" + tbxLastname.Text
                      + "', Firstname = '" + tbxFirstname.Text
                      + "', Middlename = '" + tbxMiddlename.Text
                      + "', Gender = '" + cbxGender.Text
                      + "', Status = '" + cbxStatus.Text
                      + "', Avatar = ?data where _id = '" + tbxID.Text + '\'';

                _db.Command.Parameters.Clear();
                _db.Command.Parameters.AddWithValue("?data", data);
                _db.Command.ExecuteNonQuery();

                ((Dashboard)Parent.Parent).ShowMessageBar("Changes saved!", 3000);
                Close();
            }
        }

        private void resetText()
        {
            generateTeacherId();

            tbxLastname.ResetText();
            tbxFirstname.ResetText();
            tbxMiddlename.ResetText();
            cbxGender.SelectedItem = "";

            cbxStatus.SelectedItem = "Active";

            pbxAvatar.Image = null;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.Length > 0)
            {
                pbxAvatar.Image = Image.FromFile(openFileDialog1.FileName);
                _filepath = openFileDialog1.FileName;
                openFileDialog1.FileName = "";
            }
        }
    }
}
