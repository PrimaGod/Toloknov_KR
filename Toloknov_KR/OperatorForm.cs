using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Toloknov_KR
{
    public partial class OperatorForm : Form
    {
        static string conStr = "Data Source=10.10.1.24;Initial Catalog=Kyrsivaya_Toloknov1;Persist Security Info=True;User ID=pro-41;Password=Pro_41student";
       
        public OperatorForm()
        {
            InitializeComponent();
            //InitializeTimePicker();
        }

        //private DateTimePicker timePicker;

        //private void InitializeTimePicker()
        //{
        //    timePicker = new DateTimePicker();
        //    timePicker.Format = DateTimePickerFormat.Time;
        //    timePicker.ShowUpDown = true;
        //    timePicker.Location = new Point(10, 10);
        //    timePicker.Width = 100;
        //    Controls.Add(timePicker);
           
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }


        private void btnExitForm(object sender, EventArgs e)
        {
            this.Close();
            EnterForm newEnterForm = new EnterForm();
            newEnterForm.Show();
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
        private void OperatorForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300,250);
            o();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = (conStr);
            string sqlExpression = "INSERT INTO Problem (TimeProblem, AdressProblem, CauseProblem,ExitGroup) VALUES ('"+tbTimeProblem.Text+"','"+tbAdressProblem.Text + "','"+tbCauseProblem.Text+ "','"+tbExitGroup.Text+"')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                
            }

            o();
        }
    }
}
