using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace tubes3stima
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public byte[] GetImageFromDatabase(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ImageData FROM Images WHERE ImageID = @imageId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imageId", imageId);
                    var result = command.ExecuteScalar();
                    return result as byte[];
                }
            }
        }

        public List<(byte[], string, string)> GetImagesAndBiodata()
        {
            List<(byte[], string, string)> imagesAndBiodata = new List<(byte[], string, string)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ImageData, Biodata, Name FROM Images";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imageData = (byte[])reader["ImageData"];
                            string biodata = reader["Biodata"].ToString();
                            string name = reader["Name"].ToString();
                            imagesAndBiodata.Add((imageData, biodata, name));
                        }
                    }
                }
            }
            return imagesAndBiodata;
        }
    }
}
