namespace tubes3stima
{
    public partial class Form1 : Form
    {
        //attributes
        private String FilePath = null;

        //methods
        String getFilePath() 
        { 
            if (this.FilePath != null)
            {
                return this.FilePath;
            } else
            {
                return "null";
            }
             
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    this.FilePath = filePath;

                    // Load the image
                    pictureBox1.Image = Image.FromFile(filePath);
                    label1.Text = "Image Inserted" + pictureBox1.Image;
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
    }
}
