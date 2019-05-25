using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class DataOperations
    {

        private string ConnectionString = "TODO";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">User name to update points</param>
        /// <param name="points">Points to add</param>
        /// <param name="incrementPoints">If true add points, if false subtract points</param>
        /// <returns></returns>
        public bool UpdateUserPoints(string userName, int points, bool incrementPoints = true)
        {
            var operater = incrementPoints == true ? "+" : "-";

            if (incrementPoints)
            {
                
            }
            using (var cn = new SqlConnection() {ConnectionString = ConnectionString})
            {
                using (var cmd = new SqlCommand() {Connection = cn})
                {


                    cmd.CommandText = "UPDATE Users " + 
                                      $"SET [No.of points] =  [No.of points] {operater} @Points " + 
                                      "WHERE [Name]=@UserName";

                    cn.Open();

                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Points", points);

                    return cmd.ExecuteNonQuery() == 1;

                }
            }
        }
    }
}
