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
    /// ShoppingCart class provides methods for adding, removing and listing items to tblCart.
    /// </summary>
    public class MusicCartRepository
    {
        private String connectString;
        private String SessionId;

        //Constructor to handle connection    
        public MusicCartRepository()
        {
            connectString = ConfigurationManager.ConnectionStrings["Music"].ToString();

            //sessionID is needed in shopping cart
            if (SessionId == null) SessionId = HttpContext.Current.Session.SessionID;
        }

        /// <summary>
        /// List items in cart for user's session.
        /// </summary>
        /// <returns>DataTable fields: ASIN, qty, title, listPrice, artists</returns>
        public List<MusicCartModel> GetAllItemsInCart()
        {
            string sql = @"select c.Asin, c.qty, d.Title, d.ListPrice, d.Artists
                from tblCart c, tblDescription d
                where c.Asin = d.ASIN
                and c.sessionId = @sessionId
                order by dateAdded";

            using (IDbConnection db = new SqlConnection(connectString))
            {
                List<MusicCartModel> cartItems = db.Query<MusicCartModel>(sql, new { SessionId }).ToList();
                return cartItems;
            }
        }

        /// <summary>
        /// Add new item to cart or increments qty if item is already in cart.
        /// </summary>
        /// <param name="ASIN"></param>
        public int AddToCart(string asin)
        {
            //Add the item to update qty if already exists.
            //Sql Upsert: Update if record exists, otherwise insert.  
            string SqlSelect = "SELECT qty from tblCart " +
                            "WHERE ASIN = @asin AND sessionID = @SessionId ";

            string SqlUpdate = "Update tblCart SET qty = (qty + 1) " +
                            "WHERE ASIN = @asin AND sessionID = @SessionId  ";

            string SqlInsert = "Insert into tblCart (sessionID, ASIN, qty, dateAdded) values " +
                            "(@sessionID, @asin, 1, @dateAdded);";

            string sql = "if exists (" + SqlSelect + ") " + SqlUpdate + " else " + SqlInsert;

            //populate model
            MusicCartModel musicCartModel = new MusicCartModel();
            musicCartModel.ASIN = asin;
            musicCartModel.SessionId = SessionId;
            musicCartModel.DateAdded = DateTime.Now;

            using (IDbConnection db = new SqlConnection(connectString))
            {
                int RecordsAffected = db.Query<Int32>(sql, musicCartModel).SingleOrDefault();
                return RecordsAffected;
            }
        }

        /// <summary>
        /// Decreases qty. by one item. Item is deleted if resulting quantity is < 1.
        /// </summary>
        /// <param name="ASIN">ASIN</param>
        public int RemoveFromCart(string ASIN)
        {
            string sqlUpdate = "Update tblCart SET qty = (qty - 1) " +
                               "WHERE ASIN = @ASIN AND sessionID = @SessionId; ";

            string sqlDelete = "Delete from tblCart " +
                               "WHERE ASIN = @ASIN AND sessionID = @SessionId AND qty < 1 ;";

            //execute both sql statements
            string sql = sqlUpdate + sqlDelete;

            MusicCartModel musicItem = new MusicCartModel();
            musicItem.ASIN = ASIN;
            musicItem.SessionId = SessionId;

            using (IDbConnection db = new SqlConnection(connectString))
            {
                int RecordsAffected = db.Query<Int32>(sql, musicItem).SingleOrDefault();
                return RecordsAffected;
            }
        }

        public int EmptyCart()
        {
            string sql = "Delete tblCart WHERE sessionID = @SessionId ";

            using (IDbConnection db = new SqlConnection(connectString))
            {
                int recordsAffected = db.Query<Int32>(sql, new { SessionId }).SingleOrDefault();
                return recordsAffected;
            }
        }

    }
}