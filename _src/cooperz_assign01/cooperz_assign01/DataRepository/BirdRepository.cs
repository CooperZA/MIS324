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
    /// sql statements and methods for all Bird actions.
    /// it is used with the Dapper object relation mapper (ORM) and BirdModel
    /// </summary>
    public class BirdRepository
    {
        private string connectionStrName = "Bird";
        private string connection;

        //constructor to handle connection
        public BirdRepository()
        {
            connection = ConfigurationManager.ConnectionStrings[connectionStrName].ToString();
        }

        // add Bird details
        public int AddBird(BirdModel Bird)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                // Dapper maps peron object to @parameters
                string sql = @"INSERT INTO tblBird (Name, ImageName, Description) 
                                    VALUES (@Name, @ImageName, @Description)";
                int rowsAffected = db.Execute(sql, Bird);
                return rowsAffected;
            }
        }

        // to view all Bird details using generic list
        public List<BirdModel> GetAllBird()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "SELECT BirdID, Name, ImageName, Description FROM tblBird";
                List<BirdModel> Birds = db.Query<BirdModel>(sql).ToList();
                return Birds;
            }
        }

        // to view all Bird details using generic list
        public List<BirdModel> GetRandom()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "SELECT Top 4 Name, ImageName FROM tblBird ORDER BY NEWID();";
                List<BirdModel> Birds = db.Query<BirdModel>(sql).ToList();
                return Birds;
            }
        }

        // Get one Bird by BirdID (for update & details)
        public BirdModel GetOneBird(int BirdID)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT BirdID, Name, ImageName, Description
                                    FROM tblBird 
                                    WHERE BirdID = @BirdID";
                BirdModel Bird = db.Query<BirdModel>(sql, new { BirdID }).SingleOrDefault();
                return Bird;
            }
        }

        // Update Bird
        public int UpdateBird(BirdModel Bird)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"UPDATE tblBird 
                                    SET Name = @Name, ImageName = @ImageName, Description = @Description
                                    WHERE BirdID = @BirdID";
                int rowsAffected = db.Execute(sql, Bird);
                return rowsAffected;
            }
        }

        // Delete Bird
        public int DeleteBird(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = "DELETE FROM tblBird " +
                                    "WHERE BirdID = @id";
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