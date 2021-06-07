using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NetCoreGym.Models;

namespace NetCoreGym
{
    public class membershipsHandler
    {
        const string connectionString = "server=127.0.0.1;user id=Bartosz;password=Niwobiruf_34;persistsecurityinfo=True;database=gym;allowuservariables=True";
        public static TicketInfo getMembership(int id)
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);






            //SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //// Read user
            MySqlCommand cmd = new MySqlCommand("get_ticket_info", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@in_id", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            TicketInfo ticket = new TicketInfo
            {
                name = reader.GetString(0),
                type_name = reader.GetString(1),
                end = reader.GetDateTime(2)
            };

            return ticket;
        }


    }
}
