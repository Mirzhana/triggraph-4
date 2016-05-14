using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinusoid
{
    public partial class Form1 : Form
    {
        List<PointF> arr1 = new List<PointF>(); // y=x
        List<PointF> arr2 = new List<PointF>();//y=sinx
        List<PointF> arr3 = new List<PointF>();//y=x+sinx
        List<PointF> arr4 = new List<PointF>();//y=xsinx

        public Pen coord = new Pen(Color.Black,2); // pen to draw x and y
        public Pen secondp = new Pen(Color.Red, 2); // pen to draw the curve sinx
        public Pen firstp = new Pen(Color.Green, 2);
        public Pen thridp = new Pen(Color.Orange, 2);
        public Pen fourthp = new Pen(Color.Yellow, 2);

        int x1 = 0; // inital value of x 
        int x2 = 0;
        int x3 = 0;

        Point p1 = new Point(540, 525); // points of coordinates x and y 
        Point p2 = new Point(540, 0);
        Point p3 = new Point(0, 260);
        Point p4 = new Point(1050, 260);

        public Form1()
        {
            InitializeComponent();
            arr1.Add(new PointF((float)0, (float)260)); // inital point of the curve sinus
            arr1.Add(new PointF((float)0, (float)260));

            arr2.Add(new PointF((float)536, (float)260)); // initial point of the y = x
            arr2.Add(new PointF((float)536, (float)260));

            arr3.Add(new PointF((float)800, (float)0)); // initial point of the y = x + sin(x)
            arr3.Add(new PointF((float)800, (float)0));

            arr4.Add(new PointF((float)536, (float)260)); // initial point of the y = x * sin(x)
            arr4.Add(new PointF((float)536, (float)260));

            Points();

           

            

        }

        void Points()
        {

            for (int i = 0; i < 2000; i++) // y = x
            {
                if (i <= 1000)
                {
                    double y1 = x1++;
                    arr2.Add(new PointF((float)-x1 + 536, (float)y1 + 260)); // drawing the curve
                }
                else
                {
                    double y1 = x1++;
                    arr2.Add(new PointF((float)x1 + 536, (float)-y1 + 260)); // drawing the curve

                }
            }

            for (int i = 0; i < 9999; i++) //y = sinx
            {
                double y2 = Math.Sin(x2++);
                y2 = y2 * 30 + 260;
                arr1.Add(new PointF((float)x2 * 20 - 49, (float)y2)); // drawing the curve

            }

            for (int i = 0; i < 9999; i++) // y = sinx + x
            {

                double y3 = Math.Sin(x3++) + x3;
                y3 = y3 * 20 ;
                arr3.Add(new PointF((float)-x3 * 20 + 800, (float)y3)); // drawing the curve

            } 

            for (int i = 0; i < 1000; i++) // y = x*sinx
            {

            }



        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            coord.StartCap = LineCap.ArrowAnchor; //drawing arrow
            coord.EndCap = LineCap.Flat;
            e.Graphics.DrawLine(coord, p2, p1 );

            coord.EndCap = LineCap.ArrowAnchor;
            coord.StartCap = LineCap.Flat;
            e.Graphics.DrawLine(coord, p3, p4);

            
            e.Graphics.DrawCurve(firstp, arr2.ToArray());
            e.Graphics.DrawCurve(secondp, arr1.ToArray());
            e.Graphics.DrawCurve(thridp, arr3.ToArray());

            for (int i = 20; i <= 1000; i +=30) //drawing net
            {
                if (i != 260) { 
                e.Graphics.DrawLine(new Pen(Color.LightBlue), 1053, i, 0, i);
                }
            }
            for (int i = 8; i <= 10000; i += 33)
            {
                if (i != 536) { 
                e.Graphics.DrawLine(new Pen(Color.LightBlue), i, 0, i, 540);
                }
            }
        }
    }
}
