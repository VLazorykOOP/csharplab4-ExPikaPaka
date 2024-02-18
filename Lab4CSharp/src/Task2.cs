using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.src {
    class Vector {
        protected int[] IntArray;
        protected uint size;
        protected int codeError;

        public uint Size => size;
        public int CodeError {
            get { return codeError; }
            set { codeError = value; }
        }

        public Vector() {
            IntArray = new int[1];
            size = 1;
            codeError = 0;
        }

        public Vector(uint size) {
            IntArray = new int[size];
            this.size = size;
            for (int i = 0; i < size; i++) {
                IntArray[i] = 0;
            }
            codeError = 0;
        }

        public Vector(uint size, int initializationValue) {
            IntArray = new int[size];
            this.size = size;
            for (int i = 0; i < size; i++) {
                IntArray[i] = initializationValue;
            }
            codeError = 0;
        }

        ~Vector() {
            Console.WriteLine("Destructor is called.");
        }

        public void InputValues() {
            for (int i = 0; i < size; i++) {
                Console.Write($"Enter element {i}: ");
                IntArray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void Display() {
            Console.WriteLine("Vector elements:");
            for (int i = 0; i < size; i++) {
                Console.WriteLine($"Element {i}: {IntArray[i]}");
            }
        }

        public void AssignValue(int value) {
            for (int i = 0; i < size; i++) {
                IntArray[i] = value;
            }
        }  

        public int this[int index] {
            get {
                if (index < 0 || index >= size) {
                    codeError = -1;
                    return 0;
                } else {
                    codeError = 0;
                    return IntArray[index];
                }
            }
            set {
                if (index >= 0 && index < size) {
                    IntArray[index] = value;
                } else {
                    codeError = -1;
                }
            }
        }

        // Overloading unary operators
        public static Vector operator ++(Vector vector) {
            for (int i = 0; i < vector.size; i++) {
                vector.IntArray[i]++;
            }
            return vector;
        }

        public static Vector operator --(Vector vector) {
            for (int i = 0; i < vector.size; i++) {
                vector.IntArray[i]--;
            }
            return vector;
        }

        public static explicit operator bool(Vector vector) {
            if (vector.size == 0) {
                return false;
            }
            foreach (int element in vector.IntArray) {
                if (element == 0) {
                    return false;
                }
            }
            return true;
        }

        public static Vector operator ~(Vector vector) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = ~vector.IntArray[i];
            }
            return result;
        }

        public static Vector operator +(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for addition.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] + vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator +(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] + scalar;
            }
            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for subtraction.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] - vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator -(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] - scalar;
            }
            return result;
        }

        public static Vector operator *(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for multiplication.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] * vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator *(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] * scalar;
            }
            return result;
        }

        public static Vector operator /(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for division.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] / vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator /(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] / scalar;
            }
            return result;
        }

        public static Vector operator %(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer division.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] % vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator %(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] % scalar;
            }
            return result;
        }

        public static Vector operator |(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer binary sum.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] | vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator |(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] | scalar;
            }
            return result;
        }

        public static Vector operator ^(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer xor.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] ^ vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator ^(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] ^ scalar;
            }
            return result;
        }

        public static Vector operator >>(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer binary move rigth.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] >> vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator >>(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] >> scalar;
            }
            return result;
        }

        public static Vector operator <<(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer binary move rigth.");
            }

            Vector result = new Vector(vector1.size);
            for (int i = 0; i < vector1.IntArray.Length; i++) {
                result.IntArray[i] = vector1.IntArray[i] << vector2.IntArray[i];
            }
            return result;
        }

        public static Vector operator <<(Vector vector, int scalar) {
            Vector result = new Vector(vector.size);
            for (int i = 0; i < vector.IntArray.Length; i++) {
                result.IntArray[i] = vector.IntArray[i] << scalar;
            }
            return result;
        }

        public static bool operator ==(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer equality check.");
            }

            for (int i = 0; i < vector1.IntArray.Length; i++) {
                if(vector1.IntArray[i] != vector2.IntArray[i]) { return false; }
            }
            return true;
        }

        public static bool operator !=(Vector vector1, Vector vector2) {
            if (vector1.size != vector2.size) {
                throw new ArgumentException("Vectors must be of the same size for integer non eqaulity check.");
            }

            for (int i = 0; i < vector1.IntArray.Length; i++) {
                if (vector1.IntArray[i] == vector2.IntArray[i]) { return false; }
            }
            return true;
        }

        public static bool operator >(Vector vector1, Vector vector2) {
            return vector1.size > vector2.size; 
        }

        public static bool operator <(Vector vector1, Vector vector2) {
            return vector1.size < vector2.size;
        }

        public static bool operator >=(Vector vector1, Vector vector2) {
            return vector1.size >= vector2.size;
        }

        public static bool operator <=(Vector vector1, Vector vector2) {
            return vector1.size <= vector2.size;
        }
    }
}
