using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NC_HSP.Models
{
    public class PostsDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string defaultstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(defaultstring);
        }

        // *** Insert Post ***
        public bool PostItem(PostsViewModels iPost)
        {
            connection();
            string query = "INSERT INTO Posts VALUES('" + iPost.CreationDate + "','" + iPost.Title + "','" + iPost.BodyText + "'," + iPost.MediaUrl + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // *** Get Post ***
        public List<PostsViewModels> GetPostItem()
        {
            connection();
            List<PostsViewModels> iPost = new List<PostsViewModels>();

            string query = "SELECT * FROM Posts";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iPost.Add(new PostsViewModels
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Title = Convert.ToString(dr["Title"]),
                    CreationDate = Convert.ToDateTime(dr["CreateDate"]),
                    BodyText = Convert.ToString(dr["BodyText"]),
                    MediaUrl = Convert.ToString(dr["MediaUrl"])
                });
            }
            return iPost;
        }

        // *** Update Post ***
        public bool UpdateItem(PostsViewModels iPost)
        {
            connection();
            string query = "UPDATE Posts SET Title = '" + iPost.Title + "', CreationDate = '" + iPost.CreationDate + "', BodyText = " + iPost.BodyText + "', MediaUrl = " + iPost.MediaUrl + " WHERE Id = " + iPost.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // *** Delete Item ***
        public bool DeletePostItem(int id)
        {
            connection();
            string query = "DELETE FROM ItemList WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}