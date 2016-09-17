using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSLA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
            //Database db = new Database();
            //db.TryOpenConnection();
            //Application.Run(new Student.Dashboard(db, "123123123"));
            //Application.Run(new Teacher.Dashboard(db, "202020"));
            //Application.Run(new Administrator.Dashboard(db, "303030"));

            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog();
            //byte[] data = File.ReadAllBytes(ofd.FileName);

            //db.InsertRecord("tbl_announcements", new string[] { "Title", "Poster", "Status" }, new string[] { "Banner", base64, "Active" });

            //db.Command.CommandText = "insert into tbl_announcements(Title, Poster, Status) values(?title, ?image, ?status);";
            //MySql.Data.MySqlClient.MySqlParameter titleparams = new MySql.Data.MySqlClient.MySqlParameter("?title", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //MySql.Data.MySqlClient.MySqlParameter imageparams = new MySql.Data.MySqlClient.MySqlParameter("?image", MySql.Data.MySqlClient.MySqlDbType.LongBlob, data.Length);
            //MySql.Data.MySqlClient.MySqlParameter statusparams = new MySql.Data.MySqlClient.MySqlParameter("?status", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //titleparams.Value = "sample";
            //imageparams.Value = data;
            //statusparams.Value = "Active";

            //db.Command.Parameters.Add(titleparams);
            //db.Command.Parameters.Add(imageparams);
            //db.Command.Parameters.Add(statusparams);
            //db.Command.ExecuteNonQuery();
            
            //Application.Run(new Administrator.Announcements(db));
        }
    }
}
