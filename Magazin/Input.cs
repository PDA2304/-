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
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }
        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";

       public static int save_id_employee = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);

            string sql = "select Dolgnost_ID,Login,Password,ID_Employee from Employee";
            try
            {
                conect.Open();
                var adapter = new SqlDataAdapter(sql, conect);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var rows = ds.Tables[0].Rows[i].ItemArray;
                    if (Login.Text == "Admin" && Password.Text == "Admin")
                    {
                        this.Hide();
                        Employee employee = new Employee();
                        
                        employee.Show();
                        return;
                    }
                    if (Login.Text == rows[1].ToString() && Password.Text == rows[2].ToString())
                    {
                        if ((int)rows[0] == 1)
                        {
                            this.Hide();
                            Pay pay = new Pay();
                            save_id_employee = (int)rows[3];
                            pay.Show();
                            return;
                        }
                        if ((int)rows[0] == 2)
                        {
                            this.Hide();
                            Form1 form1 = new Form1();
                            form1.Show();
                            return;
                        }
                        if ((int)rows[0] == 3)
                        {
                            this.Hide();
                            Zarplata form1 = new Zarplata();
                            form1.Show();
                            return;
                        }
                    }
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message.ToString());
            }
            finally
            {
                conect.Close();
            }

        }

        private void Input_Load(object sender, EventArgs e)
        {

        }
    }
}
