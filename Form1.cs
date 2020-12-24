using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cupckace
{
    public partial class Form1 : Form
    {
        int shape = 1;
        Versch shaper;
        List<Versch> versches = new List<Versch>();
        
        int x1=100;
        int i = 0;
        int y1=100;
        bool above;
        bool below;
        public Form1()
        {
            shaper = new circle(0, 0);

            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                if (shape == 1)
                {

                    shaper = new circle(y1, x1);

                    versches.Add(shaper);
                }
                else
                {
                    if (shape == 2)
                    {
                        shaper = new square(y1, x1);

                        versches.Add(shaper);
                    }
                    if (shape == 3)
                    {
                        shaper = new triangle(y1, x1);

                        versches.Add(shaper);
                    }
                }




                versches[i].existance = 1;

                
                this.Invalidate();
                i++;
            }
                
            if (e.Button == MouseButtons.Right)
            {
                for (int j = 0; j < i; j++)
                {
                    if(versches[j].check(e.X,e.Y))
                        versches[j].existance = 0;

                }
                

                this.Invalidate();
            }
            


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            //for (int j = 0; j < i; j++)
           // {
           //     if(versches[j].existance==1)
           //     versches[j].paintshit(e.Graphics);
            //}
            foreach(Versch shaper in versches )
            {
                shaper.outline = false;
                if (shaper.existance == 1)
                    shaper.paintshit(e.Graphics);
            }

            for (int i = 0; i < versches.Count; i++)
            {

                for (int j = i + 1; j < versches.Count; j++)
                {
                    above = false;
                    below = false;

                    for (int k = 0; k < versches.Count; k++)
                    {
                        if (k != i && k != j && i != j)
                        {

                            if (((versches[k].y1 - versches[i].y1) * (versches[j].x1 - versches[i].x1)) > ((versches[k].x1 - versches[i].x1) * (versches[j].y1 - versches[i].y1)))
                                above = true;
                            else below = true;
                        }
                    }
                    if (!above || !below) // проверка что они по одну сторону
                    {
                        versches[i].outline = true;
                        versches[j].outline = true;
                        e.Graphics.DrawLine(new Pen(Color.Black), versches[i].x1, versches[i].y1, versches[j].x1, versches[j].y1);
                    }
                }











            }
            }


        private void КругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 1;
        }

        private void КвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 2;

        }

        private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shape = 3;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

                for (int j = 0; j < i; j++)
                {
                    if (e.Button == MouseButtons.Left && versches[j].check(e.X, e.Y))

                    {
                    versches[j].x1 = e.X;//+ e.X - versches[j].x1- 25;
                    versches[j].y1 = e.Y; //+ e.Y - versches[j].y1-25;
                        this.Invalidate();
                    }

                }

            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < versches.Count; i++)
            {


                if (!versches[i].outline)
                {
                    versches[i].existance=0;
                    this.Invalidate();
                }
                this.Invalidate();
            }
        }
    }
}
