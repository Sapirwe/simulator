using System;
using System.Collections.Generic;
using System.Text;

namespace simulator
{
    public class Anomaly
    {
        public float avg(List<float> x)
        {
            float sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i];
            }
            return sum / x.Count;
        }

        public float var(List<float> x)
        {
            float av = avg(x);
            float sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i] * x[i];
            }
            return (sum / x.Count) - av * av;
        }

        public float cov(List<float> x, List<float> y)
        {
            float sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i] * y[i];
            }
            sum /= x.Count;
            return sum - avg(x) * avg(y);
        }

        public float pearson(List<float> x, List<float> y)
        {
            return (float)(cov(x, y) / ((Math.Sqrt(var(x))) * (Math.Sqrt(var(y)))));
        }

        public Line linear_reg(List<float> x, List<float> y)
        {
            int size = x.Count;
            float a = cov(x, y) / var(x);
            float b = avg(y) - a * (avg(x));
            return new Line(a, b);
        }

        /*public float dev(Point p , List<Point> points)
        {
            Line l = linear_reg(points);
            return dev(p, l);
        }*/

        public float dev(Point p, Line l)
        {
            return Math.Abs(p.y - l.f(p.x));
        }
    }
}
