using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {
            var connect = new SqlConnection(connection);

            try
            {
                connect.Open();
                var con = new SqlDataAdapter("SELECT        Name_Dolgnost FROM            dbo.Dolgnost", connection);
                var ds = new DataSet();
                con.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {

            }
            finally
            {
                connect.Close();
            }
        }
    }
}
