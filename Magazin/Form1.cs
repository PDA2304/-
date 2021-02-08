using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class Form1 : Form
    {
        string connection = @"Data Source=DESKTOP-1CRVPTK\ISIP_D_A_PAHOMOV;Initial Catalog=Mebel;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            select();
            Empty_Text();
            dataGridView1.ClearSelection();
            dataGridView1.ReadOnly = true;
        }

        private void select()
        {
            var conect = new SqlConnection(connection);
            var sql = "SELECT dbo.Sklade.Artikul AS Артикул, dbo.Sklade.Date AS Дата, dbo.Sklade.Name_Mebel AS Название, dbo.Fabrika.Name_Fabrika AS Фабрика, dbo.Type_Mebel.Name_Type_Mebel AS [Тип мебели], dbo.Sklade.Kol_vo AS Количество, dbo.Sklade.Cost AS Стоимость FROM dbo.Sklade INNER JOIN dbo.Type_Mebel ON dbo.Sklade.Type_Mebel_ID = dbo.Type_Mebel.ID_Type_Mebel INNER JOIN dbo.Fabrika ON dbo.Sklade.Fabrika_ID = dbo.Fabrika.ID_Fabrika";
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

                sql = "select * from Fabrika";
                adapter = new SqlDataAdapter(sql, conect);
                ds = new DataSet();
                adapter.Fill(ds);

                List<fabrik> fabriks = new List<fabrik>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = ds.Tables[0].Rows[i].ItemArray;
                    fabriks.Add(new fabrik { id = (int)row[0], name = row[1].ToString() });
                }

                Name_Fabrik.DataSource = fabriks;
                Name_Fabrik.DisplayMember = "name";
                Name_Fabrik.ValueMember = "id";

                sql = "select * from Type_Mebel";
                adapter = new SqlDataAdapter(sql, conect);
                ds = new DataSet();
                adapter.Fill(ds);

                fabriks = new List<fabrik>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var row = ds.Tables[0].Rows[i].ItemArray;
                    fabriks.Add(new fabrik { id = (int)row[0], name = row[1].ToString() });
                }

                Type_Mebel.DataSource = fabriks;
                Type_Mebel.DisplayMember = "name";
                Type_Mebel.ValueMember = "id";
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

        private void Empty_Text()
        {
            Artikul.Text = "";
            Name_Mebel.Text = "";
            Cost.Text = "0";
            Kol_vo.Value = 0;
            dataGridView1.ClearSelection();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Artikul.Text != "" && Name_Mebel.Text != "" && Kol_vo.Value > 0 && Convert.ToInt32(Cost.Text) > 0)
            {
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"insert into Sklade (Artikul,Date,Name_Mebel,Kol_vo,Cost,Fabrika_ID,Type_Mebel_ID) values  ('{Artikul.Text.Trim().ToUpper()}','{date.Value.Date.ToString().Replace(" 0:00:00", "")}','{Name_Mebel.Text.Trim().ToUpper()}',{Kol_vo.Text},{Cost.Text},{Name_Fabrik.SelectedValue},{Type_Mebel.SelectedValue} )", conect);
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
                Empty_Text();
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (dataGridView1.Rows.Count != 0)
            {
                var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                try
                {
                    conect.Open();
                    var cmd = new SqlCommand($"delete from Sklade  where Artikul = '{articul}' ", conect);
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
                Empty_Text();
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            var conect = new SqlConnection(connection);
            if (Artikul.Text != "" && Name_Mebel.Text != "" && Kol_vo.Value > 0 && Convert.ToInt32(Cost.Text) > 0)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    var articul = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray[0].ToString();
                    try
                    {
                        conect.Open();
                        var cmd = new SqlCommand();
                        cmd.Connection = conect;
                        cmd.CommandText = $"update Sklade set Date = '{date.Value.Date.ToString().Replace(" 0:00:00", "")}', Name_Mebel = '{Name_Mebel.Text.Trim().ToUpper()}', Kol_vo = {Kol_vo.Text}, Cost = {Cost.Text}, Fabrika_ID = {Name_Fabrik.SelectedValue}, Type_Mebel_ID = {Type_Mebel.SelectedValue} where Artikul ='{articul}' ";
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
                    Empty_Text();
                }
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.ItemArray;
                Artikul.Text = row[0].ToString();
                date.Text = row[1].ToString();
                Name_Mebel.Text = row[2].ToString();
                for (int i = 0; i < Name_Fabrik.Items.Count; i++)
                {
                    var test = Name_Fabrik.Items[i] as fabrik;
                    var fab = row[3].ToString();
                    if (test.name == fab)
                    {
                        Name_Fabrik.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < Type_Mebel.Items.Count; i++)
                {
                    var test = Type_Mebel.Items[i] as fabrik;
                    var fab = row[4].ToString();
                    if (test.name == fab)
                    {
                        Type_Mebel.SelectedIndex = i;
                    }
                }
                Cost.Text = row[6].ToString();
                Kol_vo.Value = (int)row[5];
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Empty_Text();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var but = sender as Button;
            switch (but.Tag)
            {
                case "Фабрика":
                    {

                        break;
                    }
                case "Должность":
                    {
                        break;
                    }
                case "Тип":
                    {
                        var form = new Type_Mebel();
                        form.ShowDialog();
                        break;
                    }

            }
        }


    }
}

class fabrik
{
    public int id { get; set; }
    public string name { get; set; }
}
