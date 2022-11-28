using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace testNewDB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                    //connect 1
SqlCeConnection co = new SqlCeConnection();


        private void Form1_Load(object sender, EventArgs e)
        {

            //conect 2
            co.ConnectionString = "Data Source=newDB.sdf;";


            //open
co.Open();

            //add new data
string insertString = "Insert INTO utilizatori(idutilizator,nume,prenume,datanasterii,email,telefon,adresa,cnp,oras,judet,tara,continent) values (2,'maria','trif','',' ','0269234723','','','','','','')";
SqlCeCommand insert = new SqlCeCommand(insertString, co);
insert.ExecuteNonQuery();

            //read datata and write
SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM utilizatori",co);
SqlCeDataReader reader = cmd.ExecuteReader();
while(reader.Read()) { 
    //Console.WriteLine("{0} - {1}", reader.GetString(0),reader.GetString(1));
    textBox1.Text += "\r\n";
    textBox1.Text += reader.GetValue(0).ToString() + " : " + reader.GetValue(1).ToString();
    textBox1.Text += reader.GetValue(2).ToString() + " : " + reader.GetValue(3).ToString();
    textBox1.Text += reader.GetValue(4).ToString() + " : " + reader.GetValue(5).ToString();
    textBox1.Text += reader.GetValue(6).ToString() + " : " + reader.GetValue(7).ToString();
    textBox1.Text += reader.GetValue(8).ToString() + " : " + reader.GetValue(9).ToString();
    textBox1.Text += reader.GetValue(10).ToString() + " : " + reader.GetValue(11).ToString();
}
            //get nr of records

            textBox1.Text += " \r\n" + GetNumberOfRecords().ToString();
            
            //close
reader.Close();

        }

        public int GetNumberOfRecords()
{
int count = -1;
try
{ 
    //co.Open();
SqlCeCommand countall = new SqlCeCommand("select count(*) from utilizatori", co);
count = (int)countall.ExecuteScalar();
}finally
{
    //if (co!= null){co.Close();}
}
return count;
}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
