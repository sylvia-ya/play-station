using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace play_station
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] p = new PictureBox[4];
        int[] nums = new int[4];
        private int count;
        private int cheat;
        private int cheatnum;
        private int cheatr;

        private void Form1_Load(object sender, EventArgs e)
        {
            p[1] = pictureBox1;
            p[2] = pictureBox2;
            p[3] = pictureBox3;
            pictureBox4.Image = new Bitmap("up.jpg");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            for (int i = 1; i <= p.GetUpperBound(0); i++)
            {
                p[i].Image = new Bitmap("0.jpg");
                p[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            label2.Text = "100";

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap("down.jpg");
            timer1.Enabled = Enabled;
            label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - numericUpDown1.Value);
            cheat += 1;
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 1; i <= p.GetUpperBound(0); i++)
            {
                nums[i] = r.Next(0, 4);// 0-3
                p[i].Image = new Bitmap(Convert.ToString(nums[i]) + ".jpg");
            }
            count += 1;
            if (count == 20)
            {
                //設計
                if (cheat % cheatnum == 0)
                {
                    nums[1] = nums[2] = nums[3];
                    p[1].Image = p[2].Image = p[3].Image;
                    cheatnum = cheatr.next(3, 5);
                }
                timer1.Enabled = false;
                pictureBox4.Image = new Bitmap("up.jpg");
                count = 0;

                if (nums[1] == 0 && nums[2] == 0 && nums[3] == 0)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 5);
                    MessageBox.Show("恭喜中獎，投注量*5");
                }
                else if (nums[1] == 1 && nums[2] == 1 && nums[3] == 1)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 10);
                    MessageBox.Show("恭喜中獎，投注量*10");
                }
                else if (nums[1] == 2 && nums[2] == 2 && nums[3] == 2)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 15);
                    MessageBox.Show("恭喜中獎，投注量*15");
                }
                else if (nums[1] == 3 && nums[2] == 2 && nums[3] == 3)
                {
                    label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + numericUpDown1.Value * 20);
                    MessageBox.Show("恭喜中獎，投注量*20");
                }
            }
        }
    }
}