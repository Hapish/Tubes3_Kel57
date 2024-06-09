using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace tubes3stima
{
    public partial class Form1 : Form
    {
        private String FilePath = null;
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(@"Data Source=src\tubes3_stima24.db;Version=3;");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Implementation for label1_Click if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    this.FilePath = filePath;
                    pictureBox1.Image = Image.FromFile(filePath);
                    label1.Text = "Image Inserted";

                    SearchDatabase(pictureBox1.Image);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.BackColor = Color.Aquamarine;
                checkBox1.Text = "KMP";
                checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                checkBox1.BackColor = Color.Orchid;
                checkBox1.Text = "BM";
                checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Text == "KMP")
            {
                String searchMethod = checkBox1.Text;
                label2.Text = "Searching with " + searchMethod + "!";
            }
            else if (checkBox1.Text == "BM")    // BM method
            {
                String searchMethod = checkBox1.Text;
                label2.Text = "Searching with " + searchMethod + "!";
            }
            else
            {
                label2.Text = "Pilih metode pencarian dulu!";
            }
        }

        private void SearchDatabase(Image inputImage)
    {
        string inputAscii = ImageConverter.ConvertImageToAsciiString(inputImage);
        List<(byte[], string, string)> imagesAndBiodata = dbHelper.GetImagesAndBiodata();

        bool matchFound = false;
        string bestMatchBiodata = null;
        byte[] bestMatchImageData = null;
        int bestMatchDistance = int.MaxValue;

        foreach ((byte[] imageData, string biodata, string name) in imagesAndBiodata)
        {
            string dbAscii = ImageConverter.ConvertToAsciiString(imageData);

            if (KMPAlgorithm.KMPSearch(dbAscii, inputAscii) || BoyerMoore.BMSearch(dbAscii, inputAscii))
            {
                matchFound = true;
                bestMatchBiodata = biodata;
                bestMatchImageData = imageData;
                break;
            }
            else
            {
                int distance = LevenshteinDistanceCalculator.LevenshteinDistance(inputAscii, dbAscii);
                if (distance < bestMatchDistance)
                {
                    bestMatchDistance = distance;
                    bestMatchBiodata = biodata;
                    bestMatchImageData = imageData;
                }
            }
        }

        if (matchFound)
        {
            label2.Text = "Exact match found!";
            label6.Text = bestMatchBiodata;
            pictureBox2.Image = Image.FromStream(new MemoryStream(bestMatchImageData));
        }
        else
        {
            int matchPercentage = LevenshteinDistanceCalculator.DifferencePercentage(bestMatchDistance, inputAscii, bestMatchBiodata);
            label2.Text = $"Closest match with {matchPercentage}% similarity.";
            label6.Text = bestMatchBiodata;
            pictureBox2.Image = Image.FromStream(new MemoryStream(bestMatchImageData));
        }
    }

    }
}
