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
using System.Net.Http;
using System.ComponentModel.Design;
namespace Library_Functionality
{
    public partial class Form1 : Form
    {
        string filePath = @"C:\Users\matth\source\repos\Library Functionality\Library Functionality\BookStorage.txt";
        public static List<Book> BookHolder = new List<Book>();

        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
             Book newBook = new Book();
            newBook.BookName = textBox1.Text;
            newBook.BookAuthor = textBox2.Text;
            newBook.BookRating = Double.Parse(textBox3.Text);
            newBook.BackType = textBox4.Text;

            BookHolder.Add(newBook);

            BindingSource source = new BindingSource();
            source.DataSource = BookHolder;
            dataGridView1.DataSource = source;

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{newBook.BookName},{newBook.BookAuthor},{newBook.BookRating},{newBook.BackType}");
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

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
                        
                        BookHolder.Add(loadedBook);
                    }
                }

                BindingSource source = new BindingSource();
                source.DataSource = BookHolder;
                dataGridView1.DataSource = source;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Check_Out checkout = new Check_Out();
            checkout.ShowDialog();
        }
    }
}
