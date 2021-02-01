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
    public partial class Zarplata : Form
    {
        public Zarplata()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Convert.ToInt32(Cost.Text) > 0)
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"insert into Zarplata (Date, Employee_ID,Cost) values  ('{date.Value.Date.ToString().Replace(" 0:00:00", "")}',{Employee.SelectedValue},{Cost.Text} )", conect);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message.ToString());
                }
                finally
                {
                    conect.Close();
                }
            select();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (dataGridView1.Rows.Count != 0)
            {
                var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"delete from Zarplata  where ID_Zarplata = '{articul}' ", conect);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message.ToString());
                }
                finally
                {
                    conect.Close();
                }
                select();
                Cost.Text = "";
            }
        }



        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";

        private void select()
        {
            var conect = new SqlConnection(connection);
            string sql = "SELECT dbo.Zarplata.ID_Zarplata, CONCAT(dbo.Employee.Last_Name,' ',dbo.Employee.Name,' ', dbo.Employee.Middle_Name) as 'ФИО' , dbo.Zarplata.Date as 'Дата' ,  dbo.Zarplata.Cost as 'Зарплата'  FROM dbo.Zarplata INNER JOIN dbo.Employee ON dbo.Zarplata.Employee_ID = dbo.Employee.ID_Employee";
            try
            {
                conect.Open();
                var adapter = new SqlDataAdapter(sql, conect);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];

                sql = "select Employee.ID_Employee , CONCAT(dbo.Employee.Last_Name,' ',dbo.Employee.Name,' ', dbo.Employee.Middle_Name)  from Employee";
                adapter = new SqlDataAdapter(sql, conect);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.Columns[0].Visible = false;

                List<Emploees> fabriks = new List<Emploees>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = ds.Tables[0].Rows[i].ItemArray;
                    fabriks.Add(new Emploees { id = (int)row[0], name = row[1].ToString() });
                }

                Employee.DataSource = fabriks;
                Employee.DisplayMember = "Name";
                Employee.ValueMember = "id";

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message.ToString());
            }
            finally
            {
                conect.Close();
            }
            dataGridView1.ClearSelection();
        }

        private void Zarplata_Load(object sender, EventArgs e)
        {
            select();
        }

        private void update_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Convert.ToInt32(Cost.Text) > 0)
                if (dataGridView1.Rows.Count != 0)
                {
                    var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                    try
                    {
                        conect.Open();
                        var cmd = new SqlCommand();
                        cmd.Connection = conect;
                        cmd.CommandText = $"update Zarplata set Date = '{date.Value.Date.ToString().Replace(" 0:00:00", "")}, Cost = {Cost.Text}, Employee_ID = {Employee.SelectedValue} where ID_Zarplata ='{articul}' ";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception Error)
                    {
                        MessageBox.Show(Error.Message.ToString());
                    }
                    finally
                    {
                        conect.Close();
                    }
                    select();

                }
        }
    }

    public class Emploees
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}

