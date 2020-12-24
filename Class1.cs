﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cupckace

    {
        public abstract class Versch
        {
            public Versch(int y1, int x1)
            {
                this.x1 = x1;
                this.y1 = y1;

            }
            public abstract void paintshit(Graphics paper);

            public int x1 { get; set; }
            public int y1 { get; set; }
            public int existance { get; set; }
            public int SetX { set { x1 = value; } get { return x1; } }
            public int SetY { set { y1 = value; } get { return y1; } }

        public static int R = 50;
            public static Color col { set; get; }
            abstract public bool check(int x, int y);
            public bool outline { get; set; }
        }
        class square : Versch

        {
            public square(int y1, int x1) : base(y1, x1)
            {

            }



            public override bool check(int x, int y)
            {
                if (x > x1 - R / 2 && x < x1 + R / 2)
                {
                    if (y > y1 - R / 2 && y < y1 + R / 2)
                        return true;
                }
                return false;

            }
            public override void paintshit(Graphics paper)
            {
                SolidBrush brush = new SolidBrush(Color.Red);
            if(existance==1)
                paper.FillRectangle(brush, x1 - R / 2, y1 - R / 2, R, R);




            }

        }
        class circle : Versch
        {
            public circle(int y1, int x1) : base(y1, x1)
            {

            }



            public override bool check(int x, int y)
            {
                if ((x - x1) * (x - x1) + (y - y1) * (y - y1) <= R * R / 4)
                    return true;
                return false;

            }
            public override void paintshit(Graphics paper)
            {
                SolidBrush brush = new SolidBrush(Color.Red);
            if (existance == 1)

                paper.FillEllipse(brush, x1 - R / 2, y1 - R / 2, R, R);

            }


        }
        class triangle : Versch
        {
            public triangle(int y1, int x1) : base(y1, x1)
            {

            }
            public override bool check(int x, int y)
            {
                if ((x - x1) * (x - x1) + (y - y1) * (y - y1) <= R * R / 4)
                    return true;
                return false;

            }
            public override void paintshit(Graphics paper)
            {
                SolidBrush brush = new SolidBrush(Color.Red);
            if (existance == 1)
            {
                Point point1 = new Point(x1, y1 - R / 2);
                Point point2 = new Point(x1 - R / 2, y1 + R / 2);
                Point point3 = new Point(x1 + R / 2, y1 + R / 2);
                Point[] coords = { point1, point2, point3 };


                paper.FillPolygon(brush, coords);
            }
            }

        }
    }


