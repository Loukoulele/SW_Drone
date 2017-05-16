namespace SwDrone
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

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
            this.Commande();
        }

        /// <summary>
        ///     The valeur catégorie moteur.
        /// </summary>
        /// <param name="t">
        ///     The t.
        /// </param>
        public void ValeurCatégorieMoteur(int t)
        {
            const string MyConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(MyConnection);
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

        /// <summary>
        ///     The ajout drone.
        /// </summary>
        private void AjoutDrone()
        {
            const string MyConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(MyConnection);

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

        /// <summary>
        ///     The button 1_ click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void Button1Click(object sender, EventArgs e)
        {
            this.AjoutDrone();
        }

        /// <summary>
        ///     The commande.
        /// </summary>
        private void Commande()
        {
            const string MyConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(MyConnection);
            myConn.Open();
            var ds = new DataSet();
            var cmd = new MySqlCommand("SELECT * FROM commande", myConn);
            var da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            this.dataGridView2.DataSource = ds.Tables[0];
            myConn.Close();
        }

        /// <summary>
        ///     The data grid view 2_ cell content click.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void DataGridView2CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dialogResult = MessageBox.Show(
                @"Voulez-vous télécharger le bon de commande en PDF ?",
                @"Telechargement PDF",
                MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // create a document object
                var doc = new Document();

                // get the current directory
                var path = Environment.CurrentDirectory;

                // get PdfWriter object
                PdfWriter.GetInstance(doc, new FileStream(path + "/pdfdoc.pdf", FileMode.Create));

                // open the document for writing
                doc.Open();
                var table = new PdfPTable(3);

                var cell = new PdfPCell(new Phrase("Bon de commande")) { Colspan = 3, HorizontalAlignment = 1 };

                // 0=Left, 1=Centre, 2=Right
                table.AddCell(cell);

                const string Connect = "datasource=localhost;port=3306;database=swd_db;username=root;password=";

                using (var conn = new MySqlConnection(Connect))
                {
                    var query = "SELECT n_commande, qte, prix FROM ligne_de_commande, produit WHERE n_commande = "
                                + this.dataGridView2.SelectedCells[0].Value;

                    var cmd = new MySqlCommand(query, conn);

                    try
                    {
                        conn.Open();

                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                table.AddCell(rdr[0].ToString());

                                table.AddCell(rdr[1].ToString());                              
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    doc.Add(table);

                    // close the document
                    doc.Close();

                    // view the result pdf file
                    Process.Start(path + "/pdfdoc.pdf");
                }
            }
        }

        /// <summary>
        ///     The listing.
        /// </summary>
        private void Listing()
        {
            const string MyConnection = "datasource=localhost;port=3306;database=swd_db;username=root;password=";
            var myConn = new MySqlConnection(MyConnection);
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