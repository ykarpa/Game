using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCircles
{
    class Shape : PictureBox
    {

    }
    class Circle : Shape
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }

    class Star : Shape
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                // Визначте координати точок для створення зірки
                Point[] starPoints = GetStarPoints(5, new Point(Width / 2, Height / 2), Math.Min(Width, Height) / 2);

                // Додайте лінії та точки до графічного шляху
                gp.AddLines(starPoints);
                gp.CloseFigure();

                // Застосуйте графічний шлях як область форми
                this.Region = new Region(gp);
            }
        }

        private Point[] GetStarPoints(int numPoints, Point center, int radius)
        {
            Point[] points = new Point[numPoints * 2];
            double angle = -Math.PI / 2;
            double angleIncrement = Math.PI / numPoints;

            for (int i = 0; i < numPoints * 2; i++)
            {
                if (i % 2 == 0)
                {
                    points[i] = new Point(center.X + (int)(radius * Math.Cos(angle)), center.Y + (int)(radius * Math.Sin(angle)));
                }
                else
                {
                    points[i] = new Point(center.X + (int)(radius / 2 * Math.Cos(angle)), center.Y + (int)(radius / 2 * Math.Sin(angle)));
                }
                angle += angleIncrement;
            }

            return points;
        }
    }
}
