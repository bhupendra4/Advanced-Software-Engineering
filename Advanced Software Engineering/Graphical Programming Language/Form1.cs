using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pnlShow.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2;
        Color paintcolor = Color.Blue;

        Brush dd = new SolidBrush(Color.Red);
        int textusrestyle = 5;

        Factory shapeFactory = new Factory();
        Shape shapes;

        bool startPaint = false;
        int? initX = null;
        int? initY = null;

        public int _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10, _size11, _size12;

        private void pnlShow_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            initX = null;
            initY = null;
        }

        private void pnlShow_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
        }

        private void pnlShow_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Text = (e.X).ToString();
            label6.Text = (e.Y).ToString();
        }

        int texturestyle = 5;
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_runs_Click(object sender, EventArgs e)
        {
            Regex regex6 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) rectangle (.*[\d])([,])(.*[\d])");
            Regex regex7 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) circle (.*[\d])");
            Regex regex8 = new Regex(@"drawto (.*[\d])([,])(.*[\d]) triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");


            Regex regexClear = new Regex(@"clear");
            Regex regexReset = new Regex(@"reset");
            Regex regexMT = new Regex(@"moveto (.*[\d])([,])(.*[\d])");

            Regex regexA = new Regex(@"rectangle (.*[\d])([,])(.*[\d])");
            Regex regexB = new Regex(@"circle (.*[\d])");
            Regex regexC = new Regex(@"triangle (.*[\d])([,])(.*[\d])([,])(.*[\d])");



            Match match2 = regex6.Match(richTextBox1.Text.ToLower());
            Match match3 = regex7.Match(richTextBox1.Text.ToLower());
            Match match4 = regex8.Match(richTextBox1.Text.ToLower());

            Match matchClear = regexClear.Match(richTextBox1.Text.ToLower());
            Match matchReset = regexReset.Match(richTextBox1.Text.ToLower());
            Match matchMT = regexMT.Match(richTextBox1.Text.ToLower());

            Match matchR = regexA.Match(richTextBox1.Text.ToLower());
            Match matchC = regexB.Match(richTextBox1.Text.ToLower());
            Match matchT = regexC.Match(richTextBox1.Text.ToLower());


            if (match2.Success || match3.Success || match4.Success || matchClear.Success || matchReset.Success ||
                matchMT.Success || matchR.Success || matchC.Success || matchT.Success)
            {

                //----------------RECTANGLE WITH DrawTo-----------------------//
                if (match2.Success)
                {
                    try
                    {
                        g = pnlShow.CreateGraphics();
                        _size1 = int.Parse(match2.Groups[1].Value);
                        _size2 = int.Parse(match2.Groups[3].Value);
                        _size3 = int.Parse(match2.Groups[4].Value);
                        _size4 = int.Parse(match2.Groups[6].Value);



                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("rectangle");

                        c.set(texturestyle, dd, paintcolor, _size1, _size2, _size3, _size4);
                        c.Draw(g);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

                //----------------RECTANGLE-----------------------//

                else if (matchR.Success)
                {
                    try
                    {
                        g = pnlShow.CreateGraphics();
                        _size1 = int.Parse(label5.Text);
                        _size2 = int.Parse(label6.Text);
                        _size3 = int.Parse(matchR.Groups[1].Value);
                        _size4 = int.Parse(matchR.Groups[3].Value);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("rectangle");
                        c.set(texturestyle, dd, paintcolor, _size1, _size2, _size3, _size4);

                        c.Draw(g);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

                //----------------CIRCLE-----------------------//
                else if (matchC.Success)
                {
                    try
                    {
                        g = pnlShow.CreateGraphics();
                        _size1 = int.Parse(label5.Text);
                        _size2 = int.Parse(label6.Text);
                        _size3 = int.Parse(matchC.Groups[1].Value);


                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("circle");
                        c.set(texturestyle, dd, paintcolor, _size1, _size2, _size3 * 2, _size3 * 2);
                        //c.draw(set);
                        c.Draw(g);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

                // ----------------TRIANGLE WITH DrawTo---------------------- -//
                else if (match4.Success)
                {
                    try
                    {
                        g = pnlShow.CreateGraphics();
                        _size1 = int.Parse(match4.Groups[1].Value);
                        _size2 = int.Parse(match4.Groups[3].Value);

                        _size3 = int.Parse(match4.Groups[4].Value);
                        _size4 = int.Parse(match4.Groups[6].Value);
                        _size5 = int.Parse(match4.Groups[8].Value);


                        xi1 = _size1;
                        yi1 = _size2;
                        xi2 = Math.Abs(_size3);
                        yi2 = _size2;

                        xii1 = _size1;
                        yii1 = _size2;
                        xii2 = _size1;
                        yii2 = Math.Abs(_size4);

                        xiii1 = Math.Abs(_size3);
                        yiii1 = _size2;
                        xiii2 = _size1;
                        yiii2 = Math.Abs(_size4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle");
                        c.set(texturestyle, dd, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                        //=============================== 
                        c.Draw(g);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // ----------------TRIANGLE---------------------- -//

                else if (matchT.Success)
                {
                    try
                    {
                        g = pnlShow.CreateGraphics();
                        _size1 = int.Parse(label5.Text);
                        _size2 = int.Parse(label6.Text);

                        _size3 = int.Parse(matchT.Groups[1].Value);
                        _size4 = int.Parse(matchT.Groups[3].Value);
                        _size5 = int.Parse(matchT.Groups[5].Value);


                        xi1 = _size1;
                        yi1 = _size2;
                        xi2 = Math.Abs(_size3);
                        yi2 = _size2;

                        xii1 = _size1;
                        yii1 = _size2;
                        xii2 = _size1;
                        yii2 = Math.Abs(_size4);

                        xiii1 = Math.Abs(_size3);
                        yiii1 = _size2;
                        xiii2 = _size1;
                        yiii2 = Math.Abs(_size4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle"); //new rectangles();
                        c.set(texturestyle, dd, paintcolor, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
                        c.Draw(g);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // ----------------CLEAR------------------------//

                else if (matchClear.Success)
                {
                    pnlShow.Refresh();
                    this.pnlShow.BackgroundImage = null;
                }


                // ----------------RESET------------------------//
                else if (matchReset.Success)
                {
                    _size1 = 0;
                    _size2 = 0;
                    label5.Text = _size1.ToString();
                    label6.Text = _size2.ToString();

                }

                // ----------------MOVETO------------------------//

                else if (matchMT.Success)
                {
                    try
                    {
                        _size1 = int.Parse(matchMT.Groups[1].Value);
                        _size2 = int.Parse(matchMT.Groups[3].Value);

                       label5.Text = _size1.ToString();
                        label6.Text = _size2.ToString();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show("Command doesnot exist");
            }
        }
    }
    }

