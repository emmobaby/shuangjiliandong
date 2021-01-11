using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    
public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //云台控制数据初始化
            FormData1 formData1 = new FormData1(0, 0);
            this.textBox1.Text = formData1.HPosition.ToString();
            this.textBox2.Text = formData1.VPosition.ToString();

            // 8k摄像机数据初始化
            FormData2 formData2 = new FormData2("SDR100,BT.709", 350,"1/24","120*120",false,50,"Clear","3200K","关闭");
            this.comboBox1.Text = formData2.ColorModel;
            this.comboBox2.Text = formData2.Iso.ToString();
            this.comboBox3.Text = formData2.ShutterSpeed;
            this.comboBox4.Text = formData2.FocusAreas;
            this.ucSwitch1.Checked = formData2.IsWhiteBalance;
            this.ucTrackBar1.Value = formData2.WhiteBalanceRange;
            this.textBox3.Text = formData2.WhiteBalanceRange.ToString();
            this.comboBox6.Text = formData2.NDFilter;
            this.comboBox7.Text = formData2.CCFilter;
            this.comboBox8.Text = formData2.NoiseReduction;
        }

        //
        // groupBox边框
        //
        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Black, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Black, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Black, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Black, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Black, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        //
        // 窗体加载事件
        //
        private void Form1_load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Start();
        }

        //
        // 窗体关闭事件
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Stop(); 
        }

        //
        // 定时器
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            string[] s = dt.ToString().Split(' ');
            string[] s_day = s[0].Split('/');
            string day = s_day[1] + '/' + s_day[2];
            string[] s_time = s[1].Split(':');
            string time = s_time[0] + ':' + s_time[1];
            this.toolStripLabel1.Text = day.ToString();
            this.toolStripLabel2.Text = time.ToString();
        }

        //
        // 右侧按钮
        //
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel6.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel1.Visible = false;
            this.panel3.Visible = false;
            this.panel6.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel6.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.panel6.Visible = true;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
        }

        

        /// <summary>
        /// 细节探查
        /// </summary>
        
        //
        // 收缩按钮
        //
        private void button29_Click(object sender, EventArgs e)
        {
            this.panel5.Visible = false;
            this.button29.Visible = false;
            this.button28.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height - this.panel5.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height - this.panel5.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height - this.panel5.Size.Height);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.panel5.Visible = true;
            this.button28.Visible = false;
            this.button29.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height + this.panel5.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height + this.panel5.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height + this.panel5.Size.Height);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.panel8.Visible = false;
            this.button33.Visible = false;
            this.button32.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height - this.panel8.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height - this.panel8.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height - this.panel8.Size.Height);

        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.panel8.Visible = true;
            this.button32.Visible = false;
            this.button33.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height + this.panel8.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height + this.panel8.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height + this.panel8.Size.Height);

        }

        private void button35_Click(object sender, EventArgs e)
        {
            this.panel10.Visible = true;
            this.button35.Visible = false;
            this.button36.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height + this.panel10.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height + this.panel10.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height + this.panel10.Size.Height);

        }

        private void button36_Click(object sender, EventArgs e)
        {
            this.panel10.Visible = false;
            this.button36.Visible = false;
            this.button35.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height - this.panel10.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height - this.panel10.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height - this.panel10.Size.Height);

        }

        private void button39_Click(object sender, EventArgs e)
        {
            this.panel15.Visible = true;
            this.button39.Visible = false;
            this.button40.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height + this.panel15.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height + this.panel15.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height + this.panel15.Size.Height);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            this.panel15.Visible = false;
            this.button40.Visible = false;
            this.button39.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height - this.panel15.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height - this.panel15.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height - this.panel15.Size.Height);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.panel12.Visible = true;
            this.button37.Visible = false;
            this.button38.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height + this.panel12.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height + this.panel12.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height + this.panel12.Size.Height);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.panel12.Visible = false;
            this.button38.Visible = false;
            this.button37.Visible = true;
            this.panel3.Size = new Size(this.panel3.Size.Width, this.panel3.Size.Height - this.panel12.Size.Height);
            this.groupBox6.Size = new Size(this.groupBox6.Size.Width, this.groupBox6.Size.Height - this.panel12.Size.Height);
            this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, this.flowLayoutPanel1.Size.Height - this.panel12.Size.Height);
        }

        //
        // 
        //

        /// <summary>
        /// 8k摄像机数据绑定
        /// </summary>


        //
        // 自动白平衡滑块和输入框绑定
        //
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            this.ucTrackBar1.Value = int.Parse(tb.Text.ToString());

        }

        private void ucTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            HZH_Controls.Controls.UCTrackBar uctb = (HZH_Controls.Controls.UCTrackBar)sender;

            this.textBox3.Text = uctb.Value.ToString();
        }

        /// <summary>
        /// 窗口滑动屏幕事件
        /// </summary>
        
        //
        // 点击屏幕，开始滑动事件
        //
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        //
        // 滑动事件
        //
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// 云台控制
        /// </summary>
        
        //上
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }

    /// <summary>
    /// 云台控制数据对象
    /// </summary>
    public class FormData1
    {
        private int _h_position;
        public int HPosition
        {
            get { return _h_position; }
            set { _h_position = value; }
        }

        private int _v_position;
        public int VPosition
        {
            get { return _v_position; }
            set { _v_position = value; }
        }

        public FormData1() { }
        public FormData1(int h_position, int v_position)
        {
            this.HPosition = h_position;
            this.VPosition = v_position;
        }
    }

    /// <summary>
    /// 8k摄像机数据对象
    /// </summary>
    public class FormData2
    {
        private string _color_model;
        public string ColorModel
        {
            get { return _color_model; }
            set { _color_model = value; }
        }

        private int _iso;
        public int Iso
        {
            get { return _iso; }
            set { _iso = value; }
        }

        private string _shutter_speed;
        public string ShutterSpeed
        {
            get { return _shutter_speed; }
            set { _shutter_speed = value; }
        }

        private string _focus_areas;
        public string FocusAreas
        {
            get { return _focus_areas; }
            set { _focus_areas = value; }
        }

        private bool _is_white_balance;
        public bool IsWhiteBalance
        {
            get { return _is_white_balance; }
            set { _is_white_balance = value; }
        }

        private int _white_balance_range;
        public int WhiteBalanceRange
        {
            get { return _white_balance_range; }
            set { _white_balance_range = value; }
        }

        private string _nd_filter;
        public string NDFilter
        {
            get { return _nd_filter; }
            set { _nd_filter = value; }
        }

        private string _cc_filter;
        public string CCFilter
        {
            get { return _cc_filter; }
            set { _cc_filter = value; }
        }

        private string _noise_reduction;
        public string NoiseReduction
        {
            get { return _noise_reduction; }
            set { _noise_reduction = value; }
        }

        public FormData2() { }
        public FormData2(string color_model, int iso, string shutter_speed, string focus_areas, bool is_white_balance, int white_balance_range, string nd_filte, string cc_filter, string noise_reduction)
        {
            this.ColorModel = color_model;
            this.Iso = iso;
            this.ShutterSpeed = shutter_speed;
            this.FocusAreas = focus_areas;
            this.IsWhiteBalance = is_white_balance;
            this.WhiteBalanceRange = white_balance_range;
            this.NDFilter = nd_filte;
            this.CCFilter = cc_filter;
            this.NoiseReduction = noise_reduction;
        }
    }

    
}
