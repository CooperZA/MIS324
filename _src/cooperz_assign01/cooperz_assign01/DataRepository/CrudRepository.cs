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
    public class CrudRepository
    {
        private string connectionStrName = "Crud";
        private string connection;

        //constructor to handle connection
        public CrudRepository()
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

        // Get one person by PersonID (for update & details)
        public CrudModel GetOnePerson(int PersonID)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT PersonID, Fname, Lname, Birthdate 
                                    FROM tblPerson 
                                    WHERE PersonID = @PersonID";
                CrudModel person = db.Query<CrudModel>(sql, new { PersonID }).SingleOrDefault();
                return person;
            }
        }

        // Update Person
        public int UpdatePerson(CrudModel person)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"UPDATE tblPerson 
                                    SET Fname = @Fname, Lname = @Lname, Birthdate = @Birthdate 
                                    WHERE PersonID = @PersonID";
                int rowsAffected = db.Execute(sql, person);
                return rowsAffected;
            }
        }

        // Delete Person
        public int DeletePerson(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "DELETE FROM tblPerson " +
                                    "WHERE PersonID = @id";
                int rowsAffected = db.Execute(sql, new { id });
                return rowsAffected;
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