using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp.src {
    class Matrix {
        protected int[,] IntArray;
        protected int n, m;
        protected int codeError;

        public int Rows => n;
        public int Columns => m;
        public int CodeError {
            get { return codeError; }
            set { codeError = value; }
        }

        public Matrix(int n = 1, int m = 1, int initializationValue = 0) {
            IntArray = new int[n, m];
            this.n = n;
            this.m = m;
            codeError = 0;
            InitializeArray(initializationValue);
        }

        ~Matrix() {
            Console.WriteLine("Destructor is called.");
        }

        private void InitializeArray(int value = 0) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    IntArray[i, j] = value;
                }
            }
        }

        public void InputValues() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    Console.Write($"Enter element [{i},{j}]: ");
                    IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void Display() {
            Console.WriteLine("Matrix elements:");
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    Console.Write($"{IntArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void AssignValue(int value) {
            InitializeArray(value);
        }

        public int this[int i, int j] {
            get {
                if (i < 0 || i >= n || j < 0 || j >= m) {
                    codeError = -1;
                    return 0;
                } else {
                    codeError = 0;
                    return IntArray[i, j];
                }
            }
            set {
                if (i >= 0 && i < n && j >= 0 && j < m) {
                    IntArray[i, j] = value;
                } else {
                    codeError = -1;
                }
            }
        }

        public int this[int k] {
            get {
                int i = k / m;
                int j = k % m;
                if (i < 0 || i >= n || j < 0 || j >= m) {
                    codeError = -1;
                    return 0;
                } else {
                    codeError = 0;
                    return IntArray[i, j];
                }
            }
            set {
                int i = k / m;
                int j = k % m;
                if (i >= 0 && i < n && j >= 0 && j < m) {
                    IntArray[i, j] = value;
                } else {
                    codeError = -1;
                }
            }
        }

        // Overload the equality operator ==
        public static bool operator ==(Matrix matrix1, Matrix matrix2) {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                return false;

            for (int i = 0; i < matrix1.Rows; i++) {
                for (int j = 0; j < matrix1.Columns; j++) {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }

            return true;
        }

        // Overload the inequality operator !=
        public static bool operator !=(Matrix matrix1, Matrix matrix2) {
            return !(matrix1 == matrix2);
        }

        public static Matrix operator ++(Matrix matrix) {
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    matrix.IntArray[i, j]++;
                }
            }
            return matrix;
        }

        public static Matrix operator --(Matrix matrix) {
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    matrix.IntArray[i, j]--;
                }
            }
            return matrix;
        }

        public static explicit operator bool(Matrix matrix) {
            foreach (int element in matrix.IntArray) {
                if (element == 0) {
                    return false;
                }
            }
            return true;
        }

        public static Matrix operator ~(Matrix matrix) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = ~matrix.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for addition.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] + matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] + scalar;
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for subtraction.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] - matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] - scalar;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for multiplication.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] * matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] * scalar;
                }
            }
            return result;
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for division.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] / matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator /(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] / scalar;
                }
            }
            return result;
        }

        public static Matrix operator %(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for integer division.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] % matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator %(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] % scalar;
                }
            }
            return result;
        }

        public static Matrix operator |(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for binary OR operator.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] | matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator |(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] | scalar;
                }
            }
            return result;
        }

        public static Matrix operator ^(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for XOR.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] ^ matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator ^(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] ^ scalar;
                }
            }
            return result;
        }

        public static Matrix operator <<(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for multiplication.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] << matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator <<(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] << scalar;
                }
            }
            return result;
        }

        public static Matrix operator >>(Matrix matrix1, Matrix matrix2) {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) {
                throw new ArgumentException("Matrices must have the same dimensions for multiplication.");
            }

            Matrix result = new Matrix(matrix1.n, matrix1.m);
            for (int i = 0; i < matrix1.n; i++) {
                for (int j = 0; j < matrix1.m; j++) {
                    result.IntArray[i, j] = matrix1.IntArray[i, j] >> matrix2.IntArray[i, j];
                }
            }
            return result;
        }

        public static Matrix operator >>(Matrix matrix, int scalar) {
            Matrix result = new Matrix(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++) {
                for (int j = 0; j < matrix.m; j++) {
                    result.IntArray[i, j] = matrix.IntArray[i, j] >> scalar;
                }
            }
            return result;
        }

        public static bool operator >(Matrix matrix1, Matrix matrix2) {
            return matrix1.Rows * matrix1.Columns > matrix2.Rows * matrix2.Columns;
        }

        public static bool operator <(Matrix matrix1, Matrix matrix2) {
            return matrix1.Rows * matrix1.Columns < matrix2.Rows * matrix2.Columns;
        }

        public static bool operator >=(Matrix matrix1, Matrix matrix2) {
            return matrix1.Rows * matrix1.Columns >= matrix2.Rows * matrix2.Columns;
        }

        public static bool operator <=(Matrix matrix1, Matrix matrix2) {
            return matrix1.Rows * matrix1.Columns <= matrix2.Rows * matrix2.Columns;
        }
    }
}
