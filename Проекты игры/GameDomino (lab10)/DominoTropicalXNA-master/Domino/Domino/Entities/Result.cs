using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Xna.Framework.Graphics;

namespace Domino.Entities
{
    class Result
    {
        string _Name;
        string _Score;
        
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        public Result(string Name=null, string Score=null)
        {
            this.Name = Name;
            this.Score = Score;
        }

        string conn = @"Data Source=DESKTOP-CRGN3IK;Initial Catalog=dominogame;Integrated Security=True";

        public virtual void DataAdd()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string sqlExpression = "addresult";

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Name
                };

                command.Parameters.Add(nameParam);

                SqlParameter ageParam = new SqlParameter
                {
                    ParameterName = "@score",
                    Value = Score
                };
                command.Parameters.Add(ageParam);

                var result = command.ExecuteScalar();
            }
        }

        public List<string[]> DataSelect()
        {
            string sqlExpression = "selectresult";
            List<string[]> ResultData = new List<string[]>();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                var count = reader.FieldCount;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int score = reader.GetInt32(2);

                        ResultData.Add(new string[2]);

                        ResultData[ResultData.Count - 1][0] = reader[1].ToString();
                        ResultData[ResultData.Count - 1][1] = reader[2].ToString();

                    }
                }
                reader.Close();
                return ResultData;
            }     
        }
    }
}
