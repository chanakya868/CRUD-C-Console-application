using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=ADSKPF2CKQ4P\SQLEXPRESS;Initial Catalog=StudentCRUD;Integrated Security=True";
            
            //connection establishment

            sqlConnection = new SqlConnection(connectionString);

            //inserting new values

            sqlConnection.Open();
            Console.WriteLine("Username : ");
            string Username = Console.ReadLine();
            Console.WriteLine("Pwd :");
            string Pwd = Console.ReadLine();
            Console.WriteLine("email :");
            string email = Console.ReadLine();
            string insertQuery = "insert into Student(Username,Pwd,email) values ('"+Username+"','"+Pwd+"','"+email+"')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Data inserted");
            

            //Select or display 

            string selectQuery = "select * from Student";
            SqlCommand display = new SqlCommand(selectQuery, sqlConnection);
            SqlDataReader dataReader = display.ExecuteReader();

            while(dataReader.Read())
            {
                Console.WriteLine("username -  " + dataReader.GetValue(1).ToString());
                Console.WriteLine("email -  " + dataReader.GetValue(3).ToString());
            }
            dataReader.Close();
            //connection open

            //Update Query

            Console.WriteLine("Enter new username to update : ");
            string User = Console.ReadLine();
            string update = "update Student set name =" + User;
            SqlCommand updatequery = new SqlCommand(Username, sqlConnection);
            updatequery.ExecuteNonQuery();



            sqlConnection.Close();
            Console.ReadKey();
        }
    }
}
