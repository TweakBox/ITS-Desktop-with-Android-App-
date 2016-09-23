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
    public partial class StudentInfoDialog : Form
    {
        private Database _db;
        private DialogType _type;
        private string _filepath;

        public enum DialogType { Add, Edit }

        public StudentInfoDialog(Database db, DialogType dt, string[] values)
        {
            InitializeComponent();

            _db = db;

            switch (_type = dt)
            {
                case DialogType.Add:
                    generateStudentId();

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
                    tbxGuardianLname.Text = values[5];
                    tbxGuardianFname.Text = values[6];
                    tbxGuardianMname.Text = values[7];
                    tbxContact.Text = values[8];
                    cbxStatus.SelectedItem = values[9];

                    object[,] result =  _db.ScanRecords("tbl_studentinfo", new string[] { "Avatar" }, "_id = '" + values[0] + '\'');
                    if (result[0, 0].ToString() != "")
                        pbxAvatar.Image = Image.FromStream(new MemoryStream((byte[])result[0, 0]));
                    else
                        pbxAvatar.Image = null;

                    break;
            }
        }

        private void generateStudentId()
        {
            object[,] result = _db.ScanRecords("tbl_studentinfo", "_id");
            Random r = new Random();
            int id = r.Next(0, 499999999);

            for (int i = 0; i < result.GetLength(0); i++)
                if (result[i, 0].ToString() == id.ToString("D10"))
                {
                    i = -1;
                    id = r.Next(0, 499999999);
                }

            tbxID.Text = "0" + id.ToString("D10");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxContact_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tbxContact.TextLength; i++)
                if (!"1234567890".Contains(tbxContact.Text[i]))
                {
                    tbxContact.Text = tbxContact.Text.Remove(i, 1);
                    tbxContact.Select(tbxContact.TextLength, 0);
                }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //byte[] data = File.ReadAllBytes(_filepath);
            MemoryStream ms = new MemoryStream();
            pbxAvatar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.ToArray();

            if (_type == DialogType.Add)
            {
                Random r = new Random();

                _db.Command.CommandText = "insert into tbl_studentinfo values('" +
                    tbxID.Text + "', '" +
                    tbxLastname.Text + "', '" +
                    tbxFirstname.Text + "', '" +
                    tbxMiddlename.Text + "', '" +
                    cbxGender.Text + "', '" +
                    tbxGuardianLname.Text + "', '" +
                    tbxGuardianFname.Text + "', '" +
                    tbxGuardianMname.Text + "', '" +
                    tbxContact.Text + "', '" +
                    cbxStatus.Text + "', ?data)";

                MySql.Data.MySqlClient.MySqlParameter dataparam = new MySql.Data.MySqlClient.MySqlParameter("?data", MySql.Data.MySqlClient.MySqlDbType.Blob, data.Length);
                dataparam.Value = data;
                _db.Command.Parameters.Add(dataparam);
                _db.Command.ExecuteNonQuery();

                _db.InsertRecord("tbl_accounts",
                    tbxID.Text,
                    r.Next(100000, 999999).ToString(),
                    "Student",
                    "0",
                    tbxID.Text,
                    "true"
                    );
                
                ((Dashboard)Parent).ShowMessageBar("Account saved!", 3000);

                resetText();
            }
            else
            {
                _db.Command.CommandText = 
                    "update tbl_studentinfo set Lastname = '" + tbxLastname.Text
                    + "', Firstname = '" + tbxFirstname.Text
                    + "', Middlename = '" + tbxMiddlename.Text 
                    + "', Gender = '" + cbxGender.Text 
                    + "', GLastname = '" + tbxGuardianLname.Text 
                    + "', GFirstname = '" + tbxGuardianFname.Text 
                    + "', GMiddlename = '" + tbxGuardianMname.Text 
                    + "', GContact = '" + tbxContact.Text 
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
            generateStudentId();

            tbxLastname.ResetText();
            tbxFirstname.ResetText();
            tbxMiddlename.ResetText();
            cbxGender.SelectedItem = "";

            tbxGuardianLname.ResetText();
            tbxGuardianFname.ResetText();
            tbxGuardianMname.ResetText();
            tbxContact.ResetText();
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
