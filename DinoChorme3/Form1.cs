namespace DinoChorme3
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public Form1()
        {
            InitializeComponent();

            GameReset();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            dino1.Top += jumpSpeed;

            txtScore.Text = "Score: " + score;

            
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if(jumping == true)
            {
                jumping = false;    
            }

            if(e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();    
            }
        }
        public void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + score;
            dino1.Image = Properties.Resources.running_1_;
            dino1.Top = 362;


            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag  == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);

                    x.Left= position;  

                }


            }

            gametimer.Start(); 


        }
    }
}