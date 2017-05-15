namespace SwDrone
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    using MySql.Data.MySqlClient;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            for (var i = 0; i < 5; i++)
            {
                this.ValeurCatégorieMoteur(i);
            }

            this.Listing();
            this.commande();
        }

        public void ValeurCatégorieMoteur(int t)
        {
            const string myConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(myConnection);
            var command = myConn.CreateCommand();
            command.CommandText = "Select nom_cat FROM categorie WHERE n_cat = " + t;
            try
            {
                myConn.Open();
                var myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    this.comboBox1.Items.Add(myReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Close();
        }

        private void AjoutDrone()
        {
            const string myConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(myConnection);

            const string SqlString =
                @"INSERT INTO produit(ref_prod, designation, description, prix, type_multirotor, nbr_moteur, Pas_des_Helice, Poids_g_, Autonomie, n_cat)
                                 VALUES (@ref_prod, @designation, @description, @prix, @type_multirotor, @nbr_moteur, @Pas_des_Helice, @Poids_g, @Autonomie, @n_cat )";

            var cmd1 = new MySqlCommand(SqlString, myConn);
            cmd1.Parameters.AddWithValue("ref_prod", "4");
            cmd1.Parameters.AddWithValue("designation", this.textBox1.Text);
            cmd1.Parameters.AddWithValue("description", this.richTextBox1.Text);
            cmd1.Parameters.AddWithValue("prix", this.textBox2.Text);
            cmd1.Parameters.AddWithValue("type_multirotor", this.textBox3.Text);
            cmd1.Parameters.AddWithValue("nbr_moteur", this.comboBox2.Text);
            cmd1.Parameters.AddWithValue("Pas_des_Helice", this.textBox10.Text);
            cmd1.Parameters.AddWithValue("Poids_g", this.textBox6.Text);
            cmd1.Parameters.AddWithValue("Autonomie", this.textBox4.Text);
            cmd1.Parameters.AddWithValue("n_cat", this.comboBox1.SelectedIndex);
            try
            {
                myConn.Open();
                var myReader = cmd1.ExecuteReader();

                while (myReader.Read())
                {
                    this.comboBox1.Items.Add(myReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AjoutDrone();
        }

        private void commande()
        {
            const string myConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(myConnection);
            myConn.Open();
            var ds = new DataSet();
            var cmd = new MySqlCommand("SELECT * FROM commande", myConn);
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            this.dataGridView2.DataSource = ds.Tables[0];
            myConn.Close();
        }

        private void Listing()
        {
            const string myConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(myConnection);
            myConn.Open();
            var ds = new DataSet();
            var cmd = new MySqlCommand("SELECT * FROM ligne_de_commande", myConn);
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
            myConn.Close();
        }
    }
}