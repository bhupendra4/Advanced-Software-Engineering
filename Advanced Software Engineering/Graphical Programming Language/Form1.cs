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
        public int b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2;
        Color paintColor = Color.Blue;

        Brush dd = new SolidBrush(Color.Red);
        int textusrestyle = 5;

        Factory shapeFactory = new Factory();
        Shape shapes;

        bool startPaint = false;
        int? inittX = null;
        int? inittY = null;
        int pointY, pointX = 0;
        Boolean DrawOrMove = false;
        int countLoop = 0;

        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int Size = 0;
        public int count =0;

        
 
        public int s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12;








        private void brnexecute_Click(object sender, EventArgs e)
        {
            loadCommandLines();

        }
        private void loadCommandLines()
        {
            int numbelines = txtCommand.Lines.Length;

            for (int i = 0; i < numbelines; i++)
            {
                String onelinecommand = txtCommand.Lines[i];
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
                        pointX = int.Parse(parms[0]);
                        pointY = int.Parse(parms[1]);
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
            for (countLoop = 0; countLoop < numbelines; countLoop++)
            {
                String onelinecommand = txtCommand.Lines[countLoop];
                onelinecommand = onelinecommand.Trim();
                if (!onelinecommand.Equals(""))
                {
                    runCommandLines(onelinecommand);
                }
            }
           
        }
        private void runCommandLines(string onelinecommand)
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
                        if (count == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (ifLineStart());
                    int ifEndLine = (ifLineEnd() - 1);
                    countLoop = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string oneLineCommand1 = txtCommand.Lines[j];
                            oneLineCommand1 = oneLineCommand1.Trim();
                            if (!oneLineCommand1.Equals(""))
                            {
                                runCommandLines(oneLineCommand1);
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
                        count = int.Parse(words2[1]);
                    }
                }
            }
            else if (hasPlus)
            {
                onelinecommand = System.Text.RegularExpressions.Regex.Replace(onelinecommand, @"\s+", " ");
                string[] words = onelinecommand.Split(' ');
                if (words[0].ToLower().Equals("repeat"))
                {
                    count = int.Parse(words[1]);
                    if (words[2].ToLower().Equals("circle"))
                    {
                        int increaseValue = size(onelinecommand);
                        radius = increaseValue;
                        for (int j = 0; j < count; j++)
                        {
                            circle(radius);
                            radius += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("rectangle"))
                    {
                        int increaseValue = size(onelinecommand);
                        Size = increaseValue;
                        for (int j = 0; j < count; j++)
                        {
                            rectangle(Size, Size);
                            Size += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("triangle"))
                    {
                        int increaseValue = size(onelinecommand);
                        Size = increaseValue;
                        for (int j = 0; j < count; j++)
                        {
                            triangle(Size, Size, Size);
                            Size += increaseValue;
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
                whenDarwCommandTrue(onelinecommand);
            }

        }
        



        private void whenDarwCommandTrue(String comandLineNumber)
        {
            String[] shapes = { "circle", "rectangle", "triangle", "polygon" };
            String[] variable = { "radius", "width", "height", "counter", "size" };

            comandLineNumber = System.Text.RegularExpressions.Regex.Replace(comandLineNumber, @"\s+", " ");
            string[] words = comandLineNumber.Split(' ');
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
                            circle(radius);
                        }
                    }
                    else
                    {
                        circle(Int32.Parse(words[1]));
                    }

                }
                else if (firstWord.Equals("rectangle"))
                {
                    String args = comandLineNumber.Substring(9, (comandLineNumber.Length - 9));
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
                            rectangle(width, height);
                        }
                        else
                        {
                            rectangle(width, Int32.Parse(parms[1]));
                        }

                    }
                    else
                    {
                        if (thirdWordIsVariable)
                        {
                            rectangle(Int32.Parse(parms[0]), height);
                        }
                        else
                        {
                            rectangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]));
                        }
                    }
                }
                else if (firstWord.Equals("triangle"))
                {
                    String args = comandLineNumber.Substring(8, (comandLineNumber.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    triangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]));
                }
                else if (firstWord.Equals("polygon"))
                {
                    String args = comandLineNumber.Substring(8, (comandLineNumber.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    if (parms.Length == 8)
                    {
                        polygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]));
                    }
                    else if (parms.Length == 10)
                    {
                        polygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]),
                            Int32.Parse(parms[8]), Int32.Parse(parms[9]));
                    }

                }

            }
            else
            {
                if (firstWord.Equals("loop"))
                {
                    count = int.Parse(words[1]);
                    int loopStartLine = (loopLineStart());
                    int loopEndLine = (loopLineEnd() - 1);
                    countLoop = loopEndLine;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = loopStartLine; j <= loopEndLine; j++)
                        {
                            String oneLineCommand = txtCommand.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                runCommandLines(oneLineCommand);
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
                        if (count == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (ifLineStart());
                    int ifEndLine = (ifLineEnd() - 1);
                    countLoop = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            String oneLineCommand = txtCommand.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                runCommandLines(oneLineCommand);
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
        /// 










        private int size(string lineCommand)
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

        private int ifLineEnd()
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

        private int ifLineStart()
        {
            int numberOfLines = txtCommand.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
  
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
        private int loopLineEnd()
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

        private int loopLineStart()
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
        private void polygon(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8)
        {
            Pen myPen = new Pen(paintColor);
            Point[] pnt = new Point[5];

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

            g.DrawPolygon(myPen, pnt);
        }
        /**
		 * Draw Polygon
		 */
        private void polygon(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int v10)
        {
            Pen myPen = new Pen(paintColor);
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
            pnt[5].Y = pointY - v10;
            g.DrawPolygon(myPen, pnt);
        }
        /**
		 * Draws a triangle 
		 */
        private void triangle(int rBase, int adj, int hyp)
        {
            Pen myPen = new Pen(paintColor);
            Point[] pnt = new Point[3];

            pnt[0].X = pointX;
            pnt[0].Y = pointY;

            pnt[1].X = pointX - rBase;
            pnt[1].Y = pointY;

            pnt[2].X = pointX;
            pnt[2].Y = pointY - adj;
            g.DrawPolygon(myPen, pnt);
        }

        private void rectangle(int width, int height)
        {
            Pen myPen = new Pen(paintColor);
            g.DrawRectangle(myPen, pointX - width / 2, pointY - height / 2, width, height);
        }


        private void circle(int radius)
        {
            Pen myPen = new Pen(paintColor);
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

                        c.set(texturestyle, dd, paintColor, s1, s2, s3, s4);
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
                        c.set(texturestyle, dd, paintColor, s1, s2, s3, s4);

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
                        c.set(texturestyle, dd, paintColor, s1, s2, s3 * 2, s3 * 2);
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
                        c.set(texturestyle, dd, paintColor, b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2);
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
                        c.set(texturestyle, dd, paintColor, b1, bb1, b2, bb2, c1, cc1, c2, cc2, d1, dd1, d2, dd2);
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

