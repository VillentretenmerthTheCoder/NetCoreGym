using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NetCoreGym.Models;

namespace NetCoreGym
{
    public class transactionHandler
    {
        const string connectionString = "server=127.0.0.1;user id=Bartosz;password=Niwobiruf_34;persistsecurityinfo=True;database=gym;allowuservariables=True";
        public static void callTransaction(TransactionModel transactionModel)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            long lastmember_id;
            long lastcredit_id;
            long lastpayment_id;

            //SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {

                

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "start transaction;" +
                        "insert into users(name, email, pass, role_id) " +
                        "values(@name, @email, @pass, @role_id);";

                    cmd.Parameters.AddWithValue("@name", transactionModel.Name);
                    cmd.Parameters.AddWithValue("@email", transactionModel.Email);
                    cmd.Parameters.AddWithValue("@pass", transactionModel.Pass);
                    cmd.Parameters.AddWithValue("@role_id", transactionModel.RoleId);

                    cmd.ExecuteNonQuery();

                    lastmember_id = cmd.LastInsertedId;

                    cmd.CommandText = 
                        "insert into credit_card(holder_name, exp_date)" +
                        "values(@holder_name, @exp_name);";
              

                    cmd.Parameters.AddWithValue("@holder_name", transactionModel.HolderName);
                    cmd.Parameters.AddWithValue("@exp_name", transactionModel.ExpDate);


                    cmd.ExecuteNonQuery();

                    lastcredit_id = cmd.LastInsertedId;

                    cmd.CommandText = 
                        "insert into payments(credit_id, payment_type_id)" +
                        "values(@credit_id, @payment_type_id);";

          

                    cmd.Parameters.AddWithValue("@credit_id", lastcredit_id);
                    cmd.Parameters.AddWithValue("@payment_type_id", transactionModel.PaymentTypeId);

                    cmd.ExecuteNonQuery();

                    lastpayment_id = cmd.LastInsertedId;

                    cmd.CommandText =
                        "insert into invoices(membership_id, member_id, payment_id, sold, start, end)" +
                        "values(@membership_id, @member_id, @payment_id, @sold, @start, @end); "+
                        "commit;";

                    cmd.Parameters.AddWithValue("@membership_id", transactionModel.MembershipId);
                    cmd.Parameters.AddWithValue("@member_id", lastmember_id);
                    cmd.Parameters.AddWithValue("@payment_id", lastpayment_id);
                    cmd.Parameters.AddWithValue("@sold", transactionModel.Sold);
                    cmd.Parameters.AddWithValue("@start", transactionModel.Start);
                    cmd.Parameters.AddWithValue("@end", transactionModel.End);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
