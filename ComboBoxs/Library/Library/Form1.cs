using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Library
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=USER\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
        public Form1()
        {
            InitializeComponent();
            FillComboBoxs();
        }
        public void FillComboBoxs()
        {
            //As we have 2 lists,we should place then by index.It means query and combobox should have the same name


            List<ComboBox> cmbs = new List<ComboBox>() {cmbAuthor,cmbCategory };
            List<string> querys = new List<string>() { "Author", "Category" };
            for(var i = 0; i < querys.Count; i++)
            {
                con.Open();
                string query = "Select * From "+ querys[i];
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmbs[i].Items.Add(reader.GetInt32(0) + "-" + reader.GetString(1));
                }
                con.Close();
            }
        }
    }
}
