using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using cooperz_assign01.Models;
using System.Text.RegularExpressions;

namespace cooperz_assign01.DataRepository
{

    /// <summary>
    /// this class interfaces with the database. includes connection data,
    /// sql statements and methods for all CRUD actions.
    /// it is used with the Dapper object relation mapper (ORM) and CrudModel
    /// </summary>
    public class MusicRepository
    {
        private string connectionStrName = "Music";
        private string connection;

        //constructor to handle connection
        public MusicRepository()
        {
            connection = ConfigurationManager.ConnectionStrings[connectionStrName].ToString();
        }

        // add person details
        public int AddPerson(CrudModel person)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                // Dapper maps peron object to @parameters
                string sql = @"INSERT INTO tblPerson (Fname, Lname, Birthdate) 
                                    VALUES (@Fname, @Lname, @Birthdate)";
                int rowsAffected = db.Execute(sql, person);
                return rowsAffected;
            }
        }

        // Select random music title
        public List<MusicItemModel> GetRandom()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "SELECT Top 6 ASIN, Title, Artists, EditorialReviews FROM tblDescription ORDER BY NEWID();";
                List<MusicItemModel> Music = db.Query<MusicItemModel>(sql).ToList();
                return Music;
            }
        }

        // Create List of music categories
        public List<MusicStyleModel> GetMusicCategories()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "SELECT DISTINCT s.StyleName, s.StyleID FROM tblStyles s, tblStyleAsin sa WHERE s.StyleID = sa.StyleID AND ParentStyleId = 0 ORDER BY StyleName;";
                List<MusicStyleModel> music = db.Query<MusicStyleModel>(sql).ToList();
                return music;
            }
        }

        // get music by styleID
        public List<MusicItemModel> GetMusicByStyle(int styleID)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT d.ASIN, d.title, d.artists, substring(d.EditorialReviews, 0, 200) AS EditorialReviews FROM tblDescription d, tblStyleASIN sa WHERE d.ASIN = sa.ASIN AND sa.StyleID = @styleID ORDER BY d.title";

                List<MusicItemModel> music = db.Query<MusicItemModel>(sql, new { styleID }).ToList();
                return music;
            }
        }

        // to view all person details using generic list
        public List<CrudModel> GetAllPeople()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "SELECT PersonID, Fname, Lname, Birthdate FROM tblPerson";
                List<CrudModel> persons = db.Query<CrudModel>(sql).ToList();
                return persons;
            }
        }

        // Get one title by asin
        public List<MusicItemModel> GetOneTitle(string asin)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT ASIN, Title, Artists, ReleaseDate, NumberOfDiscs, Label, ListPrice, DetailPageURL, EditorialReviews
                                    FROM tblDescription 
                                    WHERE ASIN = @asin";
                List<MusicItemModel> Title = db.Query<MusicItemModel>(sql, new { asin }).ToList();
                return Title;
            }
        }

        // Search for Music
        public List<MusicItemModel> Search(string query)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT d.ASIN, d.Title, d.Artists, d.EditorialReviews, d.DetailPageURL FROM tblDescription d WHERE d.Title like @query OR d.Artists like @query";
                List<MusicItemModel> music = db.Query<MusicItemModel>(sql, new { query = "%" + query + "%" }).ToList();
                return music;
            }
        }

        // find user in database, return user information if exists 
        public List<CustomerModel> GetPersonByEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT * FROM tblCustomers WHERE Email = @email";
                List<CustomerModel> customer = db.Query<CustomerModel>(sql, new { email }).ToList();
                return customer;
            }
        }

        //update customer info
        public void UpdateCustomer(CustomerModel custModel)
        {
            string sql = @"	update tblCustomers 
                    	set email = @Email, 
                    		Fname = @FName, 
                    		Lname = @LName, 
                    		street = @Street, 
                    		city = @City, 
                    		state = @State, 
                    		zipcode = @Zipcode 
                    	 where CustId = @CustId ";

            using (IDbConnection db = new SqlConnection(connection))
            {
                db.Query<int>(sql, custModel).SingleOrDefault();
            }
        }

        public int InsertCustomer(CustomerModel custModel)
        {
            string sql = @"insert into tblCustomers (email, Fname, Lname, street, city, state, zipcode) 
                    	values (@email, @fname, @lname, @street, @city, @state, @zipcode); 
                        Select cast(Scope_Identity() as int);";

            using (IDbConnection db = new SqlConnection(connection))
            {
                int custID = db.Query<int>(sql, custModel).First();
                return custID;
            }
        }

        //Set SQL Server to Auto Close on
        //Run this once after creating db to set Auto Close on.
        //Pervents SQL Server  from locking your db.mdf file on the server.
        //In a production setting Auto Close should be off
        public string AutoClose()
        {
            // get name of db connection string
            Regex regex = new Regex("\\|.{1,15}?.mdf");
            Match match = regex.Match(connection);
            string match2 = match.ToString().Replace("|", "");
            string path = HttpContext.Current.Server.MapPath("/App_Data") + match2;
            //HttpContext.Current.Response.Write("path: " + path + "<br>");

            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "ALTER DATABASE [" + path + "] SET AUTO_CLOSE ON";
                int rowsAffected = db.Execute(sql);
                return match2;
            }
        }

    }
}