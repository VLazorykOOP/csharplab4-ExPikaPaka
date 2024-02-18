using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.src {
    class Point {
        // Class fields
        protected int x;
        protected int y;
        protected int color;

        // Constructor
        public Point(int x = 0, int y = 0) {
            this.x = x;
            this.y = y;
            color = 0;
        }

        // Indexer
        public int this[int index] {
            get {
                switch (index) {
                    case 0: return x;
                    case 1: return y;
                    case 2: return color;
                    default:
                        Console.WriteLine("Error: Invalid index!");
                        return -1;
                }
            }
            set {
                switch (index) {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: color = value; break;
                    default:
                        Console.WriteLine("Error: Invalid index!");
                        break;
                }
            }
        }

        // Prefix increment operator ++
        public static Point operator ++(Point point) {
            point.x++;
            point.y++;
            return point;
        }

        // Prefix decrement operator --
        public static Point operator --(Point point) {
            point.x--;
            point.y--;
            return point;
        }

        // Overloading true and false
        public static explicit operator bool(Point point) {
            return point.x == point.y;
        }

        // Binary addition operator +
        public static Point operator +(Point point, int scalar) {
            return new Point(point.x + scalar, point.y + scalar);
        }

        // Conversion to string
        public static explicit operator string(Point point) {
            return $"{point.x}, {point.y}, {point.color}";
        }

        // Conversion from string
        public static explicit operator Point(string str) {
            string[] parts = str.Split(',');
            int x = int.Parse(parts[0].Trim('(', ')'));
            int y = int.Parse(parts[1].Trim());
            int color = int.Parse(parts[2].Trim());
            return new Point(x, y) { color = color };
        }

        // Class methods
        public void Show() {
            Console.WriteLine($"Coordinates: ({x}, {y}), Color: {color}");
        }
    }
}
