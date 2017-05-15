using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SwDrone
{
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    
    public class ListeRequete
    {
        public void AjoutDrone()
        {
            const string myConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(myConnection);
            var command = myConn.CreateCommand();
            command.CommandText = "Select nom_cat FROM categorie WHERE n_cat = 1";
            try
            {
                myConn.Open();
                var myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    //this.test.comboBox1.AutoCompleteCustomSource.Add(myReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Close();
        }
    }
}
