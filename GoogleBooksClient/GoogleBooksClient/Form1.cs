using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace GoogleBooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";

            var http = new HttpClient();

            string json = await http.GetStringAsync(url);

            textBox2.Text = json;

            BooksResults result = JsonConvert.DeserializeObject<BooksResults>(json);

            dataGridView1.DataSource = result.items.Select(x => x.volumeInfo).ToList();
        }
    }
}
