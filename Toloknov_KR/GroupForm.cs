﻿using System;
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
