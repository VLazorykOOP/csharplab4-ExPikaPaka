using System;
using Lab4CSharp.src;
namespace Lab4CSharp {
    internal class Program {
        static void Main(string[] args) {
            int number = 1;

            while (number != 0) {
                Console.Write("Input task number [1-3], [0] to exit: ");

                try {
                    string? input = Console.ReadLine();

                    if (input != null) {
                        number = int.Parse(input);

                        switch (number) {
                            case 0:
                                return;

                            case 1:
                                task1(); // Testing task 1
                                break;

                            case 2:
                                task2(); // Testing task
                                break;

                            case 3:
                                task3(); // Testing task 3

                                break;

                            default:
                                break;
                        }
                    } else {
                        Console.WriteLine("Nothing provided. Exiting...");
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine();
            }
        }

        static void task1() {
            Console.WriteLine("|===~        Testing task 1.1        ~===|");

            Point point = new Point(3, 4);
            Console.WriteLine("Original Point:");
            point.Show();

            Console.WriteLine("\nIndexer Usage:");
            Console.WriteLine($"x = {point[0]}, y = {point[1]}, color = {point[2]}");

            Console.WriteLine("\nIncrementing Point:");
            point++;
            point.Show();

            Console.WriteLine("\nDecrementing Point:");
            point--;
            point.Show();

            Console.WriteLine("\nTesting true and false operators:");
            Console.WriteLine($"Is point.x equal to point.y? {(bool)point}");

            Console.WriteLine("\nAdding scalar value to Point:");
            point = point + 5;
            point.Show();

            Console.WriteLine("\nConverting Point to string:");
            string pointStr = (string)point;
            Console.WriteLine(pointStr);

            Console.WriteLine("\nConverting string to Point:");
            Point newPoint = (Point)pointStr;
            newPoint.Show();
        }

        static void task2() {
            Console.WriteLine("|===~        Testing task 2.1        ~===|");

            // Create vectors
            Vector v1 = new Vector(3, 1); // Vector with all elements initialized to 1
            Vector v2 = new Vector(3, 2); // Vector with all elements initialized to 2

            // Input vector
            Vector input = new Vector(3);
            input.InputValues();
            input.Display();

            // Display original vectors
            Console.WriteLine("Original vectors:");
            v1.Display();
            v2.Display();

            // Test addition operator (+)
            Vector sum = v1 + v2;
            Console.WriteLine("\nAddition of v1 and v2:");
            sum.Display();

            // Test addition operator with scalar
            sum = v1 + 5;
            Console.WriteLine("\nAddition of scalar (5) to v1:");
            sum.Display();

            // Test subtraction operator (-)
            Vector diff = v1 - v2;
            Console.WriteLine("\nSubtraction of v2 from v1:");
            diff.Display();

            // Test subtraction operator with scalar
            diff = v1 - 3;
            Console.WriteLine("\nSubtraction of scalar (3) from v1:");
            diff.Display();

            // Test unary increment operator (++)
            Vector incremented = ++v1;
            Console.WriteLine("\nIncrementing v1:");
            incremented.Display();

            // Test unary decrement operator (--)
            Vector decremented = --v1;
            Console.WriteLine("\nDecrementing v1:");
            decremented.Display();

            // Test bitwise complement operator (~)
            Vector complemented = ~v1;
            Console.WriteLine("\nBitwise complement of v1:");
            complemented.Display();

            // Test multiplication operator (*)
            Vector product = v1 * v2;
            Console.WriteLine("\nElement-wise multiplication of v1 and v2:");
            product.Display();

            // Test multiplication operator with scalar
            product = v1 * 3;
            Console.WriteLine("\nMultiplication of v1 by scalar (3):");
            product.Display();

            // Test division operator (/)
            Vector divisionResult = v1 / v2;
            Console.WriteLine("\nElement-wise division of v1 by v2:");
            divisionResult.Display();

            // Test division operator with scalar
            divisionResult = v1 / 2;
            Console.WriteLine("\nDivision of v1 by scalar (2):");
            divisionResult.Display();

            // Test modulus operator (%)
            Vector modulusResult = v1 % v2;
            Console.WriteLine("\nElement-wise modulus of v1 by v2:");
            modulusResult.Display();

            // Test modulus operator with scalar
            modulusResult = v1 % 2;
            Console.WriteLine("\nModulus of v1 by scalar (2):");
            modulusResult.Display();

            // Test logical OR operator (|)
            Vector orResult = v1 | v2;
            Console.WriteLine("\nElement-wise bitwise OR of v1 and v2:");
            orResult.Display();

            // Test logical OR operator with scalar
            orResult = v1 | 3;
            Console.WriteLine("\nBitwise OR of v1 with scalar (3):");
            orResult.Display();

            // Test logical XOR operator (^)
            Vector xorResult = v1 ^ v2;
            Console.WriteLine("\nElement-wise bitwise XOR of v1 and v2:");
            xorResult.Display();

            // Test logical XOR operator with scalar
            xorResult = v1 ^ 3;
            Console.WriteLine("\nBitwise XOR of v1 with scalar (3):");
            xorResult.Display();

            // Test right shift operator (>>)
            Vector rightShiftResult = v1 >> v2;
            Console.WriteLine("\nElement-wise right shift of v1 by v2:");
            rightShiftResult.Display();

            // Test right shift operator with scalar
            rightShiftResult = v1 >> 1;
            Console.WriteLine("\nRight shift of v1 by scalar (1):");
            rightShiftResult.Display();

            // Test left shift operator (<<)
            Vector leftShiftResult = v1 << v2;
            Console.WriteLine("\nElement-wise left shift of v1 by v2:");
            leftShiftResult.Display();

            // Test left shift operator with scalar
            leftShiftResult = v1 << 1;
            Console.WriteLine("\nLeft shift of v1 by scalar (1):");
            leftShiftResult.Display();

            // Test equality operator (==)
            Console.WriteLine($"\nIs v1 equal to v2? {v1 == v2}");

            // Test inequality operator (!=)
            Console.WriteLine($"Is v1 not equal to v2? {v1 != v2}");

            // Test greater than operator (>)
            Console.WriteLine($"Is v1 greater than v2? {v1 > v2}");

            // Test greater than or equal to operator (>=)
            Console.WriteLine($"Is v1 greater than or equal to v2? {v1 >= v2}");

            // Test less than operator (<)
            Console.WriteLine($"Is v1 less than v2? {v1 < v2}");

            // Test less than or equal to operator (<=)
            Console.WriteLine($"Is v1 less than or equal to v2? {v1 <= v2}");
        }

        static void task3() {
            Console.WriteLine("|===~        Testing task 3.1        ~===|");

            // Create two matrices
            Matrix matrix1 = new Matrix(2, 3, 1);
            Matrix matrix2 = new Matrix(2, 3, 2);

            Matrix matrixInput = new Matrix(2, 2);
            matrixInput.InputValues();
            matrixInput.Display();

            // Display initial matrices
            Console.WriteLine("Initial Matrices:");
            Console.WriteLine("Matrix 1:");
            matrix1.Display();
            Console.WriteLine("Matrix 2:");
            matrix2.Display();

            // Test unary operations
            Console.WriteLine("\nTesting Unary Operations:");
            Console.WriteLine("Matrix 1 (After increment):");
            (++matrix1).Display();
            Console.WriteLine("Matrix 2 (After decrement):");
            (--matrix2).Display();

            // Test binary operations
            Console.WriteLine("\nTesting Binary Operations:");
            Console.WriteLine("Matrix 1 + Matrix 2:");
            (matrix1 + matrix2).Display();
            Console.WriteLine("Matrix 1 - Matrix 2:");
            (matrix1 - matrix2).Display();
            Console.WriteLine("Matrix 1 * Matrix 2:");
            (matrix1 * matrix2).Display();
            Console.WriteLine("Matrix 1 / Matrix 2:");
            (matrix1 / matrix2).Display();
            Console.WriteLine("Matrix 1 % Matrix 2:");
            (matrix1 % matrix2).Display();
            Console.WriteLine("Matrix 1 | Matrix 2:");
            (matrix1 | matrix2).Display();
            Console.WriteLine("Matrix 1 ^ Matrix 2:");
            (matrix1 ^ matrix2).Display();
            Console.WriteLine("Matrix 1 << Matrix 2:");
            (matrix1 << matrix2).Display();
            Console.WriteLine("Matrix 1 >> Matrix 2:");
            (matrix1 >> matrix2).Display();

            // Test comparison operators
            Console.WriteLine("\nTesting Comparison Operators:");
            Console.WriteLine($"Matrix 1 > Matrix 2: {matrix1 > matrix2}");
            Console.WriteLine($"Matrix 1 < Matrix 2: {matrix1 < matrix2}");
            Console.WriteLine($"Matrix 1 >= Matrix 2: {matrix1 >= matrix2}");
            Console.WriteLine($"Matrix 1 <= Matrix 2: {matrix1 <= matrix2}");

            // Test type conversion
            Console.WriteLine("\nTesting Type Conversion:");
            Console.WriteLine($"Matrix 1 is bool: {(bool)matrix1}");
            Console.WriteLine($"Matrix 2 is bool: {(bool)matrix2}");

            // Test bitwise negation
            Console.WriteLine("\nTesting Bitwise Negation:");
            Console.WriteLine("Bitwise Negation of Matrix 1:");
            (~matrix1).Display();
            Console.WriteLine("Bitwise Negation of Matrix 2:");
            (~matrix2).Display();
        }
    }
}
