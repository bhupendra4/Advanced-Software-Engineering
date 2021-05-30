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
        public Boolean save = false;
        public string path;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pnlShow.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2;
        Color mycolor12 = Color.Blue;

        Brush dd = new SolidBrush(Color.Red);
        int text12 = 5;

        Factory shapeFactory = new Factory();
        Shape shapes;

        bool startPaint = false;
        int? inittX = null;
        int? inittY = null;
        int pointX, pointY= 0;
        Boolean drawmove = false;
        int Counter12 = 0;
        public int size001 = 0;

        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int Size = 0;
        public int counter =0;

        
 
        public int s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;








        private void brnexecute_Click(object sender, EventArgs e)
        {
            loadCommandLines();

        }
        private void loadCommandLines()
        {
            int number = txtCommand.Lines.Length;

            for (int i = 0; i < number; i++)
            {
                String singlecommanad = txtCommand.Lines[i];
                singlecommanad = singlecommanad.Trim();
                if (!singlecommanad.Equals(""))
                {
                    Boolean hasDrawto = Regex.IsMatch(singlecommanad.ToLower(), @"\bdrawto\b");
                    Boolean hasMoveto = Regex.IsMatch(singlecommanad.ToLower(), @"\bmoveto\b");

                    if (hasDrawto || hasMoveto)
                    {
                        String args = singlecommanad.Substring(6, (singlecommanad.Length - 6));
                        String[] parms = args.Split(',');
                        for (int j = 0; j < parms.Length; j++)
                        {
                            parms[j] = parms[j].Trim();
                        }
                        pointX = int.Parse(parms[0]);
                        pointY = int.Parse(parms[1]);
                        drawmove = true;
                    }
                    else
                    {
                        drawmove = false;
                    }
                    if (hasMoveto)
                    {
                        pnlShow.Refresh();
                    }
                }
            }
            for (counter = 0; counter < number; counter++)
            {
                String singlecommand = txtCommand.Lines[counter];
                singlecommand = singlecommand.Trim();
                if (!singlecommand.Equals(""))
                {
                    RunCommand(singlecommand);
                }
            }
        }


        private void RunCommand(String singlecommand)
        {
            Boolean hasPlus = singlecommand.Contains('+');
            Boolean hasEquals = singlecommand.Contains("=");
            if (hasEquals)
            {
                singlecommand = Regex.Replace(singlecommand, @"\s+", " ");
                string[] words = singlecommand.Split(' ');
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

                    int ifStartLine = (GetIfStartLineNumber());
                    int ifEndLine = (GetEndifEndLineNumber() - 1);
                    counter = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string newsignlecommand = txtCommand.Lines[j];
                            newsignlecommand = newsignlecommand.Trim();
                            if (!newsignlecommand.Equals(""))
                            {
                                RunCommand(newsignlecommand);
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
                    string[] words2 = singlecommand.Split('=');
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
                singlecommand = System.Text.RegularExpressions.Regex.Replace(singlecommand, @"\s+", " ");
                string[] words = singlecommand.Split(' ');
                if (words[0].ToLower().Equals("repeat"))
                {
                    counter = int.Parse(words[1]);
                    if (words[2].ToLower().Equals("circle"))
                    {
                        int increaseValue = GetSize(singlecommand);
                        radius = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawCircle(radius);
                            radius += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("rectangle"))
                    {
                        int increaseValue = GetSize(singlecommand);
                        size001 = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawRectangle(size001, size001);
                            size001 += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("triangle"))
                    {
                        int increaseValue = GetSize(singlecommand);
                        size001 = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawTriangle(size001, size001, size001);
                            size001 += increaseValue;
                        }
                    }
                }
                else
                {
                    string[] words2 = singlecommand.Split('+');
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
                sendDrawCommand(singlecommand);
            }
        }

        /// <summary>
		/// Returns the size of structure
		/// </summary>
		/// <param name="lineCommand"></param>
		/// <returns></returns>
        private int GetSize(string lineCommand)
        {
            int value = 0;
            if (lineCommand.ToLower().Contains("radius"))
            {
                int pos = (lineCommand.IndexOf("radius") + 6);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);

            }
            else if (lineCommand.ToLower().Contains("size"))
            {
                int pos = (lineCommand.IndexOf("size") + 4);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);
            }
            return value;
        }
        /// <summary>
        ///  Initiate shapes and figure to build shapes
        /// </summary>
        /// <param name="lineOfCommand"></param>
        private void sendDrawCommand(string lineOfCommand)
        {
            String[] shapes = { "circle", "rectangle", "triangle", "polygon" };
            String[] variable = { "radius", "width", "height", "counter", "size" };

            lineOfCommand = System.Text.RegularExpressions.Regex.Replace(lineOfCommand, @"\s+", " ");
            string[] words = lineOfCommand.Split(' ');
            //removing white spaces in between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstWord = words[0].ToLower();
            Boolean firstWordShape = shapes.Contains(firstWord);
            if (firstWordShape)
            {

                if (firstWord.Equals("circle"))
                {
                    Boolean secondWordIsVariable = variable.Contains(words[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (words[1].ToLower().Equals("radius"))
                        {
                            DrawCircle(radius);
                        }
                    }
                    else
                    {
                        DrawCircle(Int32.Parse(words[1]));
                    }

                }
                else if (firstWord.Equals("rectangle"))
                {
                    String args = lineOfCommand.Substring(9, (lineOfCommand.Length - 9));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    Boolean secondWordIsVariable = variable.Contains(parms[0].ToLower());
                    Boolean thirdWordIsVariable = variable.Contains(parms[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (thirdWordIsVariable)
                        {
                            DrawRectangle(width, height);
                        }
                        else
                        {
                            DrawRectangle(width, Int32.Parse(parms[1]));
                        }

                    }
                    else
                    {
                        if (thirdWordIsVariable)
                        {
                            DrawRectangle(Int32.Parse(parms[0]), height);
                        }
                        else
                        {
                            DrawRectangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]));
                        }
                    }
                }
                else if (firstWord.Equals("triangle"))
                {
                    String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    DrawTriangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]));
                }
                else if (firstWord.Equals("polygon"))
                {
                    String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    if (parms.Length == 8)
                    {
                        DrawPolygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]));
                    }
                    else if (parms.Length == 10)
                    {
                        DrawPolygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]),
                            Int32.Parse(parms[8]), Int32.Parse(parms[9]));
                    }

                }

            }
            else
            {
                if (firstWord.Equals("loop"))
                {
                    counter = int.Parse(words[1]);
                    int loopStartLine = (GetLoopStartLineNumber());
                    int loopEndLine = (GetLoopEndLineNumber() - 1);
                    counter = loopEndLine;
                    for (int i = 0; i < counter; i++)
                    {
                        for (int j = loopStartLine; j <= loopEndLine; j++)
                        {
                            String oneLineCommand = txtCommand.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
                else if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[1]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetIfStartLineNumber());
                    int ifEndLine = (GetEndifEndLineNumber() - 1);
                    counter = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            String oneLineCommand = txtCommand.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
		/// initiates loop 
		/// </summary>
		/// <returns></returns>
        private int GetEndifEndLineNumber()
        {
            int numberOfLines = txtCommand.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals("endif"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }
        /// <summary>
		/// initiates if there is an if clause
		/// </summary>
		/// <returns></returns>
        private int GetIfStartLineNumber()
        {
            int numberOfLines = txtCommand.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.Equals("if"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }
        /// <summary>
		/// Initiates loops
		/// </summary>
		/// <returns></returns>
        private int GetLoopEndLineNumber()
        {
            try
            {
                int numberOfLines = txtCommand.Lines.Length;
                int lineNum = 0;

                for (int i = 0; i < numberOfLines; i++)
                {
                    String oneLineCommand = txtCommand.Lines[i];
                    oneLineCommand = oneLineCommand.Trim();
                    if (oneLineCommand.ToLower().Equals("endloop"))
                    {
                        lineNum = i + 1;

                    }
                }
                return lineNum;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// getting loops starting line number
        /// </summary>
        /// <returns></returns>
        private int GetLoopStartLineNumber()
        {
            int numberOfLines = txtCommand.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.Equals("loop"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;

        }
       
        private void DrawPolygon(int b1, int b2, int b3, int b4, int b5, int b6, int b7, int b8)
        {
            Pen myPen = new Pen(mycolor12);
            Point[] pnt = new Point[5];

            pnt[0].X = pointX;
            pnt[0].Y = pointY;

            pnt[1].X = pointX - b1;
            pnt[1].Y = pointY - b2;

            pnt[2].X = pointX - b3;
            pnt[2].Y = pointY - b4;

            pnt[3].X = pointX - b5;
            pnt[3].Y = pointY - b6;

            pnt[4].X = pointX - b7;
            pnt[4].Y = pointY - b8;

            g.DrawPolygon(myPen, pnt);
        }
        /// <summary>
        /// logic to draw polygon
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <param name="v5"></param>
        /// <param name="v6"></param>
        /// <param name="v7"></param>
        /// <param name="v8"></param>
        /// <param name="v9"></param>
        /// <param name="v11"></param>
        private void DrawPolygon(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int v11)
        {
            Pen myPen = new Pen(mycolor12);
            Point[] pnt = new Point[6];

            pnt[0].X = pointX;
            pnt[0].Y = pointY;

            pnt[1].X = pointX - v1;
            pnt[1].Y = pointY - v2;

            pnt[2].X = pointX - v3;
            pnt[2].Y = pointY - v4;

            pnt[3].X = pointX - v5;
            pnt[3].Y = pointY - v6;

            pnt[4].X = pointX - v7;
            pnt[4].Y = pointY - v8;

            pnt[5].X = pointX - v9;
            pnt[5].Y = pointY - v11;
            g.DrawPolygon(myPen, pnt);
        }
        /// <summary>
        /// logic to draw triangle
        /// </summary>
        /// <param name="basee"></param>
        /// <param name="adj"></param>
        /// <param name="hyp"></param>
        private void DrawTriangle(int basee, int adj, int hyp)
        {
            Pen myPen = new Pen(mycolor12);
            Point[] pnt = new Point[3];

            pnt[0].X = pointX;
            pnt[0].Y = pointY;

            pnt[1].X = pointX - basee;
            pnt[1].Y = pointY;

            pnt[2].X = pointX;
            pnt[2].Y = pointY - adj;
            g.DrawPolygon(myPen, pnt);
        }
        /// <summary>
        /// logic to draw rectangle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawRectangle(int width, int height)
        {
            Pen myPen = new Pen(mycolor12);
            g.DrawRectangle(myPen, pointX - width / 2, pointY - height / 2, width, height);
        }
        /// <summary>
        /// logic to draw circle
        /// </summary>
        /// <param name="radius"></param>

        private void DrawCircle(int radius)
        {
            Pen myPen = new Pen(mycolor12);
            g.DrawEllipse(myPen, pointX - radius, pointY - radius, radius * 2, radius * 2);
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
            txtCommand.Text = "";
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
            MessageBox.Show("Graphical Programming Language || Version 1.0.2|| Bhupendra");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlShow.Invalidate();
            richTextBox1.Text = "";
            txtCommand.Text = "";
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
                        s1 = int.Parse(match2.Groups[1].Value);
                        s2 = int.Parse(match2.Groups[3].Value);
                        s3 = int.Parse(match2.Groups[4].Value);
                        s4 = int.Parse(match2.Groups[6].Value);



                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("rectangle");

                        c.set(texturestyle, dd, mycolor12, s1, s2, s3, s4);
                        c.draw(g);

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
                        s1 = int.Parse(label5.Text);
                        s2 = int.Parse(label6.Text);
                        s3 = int.Parse(matchR.Groups[1].Value);
                        s4 = int.Parse(matchR.Groups[3].Value);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("rectangle");
                        c.set(texturestyle, dd, mycolor12, s1, s2, s3, s4);

                        c.draw(g);
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
                        s1 = int.Parse(label5.Text);
                        s2 = int.Parse(label6.Text);
                        s3 = int.Parse(matchC.Groups[1].Value);


                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("circle");
                        c.set(texturestyle, dd, mycolor12, s1, s2, s3 * 2, s3 * 2);
                        //c.draw(set);
                        c.draw(g);
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
                        s1 = int.Parse(match4.Groups[1].Value);
                        s2 = int.Parse(match4.Groups[3].Value);

                        s3 = int.Parse(match4.Groups[4].Value);
                        s4 = int.Parse(match4.Groups[6].Value);
                        s5 = int.Parse(match4.Groups[8].Value);


                        b1 = s1;
                        bb1 = s2;
                        b2 = Math.Abs(s3);
                        bb2 = s2;

                        c1 = s1;
                        cc1 = s2;
                        c2 = s1;
                        cc2 = Math.Abs(s4);

                        d1 = Math.Abs(s3);
                        dd1 = s2;
                        d2 = s1;
                        dd2 = Math.Abs(s4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle");
                        c.set(texturestyle, dd, mycolor12, b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2);
                        //=============================== 
                        c.draw(g);
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
                        s1 = int.Parse(label5.Text);
                        s2 = int.Parse(label6.Text);

                        s3 = int.Parse(matchT.Groups[1].Value);
                        s4 = int.Parse(matchT.Groups[3].Value);
                        s5 = int.Parse(matchT.Groups[5].Value);


                        b1 = s1;
                        bb1 = s2;
                        b2 = Math.Abs(s3);
                        bb2 = s2;

                        c1 = s1;
                        cc1 = s2;
                        c2 = s1;
                        cc2 = Math.Abs(s4);

                        d1 = Math.Abs(s3);
                        dd1 = s2;
                        d2 = s1;
                        cc2 = Math.Abs(s4);

                        Factory shapeFactory = new Factory();
                        Shape c = shapeFactory.GetShape("triangle"); //new rectangles();
                        c.set(texturestyle, dd, mycolor12, b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2);
                        c.draw(g);
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
                    s1 = 0;
                    s2 = 0;
                    label5.Text = s1.ToString();
                    label6.Text = s2.ToString();

                }

                // ----------------MOVETO------------------------//

                else if (matchMT.Success)
                {
                    try
                    {
                        s1 = int.Parse(matchMT.Groups[1].Value);
                        s2 = int.Parse(matchMT.Groups[3].Value);

                       label5.Text = s1.ToString();
                        label6.Text = s2.ToString();
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

