using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imdb
{
    public partial class Form1 : Form
    {
        String connectionString = "Server=127.0.0.1;Port=5432;Database=imdb;User Id=postgres;Password= '';";
        NpgsqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            panel3.Hide();
            panel4.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                if (textBox2.Text == "" && textBox3.Text == "")
                {
                    try
                    {
                        connection.Open();

                        String querry = "SELECT * FROM actor ";

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel4.Hide();
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            dataGridView2.DataSource = dt;
                            dataGridView2.BringToFront();
                            panel4.Hide();
                            panel3.Show();
                            

                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    if (textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Παρακαλώ εισάγετε όνομα και επώνυμο");
                    }
                    else
                    {
                        try
                        {
                            connection.Open();


                            String querry = "SELECT * " +
                                            "FROM actor " +
                                            "WHERE actor_first_name = '" + textBox2.Text + "' " +
                                            "AND actor_last_name = '" + textBox3.Text + "' ";

                            NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                            NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count <= 0)
                            {
                                panel4.Hide();
                                panel3.Hide();
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                MessageBox.Show("Δε βρέθηκαν εγγραφές");
                            }
                            else
                            {
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                panel4.Hide();
                                panel3.Hide();
                                dataGridView2.DataSource = dt;
                                dataGridView2.BringToFront();
                            }
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connection.Close();
                        }
                    }
                }
            }
            else if (radioButton5.Checked == true)
            {
                if (textBox2.Text == "" && textBox3.Text == "")
                {
                    try
                    {
                        connection.Open();
                        
                        String querry = "SELECT actor_first_name, actor_last_name, award_name  " +
                                        "FROM actor NATURAL JOIN actor_takes_award NATURAL JOIN award";

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            panel3.Hide();
                            dataGridView2.DataSource = dt;
                            dataGridView2.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    if (textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Παρακαλώ εισάγετε όνομα και επώνυμο");
                    }
                    else
                    {
                        try
                        {
                            connection.Open();

                            String querry = "SELECT actor_first_name, actor_last_name, award_name " +
                                            "FROM actor NATURAL JOIN actor_takes_award NATURAL JOIN award " +
                                            "WHERE actor_first_name = '" + textBox2.Text + "' " +
                                            "AND actor_last_name = '" + textBox3.Text + "' ";

                            NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                            NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count <= 0)
                            {
                                panel3.Hide();
                                panel4.Hide();
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                MessageBox.Show("Δε βρέθηκαν εγγραφές");
                            }
                            else
                            {
                                panel4.Hide();
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                panel3.Hide();
                                dataGridView2.DataSource = dt;
                                dataGridView2.BringToFront();
                            }
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connection.Close();
                        }
                    }
                }
            }
            else if(radioButton6.Checked == true)
            {
                if (textBox2.Text == "" && textBox3.Text == "")
                {
                    try
                    {
                        
                        
                        connection.Open();

                        String querry = "SELECT actor_first_name, actor_last_name, title " +
                                        "FROM actor NATURAL JOIN actor_playsin_movie NATURAL JOIN movie ";

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView2.DataSource = null;
                            dataGridView2.Refresh();
                            panel3.Hide();
                            dataGridView2.DataSource = dt;
                            dataGridView2.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    if (textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Παρακαλώ εισάγετε όνομα και επώνυμο");
                    }
                    else
                    {
                        try
                        {
                            connection.Open();

                            String querry = "SELECT actor_first_name, actor_last_name, title " +
                                            "FROM actor NATURAL JOIN actor_playsin_movie NATURAL JOIN movie " +
                                            "WHERE actor_first_name = '" + textBox2.Text + "' " +
                                            "AND actor_last_name = '" + textBox3.Text + "' ";

                            NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                            NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count <= 0)
                            {
                                panel3.Hide();
                                panel4.Hide();
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                MessageBox.Show("Δε βρέθηκαν εγγραφές");
                            }
                            else
                            {
                                panel4.Hide();
                                dataGridView2.DataSource = null;
                                dataGridView2.Refresh();
                                panel3.Hide();
                                dataGridView2.DataSource = dt;
                                dataGridView2.BringToFront();
                            }
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Δεν έχετε επιλέξει τίποτα για εμφάνιση");
            }
        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if(textBox1.Text == "")
                {
                    try
                    {
                        connection.Open();

                        String querry = "SELECT * FROM movie ";
                       
                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            panel4.Show();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    try
                    {
                        connection.Open();


                        String querry = "SELECT *" +
                                        "FROM movie " +
                                        "WHERE title = '" + textBox1.Text + "' "; 

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    try
                    {
                        connection.Open();

                        String querry = "SELECT title, director_first_name, director_last_name " +
                                        "FROM movie, director_directs_movie, director " +
                                        "WHERE movie.id_movie = director_directs_movie.id_movie AND director_directs_movie.id_director = director.id_director ";

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    try
                    {
                        connection.Open();


                        String querry = "SELECT title, director_first_name, director_last_name " +
                                        "FROM movie NATURAL JOIN director_directs_movie NATURAL JOIN director " +
                                        "WHERE title = '" + textBox1.Text + "' ";

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
            }
            else if(radioButton3.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    try
                    {
                        connection.Open();

                        String querry = "SELECT title, genre_name " +
                                        "FROM movie NATURAL JOIN movie_belongsto_genre NATURAL JOIN genre ";
                                        

                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    try
                    {
                        connection.Open();

                        String querry = "SELECT title, genre_name " +
                                        "FROM movie NATURAL JOIN movie_belongsto_genre NATURAL JOIN genre " +
                                        "WHERE title = '" + textBox1.Text + "' ";


                        NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            panel3.Hide();
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            MessageBox.Show("Δε βρέθηκαν εγγραφές");
                        }
                        else
                        {
                            panel4.Hide();
                            dataGridView1.DataSource = null;
                            dataGridView1.Refresh();
                            panel3.Hide();
                            dataGridView1.DataSource = dt;
                            dataGridView1.BringToFront();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Δεν έχετε επιλέξει τίποτα για εμφάνιση");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string querry = "UPDATE actor " +
                        "SET actor_first_name = '" + textBox4.Text + "',actor_last_name = '" + textBox5.Text + "',birth_date = '" + textBox6.Text + "'" +
                        "WHERE id_actor = '" + textBox7.Text + "' ";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                da.SelectCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Update successfull");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
               

                //update movie
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox10.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox11.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox12.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox13.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox14.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string querry = "UPDATE movie " +
                        "SET title = '" + textBox9.Text + "',movie_year = '" + textBox10.Text + "',rating = '" + textBox11.Text + "', " +
                        "abstract = '" + textBox12.Text + "',series = '" + textBox13.Text + "',run_time = '" + textBox14.Text + "'  " +
                        "WHERE id_movie = '" + textBox7.Text + "' ";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(querry, connection);
                da.SelectCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Update successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //update actor
                textBox7.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
