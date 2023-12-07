using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        // 构造函数
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // 点乘
        public double Dot(Vector other)
        {
            return X * other.X + Y * other.Y;
        }

        // 叉乘
        public double Cross(Vector other)
        {
            return X * other.Y - Y * other.X;
        }

        // 相加
        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y);
        }

        // 相减
        public Vector Subtract(Vector other)
        {
            return new Vector(X - other.X, Y - other.Y);
        }

        // 与常数相乘
        public Vector Multiply(double scalar)
        {
            return new Vector(X * scalar, Y * scalar);
        }
    }
}
