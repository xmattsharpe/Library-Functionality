using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library_Functionality
{
    public partial class Check_Out : Form
    {
        string filePath = @"C:\Users\matth\source\repos\Library Functionality\Library Functionality\BookStorage.txt";

        public Check_Out()
        {
            InitializeComponent();
           
        }

        private void Check_Out_Load(object sender, EventArgs e)
        {
            List<Book> books = Form1.BookHolder;
            List<Book> newBooks = new List<Book>();

            if (File.Exists(filePath))
            {

                foreach (string line in File.ReadLines(filePath))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Book loadedBook = new Book
                        {
                            BookName = parts[0],
                            BookAuthor = parts[1],
                            BookRating = double.Parse(parts[2]),
                            BackType = parts[3]
                        };
                        newBooks.Add(loadedBook);
                        
                    }

                }
               
                BindingSource source = new BindingSource();
                source.DataSource = Form1.BookHolder;
                dataGridView1.DataSource = source;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;
            if(selectedIndex >= 0 && selectedIndex < Form1.BookHolder.Count)
            {
                RemoveBook(selectedIndex);

                BindingSource newSource = new BindingSource();
                newSource.DataSource = Form1.BookHolder;

                dataGridView1.DataSource = newSource;
            }
        }

        public void RemoveBook(int index)
        {
            if (index >= 0 && index < Form1.BookHolder.Count)
            {

              DialogResult x = MessageBox.Show($"Are you sure that you would like to check out this book?", "Check OUT", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes)
                {
                    Form1.BookHolder.RemoveAt(index);
                    MessageBox.Show("Transaction complete");
                }
            }
        }
    }
}
