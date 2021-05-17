using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language
    
{
    /// <summary>
    /// this is the code for form 1
    /// </summary>
    public partial class Form1 : Form
    {
        public Boolean savechnage = false;
        public string FilePath;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pnlShow.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int xb1, yb1, xb2, yb2, xbb1, ybb1, xbb2, ybb2, xbbb1, ybbb1, xbbb2, ybbb2;
        Color paintcolor = Color.Blue;

        Brush dd = new SolidBrush(Color.Red);
        int textusrestyle = 5;

        Factory shapeFactory = new Factory();
        Shape shapes;

        bool startPaint = false;
        int? inittX = null;
        int? inittY = null;
        int MouY, MouX = 0;
        Boolean DrawOrMove = false;
        int loopcounter = 0;

        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int dSize = 0;
        public int counter =0;


        public int _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10, _size11, _size12;

        private void brnexecute_Click(object sender, EventArgs e)
        {
            loadcommand();

        }
        private void loadcommand()
        {
            int numbelines = richTextBox2.Lines.Length;

            for (int i = 0; i < numbelines; i++)
            {
                String onelinecommand = richTextBox2.Lines[i];
                onelinecommand = onelinecommand.Trim();
                if (!onelinecommand.Equals(" "))
                {
                    Boolean Drawto = Regex.IsMatch(onelinecommand.ToLower(), @"\ddrawto\d");
                    Boolean moveto = Regex.IsMatch(onelinecommand.ToLower(), @"\dmoveto\d");
                    if (Drawto || moveto)
                    {
                        String args = onelinecommand.Substring(6, (onelinecommand.Length - 6));
                        String[] parms = args.Split(',');
                        for (int k=0; k<parms.Length; k++)
                        {
                            parms[k] = parms[k].Trim();
                        }
                        MouX = int.Parse(parms[0]);
                        MouY = int.Parse(parms[1]);
                        DrawOrMove = true;
                    }
                    else
                    {
                        DrawOrMove = false;
                    }
                    if (moveto)
                    {
                        pnlShow.Refresh();
                    }
                }
            }
            for (loopcounter = 0; loopcounter < numbelines; loopcounter++)
            {
                String onelinecommand = richTextBox2.Lines[loopcounter];
                onelinecommand = onelinecommand.Trim();
                if (!onelinecommand.Equals(""))
                {
                    Run(onelinecommand);
                }
            }
           
        }
        private void Run(string onelinecommand)
        {
            Boolean hasPlus = onelinecommand.Contains('+');
            Boolean hasEquals = onelinecommand.Contains("=");
            if (hasEquals)
            {
                onelinecommand = Regex.Replace(onelinecommand, @"\s+", " ");
                string[] words = onelinecommand.Split(' ');
                //removing white spaces in between words
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[3]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (StartLineNumber());
                    int ifEndLine = (EndLineNumber() - 1);
                    loopcounter = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string oneLineCommand1 = richTextBox2.Lines[j];
                            oneLineCommand1 = oneLineCommand1.Trim();
                            if (!oneLineCommand1.Equals(""))
                            {
                                Run(oneLineCommand1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("If Statement is false");
                    }
                }
                else
                {
                    string[] words2 = onelinecommand.Split('=');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("counter"))
                    {
                        counter = int.Parse(words2[1]);
                    }
                }
            }
            else if (hasPlus)
            {
                onelinecommand = System.Text.RegularExpressions.Regex.Replace(onelinecommand, @"\s+", " ");
                string[] words = onelinecommand.Split(' ');
                if (words[0].ToLower().Equals("repeat"))
                {
                    counter = int.Parse(words[1]);
                    if (words[2].ToLower().Equals("circle"))
                    {
                        int increaseValue = GetSize(onelinecommand);
                        radius = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawCircle(radius);
                            radius += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("rectangle"))
                    {
                        int increaseValue = GetSize(onelinecommand);
                        dSize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawRectangle(dSize, dSize);
                            dSize += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("triangle"))
                    {
                        int increaseValue = GetSize(onelinecommand);
                        dSize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawTriangle(dSize, dSize, dSize);
                            dSize += increaseValue;
                        }
                    }
                }
                else
                {
                    string[] words2 = onelinecommand.Split('+');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height += int.Parse(words2[1]);
                    }
                }
            }
            else
            {
                senddrawcommand(onelinecommand);
            }

        }
        private void DrawRectangle(int width, int height)
        {
            Pen myPen = new Pen(paintcolor);
            g.DrawRectangle(myPen, MouX - width / 2, MouY - height / 2, width, height);
        }
        private void DrawCircle(int radius)
        {
            Pen myPen = new Pen(paintcolor);
            g.DrawEllipse(myPen, MouX - radius, MouY - radius, radius * 2, radius * 2);
        }
        private void senddrawcommand(String lineofcommand)
        {

        }
       
        private int StartLineNumber()
        {
            int numberoflines = richTextBox2.Lines.Length;
            int num = 0;

            for (int i =0; i < numberoflines; i++)
            {
                String onelinecommand = richTextBox2.Lines[i];
                onelinecommand = Regex.Replace(onelinecommand, @"\s+", " ");
                string[] wod = onelinecommand.Split(' ');
                for (int k = 0; k < wod.Length; k++)
                {
                    wod[k] = wod[k].Trim();
                }
                String firstWord = wod[0].ToLower();
                onelinecommand = onelinecommand.Trim();
                if (firstWord.Equals("if"))
                {
                    num = i + 1;

                }
            }
            return num;
        }
        private int EndLineNumber()
        {
            int numberlines = richTextBox2.Lines.Length;
            int num = 0;
            return num;
        }
        private void DrawTriangle(int rBase, int adj, int hyp)
        {
            Pen pen = new Pen(paintcolor);

        }
        private int GetSize(string linecommand)
        {
            int value = 0;
            return value;

        }
        private void btnload_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Text Document(*.txt) | *.txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(of.FileName);
            }
        }

        private void btnclear2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void pnlShow_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            inittX = null;
            inittY = null;
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
            //for save text
            SaveFileDialog bhupe = new SaveFileDialog();
            bhupe.Filter ="Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (bhupe.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(bhupe.FileName, richTextBox1.Text);
            }
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Graphical Programming Language || Version 1.0.2|| BHupendra");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlShow.Invalidate();
            richTextBox1.Text = "";
            richTextBox2.Text = "";
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


                        xb1 = _size1;
                        yb1 = _size2;
                        xb2 = Math.Abs(_size3);
                        yb2 = _size2;

                        xbb1 = _size1;
                        ybb1 = _size2;
                        xbb2 = _size1;
                        ybb2 = Math.Abs(_size4);

                        xbbb1 = Math.Abs(_size3);
                        ybbb1 = _size2;
                        xbbb2 = _size1;
                        ybbb2 = Math.Abs(_size4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle");
                        c.set(texturestyle, dd, paintcolor, xb1, yb1, xb2, yb2, xbb1, ybb1, xbb2, ybb2, xbbb1, ybbb1, xbbb2, ybbb2);
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


                        xb1 = _size1;
                        yb1 = _size2;
                        xb2 = Math.Abs(_size3);
                        yb2 = _size2;

                        xbb1 = _size1;
                        ybb1 = _size2;
                        xbb2 = _size1;
                        ybb2 = Math.Abs(_size4);

                        xbbb1 = Math.Abs(_size3);
                        ybbb1 = _size2;
                        xbbb2 = _size1;
                        ybb2 = Math.Abs(_size4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle"); //new rectangles();
                        c.set(texturestyle, dd, paintcolor, xb1, yb1, xb2, yb2, xbb1, ybb1, xbb2, ybb2, xbbb1, ybbb1, xbbb2, ybbb2);
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
                MessageBox.Show("Press Enter to Show result");
            }
        }
    }
    }

