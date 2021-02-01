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
    public partial class Pay : Form
    {
        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";
        public Pay()
        {
            InitializeComponent();
        }



        private void select()
        {
            var conect = new SqlConnection(connection);
            try
            {
                conect.Open();

                string sql = "SELECT ID_Pay, dbo.Employee_Pay.Artikul,  CONCAT(dbo.Sklade.Artikul, '  ',dbo.Sklade.Name_Mebel) as 'Артикул и Название', CONCAT(dbo.Employee.Last_Name,' ',dbo.Employee.Name ,' ',dbo.Employee.Middle_Name) as 'Сотрудник', dbo.Employee_Pay.Kol_vo, dbo.Employee_Pay.Cost FROM dbo.Sklade INNER JOIN dbo.Employee_Pay ON dbo.Sklade.Artikul = dbo.Employee_Pay.Artikul INNER JOIN dbo.Employee ON dbo.Employee_Pay.Epmloyee_ID = dbo.Employee.ID_Employee";
                var adapter = new SqlDataAdapter(sql, conect);
                var ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                sql = "SELECT Artikul, CONCAT(Artikul, ' ', Name_Mebel)FROM dbo.Sklade";
                adapter = new SqlDataAdapter(sql, conect);
                ds = new DataSet();
                adapter.Fill(ds);

                List<Sklade> fabriks = new List<Sklade>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = ds.Tables[0].Rows[i].ItemArray;
                    fabriks.Add(new Sklade { art = row[0].ToString(), name = row[1].ToString() });
                }

                Artikul.DataSource = fabriks;
                Artikul.DisplayMember = "name";
                Artikul.ValueMember = "art";
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
        private void Pay_Load(object sender, EventArgs e)
        {
            select();
            dataGridView1.ClearSelection();
        }


        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Artikul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Artikul.SelectedIndex != -1)
            {

                var conect = new SqlConnection(connection);
                var art = (Artikul.SelectedItem as Sklade);

                try
                {
                    conect.Open();
                    string sql = $"SELECT Cost FROM dbo.Sklade where Artikul = '{art.art}'";
                    var adapter = new SqlDataAdapter(sql, conect);
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        var row = ds.Tables[0].Rows[0].ItemArray;
                        Cost.Text = row[0].ToString();
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
        }

        private void add_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Kol_vo.Value > 0)
            {
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"insert into Employee_Pay values  ('{(Artikul.SelectedItem as Sklade).art}',{Input.save_id_employee},{Kol_vo.Value},{Kol_vo.Value * Convert.ToInt32(Cost.Text)}" + $")", conect);
                    cmd.ExecuteNonQuery();
                    select();
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
        }

        private void Pay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                    var cmd = new SqlCommand($"delete from Employee_Pay  where ID_Pay = '{articul}' ", conect);
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

        private void update_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Kol_vo.Value != 0)
            {

                if (dataGridView1.Rows.Count != 0)
                {
                    var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                    try
                    {
                        conect.Open();
                        var cmd = new SqlCommand();
                        cmd.Connection = conect;
                        cmd.CommandText = $"update Employee_Pay set Artikul = '{(Artikul.SelectedItem as Sklade).art}', Kol_vo = {Kol_vo.Value}, Cost = {Kol_vo.Value * Convert.ToInt32(Cost.Text)} where ID_Pay ='{articul}' ";
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
    }

    public class Sklade
    {
        public string art { get; set; }
        public string name { get; set; }
    }
}
