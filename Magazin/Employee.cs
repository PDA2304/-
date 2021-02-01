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
    public partial class Employee : Form
    {
        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";
        public Employee()
        {
            InitializeComponent();
        }
        private void Empty_text()
        {
            login.Text = "";
            Password.Text = "";
            Middle_name.Text = "";
            Last_name.Text = "";
            Name.Text = "";
            dataGridView1.ClearSelection();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (login.Text != "" && Password.Text != "" && Password.Text.Length<=8 && Last_name.Text  !="" && Name.Text  != "")
            {
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"insert into Employee (Login,Password,Last_Name,Name,Middle_Name,Dolgnost_ID) values  ('{login.Text.Trim()}','{Password.Text.Trim()}','{Last_name.Text.Trim().ToUpper()}','{Name.Text.Trim().ToUpper()}','{Middle_name.Text.Trim().ToUpper()}',{Dolgnost.SelectedValue} )", conect);
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
                Empty_text();
            }
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
                    var cmd = new SqlCommand($"delete from Employee  where ID_Employee = '{articul}' ", conect);
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
                Empty_text();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (login.Text != "" && Password.Text != "" && Password.Text.Length <= 8 && Last_name.Text != "" && Name.Text != "")
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                    try
                    {
                        conect.Open();
                        var cmd = new SqlCommand();
                        cmd.Connection = conect;
                        cmd.CommandText = $"update Employee set Login = '{login.Text.Trim()}', Password = '{Password.Text.Trim()}', Last_Name = '{Last_name.Text.Trim().ToUpper()}',  Name = '{Name.Text.Trim().ToUpper()}', Middle_Name = '{Middle_name.Text.Trim().ToUpper()}', Dolgnost_ID = '{Dolgnost.SelectedValue}' where ID_Employee ='{articul}' ";
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
                    Empty_text();
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Empty_text();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            select();
            dataGridView1.ReadOnly = true;
            Empty_text();
        }

        private void select()
        {
            var conect = new SqlConnection(connection);
            string sql = "SELECT        dbo.Employee.ID_Employee AS [№], dbo.Employee.Login AS Логин, dbo.Employee.Password AS Пароль, dbo.Employee.Last_Name AS Фамилия, dbo.Employee.Name AS Имя, dbo.Employee.Middle_Name AS Очество, dbo.Dolgnost.Name_Dolgnost AS[Название должности] FROM dbo.Employee INNER JOIN dbo.Dolgnost ON dbo.Employee.Dolgnost_ID = dbo.Dolgnost.ID_Dolgnost";
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

                sql = "select * from Dolgnost";
                adapter = new SqlDataAdapter(sql, conect);
                ds = new DataSet();
                adapter.Fill(ds);

                List<Dolgnost> fabriks = new List<Dolgnost>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = ds.Tables[0].Rows[i].ItemArray;
                    fabriks.Add(new Dolgnost { id = (int)row[0], Name = row[1].ToString() });
                }

                Dolgnost.DataSource = fabriks;
                Dolgnost.DisplayMember = "Name";
                Dolgnost.ValueMember = "id";

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

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray;
                login.Text = row[1].ToString();
                Password.Text = row[2].ToString();
                Last_name.Text = row[3].ToString();
                Name.Text = row[4].ToString();
                Middle_name.Text = row[5].ToString();
                
                for (int i = 0; i < Dolgnost.Items.Count; i++)
                {
                    var test = Dolgnost.Items[i] as Dolgnost;
                    var fab = row[6].ToString();
                    if (test.Name == fab)
                    {
                        Dolgnost.SelectedIndex = i;
                    }
                }
               
            }
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

    class Dolgnost
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

}

