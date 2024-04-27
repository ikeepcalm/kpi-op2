#pragma warning disable CA1814
using System;

namespace MatrixLibrary
{
    public class MatrixException : Exception
    {
        public MatrixException()
        {
        }

        public MatrixException(string message) : base(message)
        {
        }

        public MatrixException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class Matrix : ICloneable
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get => Array.GetLength(0);
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get => Array.GetLength(1);
        }

        /// <summary>
        /// Gets an array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int rows, int columns)
        {
            if (rows < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rows));
            }
            
            if (columns < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columns));
            }
            
            Array = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Array[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="data">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix(double[,] data)
        {
            
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            Array = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Array[i, j] = data[i, j];
                }
            }
        }

        /// <summary>
        /// Allows instances of a Matrix to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException"></exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Array.GetLength(0) || column < 0 || column >= Array.GetLength(1))
                {
                    throw new ArgumentException("Invalid row or column index.");
                }

                return Array[row, column];
            }
            set
            {
                if (row < 0 || row >= Array.GetLength(0) || column < 0 || column >= Array.GetLength(1))
                {
                    throw new ArgumentException("Invalid row or column index.");
                }

                Array[row, column] = value;
            }
        }

        /// <summary>
        /// Creates a deep copy of this Matrix.
        /// </summary>
        /// <returns>A deep copy of the current object.</returns>
        public object Clone()
        {
            return new Matrix(Array);
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is sum of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }
            
            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }
            
            if (EligibleForSimpleOperators(matrix1, matrix2))
            {
                int rows = matrix1.Array.GetLength(0);
                int columns = matrix1.Array.GetLength(1);
                Matrix result = new Matrix(rows, columns);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result.Array[i, j] = matrix1.Array[i, j] + matrix2.Array[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new MatrixException("Matrices are not elibigle for simple operations.");
            }
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is subtraction of two matrices</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }
            
            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }
            
            if (EligibleForSimpleOperators(matrix1, matrix2))
            {
                int rows = matrix1.Array.GetLength(0);
                int columns = matrix1.Array.GetLength(1);
                Matrix result = new Matrix(rows, columns);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result.Array[i, j] = matrix1.Array[i, j] - matrix2.Array[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new MatrixException("Matrices are not convergenced.");
            }
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is multiplication of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException(nameof(matrix1));
            }
            
            if (matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix2));
            }
            
            if (!EligibleForMultiplication(matrix1, matrix2))
            {
                throw new MatrixException("Matrices are not eligible for multiplication.");
            }

            int rows = matrix1.Rows;
            int columns = matrix2.Columns;
            int innerDimension = matrix1.Columns;

            Matrix result = new Matrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < innerDimension; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            
            if (EligibleForSimpleOperators(this, matrix))
            {
                int rows = Array.GetLength(0);
                int columns = Array.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Array[i, j] = Array[i, j] + matrix.Array[i, j];
                    }
                }

                return this;
            }
            else
            {
                throw new MatrixException("Matrices are not convergenced.");
            }
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {
            
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            
            if (EligibleForSimpleOperators(this, matrix))
            {
                int rows = Array.GetLength(0);
                int columns = Array.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Array[i, j] = Array[i, j] - matrix.Array[i, j];
                    }
                }

                return this;
            }
            else
            {
                throw new MatrixException("Matrices are not convergenced.");
            }
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            
            if (!EligibleForMultiplication(this, matrix))
            {
                throw new MatrixException("Matrices are not eligible for multiplication.");
            }

            int rows = this.Rows;
            int columns = this.Columns;
            int innerDimension = this.Columns;

            Matrix result = new Matrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < innerDimension; k++)
                    {
                        sum += this[i, k] * matrix[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        /// <summary>
        /// Tests if <see cref="Matrix"/> is identical to this Matrix.
        /// </summary>
        /// <param name="obj">Object to compare with. (Can be null)</param>
        /// <returns>True if matrices are equal, false if are not equal.</returns>
        public override bool Equals(object obj)
        {
            Matrix matrix = obj as Matrix; 
            
            if (matrix == null || this.Rows !=  matrix.Rows || this.Columns != matrix.Columns)
            {
                return false;
            }

            int rows = this.Rows;
            int columns = this.Columns;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (this[i, j] != matrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode() => Array.GetHashCode();

        private static bool EligibleForSimpleOperators(Matrix origin, Matrix matrix)
        {
            return origin.Rows == matrix.Rows && origin.Columns == matrix.Columns;
        }

        private static bool EligibleForMultiplication(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Columns == matrix2.Rows;
        }
    }
}