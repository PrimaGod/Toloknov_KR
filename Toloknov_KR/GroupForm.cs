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

namespace Toloknov_KR
{
    public partial class GroupForm : Form
    {
        static string conStr = "Data Source=10.10.1.24;Initial Catalog=Kyrsivaya_Toloknov1;Persist Security Info=True;User ID=pro-41;Password=Pro_41student";
        public GroupForm()
        {
            InitializeComponent();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 250);
            string connectionString = (conStr);
            string sql = "SELECT * FROM Problem";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            EnterForm newEnterForm = new EnterForm();
            newEnterForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int click;
        string a;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            click = dataGridView1.CurrentCell.RowIndex;
            a = dataGridView1.Rows[click].Cells[0].Value.ToString();
            tbid.Text = a;

            string b = dataGridView1.Rows[click].Cells[4].Value.ToString();
            textBox2.Text = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = (conStr);
            string sqlExpression = "UPDATE Problem SET TimeAccept = GETDATE() WHERE id_problem = "+ a +"";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();

            }
            o();

      
       }

        void o()
        {
            string connectionString = (conStr);
            string sql = "SELECT * FROM Problem";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }



    }

}
