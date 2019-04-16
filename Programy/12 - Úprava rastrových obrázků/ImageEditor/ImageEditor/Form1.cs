using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap b1, b2; // bitmapa obrázku1
                       // musím kreslit na bitmapu, aby to bylo trval
                       // tj. soubor načtu do bitmapy, do ní kreslím a tu provážu s obrázek1.Image
        PictureBox pb1, pb2;  //ty dva pictureboxy - pb1 vlevo

        Color brushColor = Color.FromName("Black");
        int brushSize = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (od.ShowDialog() == DialogResult.OK)                     //zavolám dialog a chci OK
            {
                Bitmap pom = new Bitmap(od.FileName);                   //finta - načtu do pom a ne do b1, aby to
                                                                        //nebylo provázáno se souborem (problém kreslení)
                if (b1 != null) b1.Dispose();                           //kvůli opakovanému otevření 
                b1 = new Bitmap(pom);                                   //b1 je nové a zkopíruje se z pom
                pom.Dispose();                                          //pom splnilo funkci
                //tím mám bitmapu b1 (šlo by načíst přímo do b1 bez pom, ale pak bych tam nemohl kreslit!!!)
                //vytvořím picture box a nastavím mu rodiče a rozměry a ...
                if (pb1 != null) { pb1.Dispose(); }
                pb1 = new PictureBox();
                pb1.Parent = this;
                pb1.BorderStyle = BorderStyle.FixedSingle;
                pb1.Left = 0;
                pb1.Top = 25;
                if (b1.Width > this.ClientSize.Width / 2) pb1.Width = this.ClientSize.Width / 2;
                else pb1.Width = b1.Width;

                if (b1.Height > this.ClientSize.Height - 100) pb1.Height = this.ClientSize.Height - 100;
                else pb1.Height = b1.Height;

                pb1.Image = b1;                                         //b1 se prováže s obrázkem1
                
                foreach(ToolStripMenuItem mi in hlavniMenu.Items) mi.Enabled = true;    // Allow the menu
                
                pb1.MouseMove += wasPictureBoxPressed;
            }
        }

        private void wasPictureBoxPressed(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            if (me.Button == MouseButtons.Left)
            {
                for (int i = 0; i < brushSize; i++)
                {
                    for (int j = 0; j < brushSize; j++)
                    {
                        int x = coordinates.X + i;
                        int y = coordinates.Y + j;

                        if (x >= 0 && x < b1.Width && y >= 0 && y < b1.Height)
                        {
                            b1.SetPixel(x, y, brushColor);
                            pb1.Image = b1;
                        }
                    }
                }
            }
        }

        private void smažVpravoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            if (pb2 != null) pb2.Dispose();
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drawLeftPictureBox(object sender, EventArgs e, int width, int height)
        {
            if (pb2 != null) pb2.Dispose();
            pb2 = new PictureBox();

            pb2.Parent = this;
            pb2.BorderStyle = BorderStyle.FixedSingle;
            pb2.Left = this.ClientSize.Width / 2 + 1;
            pb2.Top = 25;
            pb2.Width = width;
            pb2.Height = height;
            pb2.Image = b2;

        }

        /// <summary>
        /// Copies the picture quickly (the pictures are copied using quick system functions)
        /// </summary>
        private void celéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(b1);
            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Copies the picture slowly (pixels are copied one by one)
        /// </summary>
        private void celéPoBodechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width,pb1.Height);

            for (int i = 0; i < pb1.Width; i++) 
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, b1.GetPixel(i, j));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw only the red color from the picture.
        /// </summary>
        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(b1.GetPixel(i, j).R, 0, 0));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw only the green color from the picture.
        /// </summary>
        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(0, b1.GetPixel(i, j).G, 0));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw only the blue color from the picture.
        /// </summary>
        private void bToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(0, 0, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the blue and green (cyan) color from the picture.
        /// </summary>
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(0, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the red and blue (magneta) color from the picture.
        /// </summary>
        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(b1.GetPixel(i, j).R, 0, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the red and blue (magneta) color from the picture.
        /// </summary>
        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, 0));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the negative of the picture (255 - color value for each of the colors)
        /// </summary>
        private void negativToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, j, Color.FromArgb(255-b1.GetPixel(i, j).R, 255-b1.GetPixel(i, j).G, 255-b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the picture greyscaled (with arithmetic average)
        /// </summary>
        private void aritmetickýPrůměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                {
                    int average = (b1.GetPixel(i, j).R + b1.GetPixel(i, j).G + b1.GetPixel(i, j).B) / 3;
                    b2.SetPixel(i, j, Color.FromArgb(average, average, average));
                }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Draw the picture greyscaled (with weighed arithmetic average) - 0.2989 * R + 0.5866 * G + 0.1145 * B
        /// </summary>
        private void váženýPrůměrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)    
                {
                    int average = (int)(b1.GetPixel(i, j).R * 0.2989 + b1.GetPixel(i, j).G * 0.5866 + b1.GetPixel(i, j).B * 0.1145);
                    b2.SetPixel(i, j, Color.FromArgb(average, average, average));
                }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Flip the picture (vertically)
        /// </summary>
        private void svosláToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(pb1.Width - i - 1, j, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Flip the picture (horizontally)
        /// </summary>
        private void vodorovnáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(i, pb1.Height - j - 1, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Rotate picture both vertically and horizontally (flip vertical AND horziontal)
        /// </summary>
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(pb1.Width - i - 1, pb1.Height - j - 1, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Rotate +90 degrees (to the left)
        /// </summary>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Height, pb1.Width);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(j, i, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Height, pb1.Width);
        }

        /// <summary>
        /// Rotate -90 degrees (to the right)
        /// </summary>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Height, pb1.Width);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                    b2.SetPixel(pb1.Height - j - 1, i, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));

            drawLeftPictureBox(sender, e, pb1.Height, pb1.Width);
        }

        /// <summary>
        /// Create a black and white picture with no error distribution.
        /// </summary>
        private void obyčejnýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            for (int i = 0; i < pb1.Width; i++)
                for (int j = 0; j < pb1.Height; j++)
                {
                    int average = (int)(b1.GetPixel(i, j).R * 0.2989 
                                      + b1.GetPixel(i, j).G * 0.5866 
                                      + b1.GetPixel(i, j).B * 0.1145);
                    
                    // Either black or white, depending on the color average
                    if (average < 255 / 2) b2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else b2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Create a black and white picture WITH error distribution.
        /// </summary>
        private void distribuceChybyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);

            // Rows used for distributing the error in the algorithm
            int[] row1 = new int[pb1.Width];
            int[] row2 = new int[pb1.Width];

            for (int j = 0; j < pb1.Height; j++)
            {
                for (int i = 0; i < pb1.Width; i++)
                {
                    // Calculate the weighed average of colors and add the error
                    int average = (int)(b1.GetPixel(i, j).R * 0.2989 + b1.GetPixel(i, j).G * 0.5866 + b1.GetPixel(i, j).B * 0.1145) + row1[i];

                    int remainder = 0;
                    if (average < 255 / 2)
                    {
                        remainder = average;
                        b2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        remainder = average - 255;
                        b2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }

                    if (i != pb1.Width - 1) row1[i + 1] += remainder / 4;   // The pixel to the right
                    if (j != pb1.Height - 1) row2[i] += remainder / 4;  // The pixel down
                    if (i != 0 && j != pb1.Height - 1) row2[i - 1] += remainder / 4;   // The pixel down to the left
                    if (i != pb1.Width - 1 && j != pb1.Height - 1) row2[i + 1] += remainder / 4;   // The pixel down to the right
                }

                row1 = row2;
                row2 = new int[pb1.Width];
            }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Scale the picture down by 2.
        /// </summary>
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width/2 + 1, pb1.Height/2 + 1);
            for (int i = 0; i < pb1.Width; i+=2)
                for (int j = 0; j < pb1.Height; j+=2)
                {
                    Console.WriteLine(i + " " + j);
                    b2.SetPixel(i / 2, j / 2, Color.FromArgb(b1.GetPixel(i, j).R, b1.GetPixel(i, j).G, b1.GetPixel(i, j).B));
                }

            drawLeftPictureBox(sender, e, pb1.Width/2, pb1.Height/2);
        }

        /// <summary>
        /// Scale the picture up by 2.
        /// </summary>
        private void xCeléToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width * 2, pb1.Height * 2);

            for (int i = 0; i < pb1.Width * 2; i+=2)
                for (int j = 0; j < pb1.Height * 2; j+=2)
                    for (int k = 0; k < 4; k++)
                    {
                        int r = b1.GetPixel(i / 2, j / 2).R;
                        int g = b1.GetPixel(i / 2, j / 2).G;
                        int b = b1.GetPixel(i / 2, j / 2).B;

                        b2.SetPixel(i + k / 2, j + k % 2, Color.FromArgb(r, g, b));
                    }

            drawLeftPictureBox(sender, e, pb1.Width * 2, pb1.Height * 2);
        }

        /// <summary>
        /// Copy the top left part of the picture and scale it up by 2.
        /// </summary>
        private void lHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);
            for (int i = 0; i < pb1.Width - 1; i += 2)
                for (int j = 0; j < pb1.Height- 1; j += 2)
                    for (int k = 0; k < 4; k++)
                    {
                        int r = b1.GetPixel(i / 2, j / 2).R;
                        int g = b1.GetPixel(i / 2, j / 2).G;
                        int b = b1.GetPixel(i / 2, j / 2).B;

                        b2.SetPixel(i + k / 2, j + k % 2, Color.FromArgb(r, g, b));
                    }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Copy the top right part of the picture and scale it up by 2.
        /// </summary>
        private void pHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);
            for (int i = 0; i < pb1.Width - 1; i += 2)
                for (int j = 0; j < pb1.Height - 1; j += 2)
                    for (int k = 0; k < 4; k++)
                    {
                        int x = (i + pb1.Width) / 2;

                        int r = b1.GetPixel(x, j / 2).R;
                        int g = b1.GetPixel(x, j / 2).G;
                        int b = b1.GetPixel(x, j / 2).B;

                        b2.SetPixel(i + k / 2, j + k % 2, Color.FromArgb(r, g, b));
                    }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Change the color of the brush.
        /// </summary>
        private void barvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog clrDialog = new ColorDialog();
            
            if (clrDialog.ShowDialog() == DialogResult.OK)
            {
                brushColor = clrDialog.Color;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            brushSize = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            brushSize = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            brushSize = 3;
        }

        /// <summary>
        /// Copy the bottom left part of the picture and scale it up by 2.
        /// </summary>
        private void lDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width - 1, pb1.Height);
            for (int i = 0; i < pb1.Width - 1; i += 2)
                for (int j = 0; j < pb1.Height; j += 2)
                    for (int k = 0; k < 4; k++)
                    {
                        int y = (j + pb1.Height) / 2;

                        int r = b1.GetPixel(i / 2, y).R;
                        int g = b1.GetPixel(i / 2, y).G;
                        int b = b1.GetPixel(i / 2, y).B;

                        b2.SetPixel(i + k / 2, j + k % 2, Color.FromArgb(r, g, b));
                    }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }

        /// <summary>
        /// Copy the bottom right part of the picture and scale it up by 2.
        /// </summary>
        private void pDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b2 != null) b2.Dispose();
            b2 = new Bitmap(pb1.Width, pb1.Height);
            for (int i = 0; i < pb1.Width - 1; i += 2)
                for (int j = 0; j < pb1.Height - 1; j += 2)
                    for (int k = 0; k < 4; k++)
                    {
                        int x = (i + pb1.Width) / 2;
                        int y = (j + pb1.Height) / 2;

                        int r = b1.GetPixel(x, y).R;
                        int g = b1.GetPixel(x, y).G;
                        int b = b1.GetPixel(x, y).B;

                        b2.SetPixel(i + k / 2, j + k % 2, Color.FromArgb(r, g, b));
                    }

            drawLeftPictureBox(sender, e, pb1.Width, pb1.Height);
        }
    }
}
