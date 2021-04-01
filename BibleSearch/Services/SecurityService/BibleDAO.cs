using BibleSearch.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibleSearch.Services.SecurityService
{
    public class BibleDAO
    {

        //connection to the database
        string connectionString = "@Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // call the model, then search
        BibleModel myBible = new BibleModel();
        // Search method
        public BibleModel search(BibleModel bible)
        {

            // What we are searching for, need to confirm this
            string queryString = "SELECT * from dbo.Bible WHERE testament = @testament and book = @book and chapter = @chapter and verse = @verse";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@testament", System.Data.SqlDbType.VarChar, 50).Value = bible.Testament;
                command.Parameters.Add("@book", System.Data.SqlDbType.VarChar, 50).Value = bible.Book;
                command.Parameters.Add("@chapter", System.Data.SqlDbType.VarChar, 50).Value = bible.Chapter;
                command.Parameters.Add("@verse", System.Data.SqlDbType.VarChar, 50).Value = bible.Verse;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        myBible.Testament = reader.GetString(1);
                        myBible.Book = reader.GetString(2);
                        myBible.Chapter = reader.GetString(3);
                        myBible.Verse = reader.GetString(4);
                        myBible.Text = reader.GetString(5);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return myBible;
        }

    }
}
