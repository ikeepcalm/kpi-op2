namespace Class
{
    class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            this.sideA = a;
            this.sideB = b;
        }

        public Rectangle(double a)
        {
            this.sideA = a;
            this.sideB = 5;
        }

        public Rectangle()
        {
            this.sideA = 4;
            this.sideB = 3;
        }

        public double GetSideA()
        {
            return this.sideA;
        }

        public double GetSideB()
        {
            return this.sideB;
        }

        public double Area()
        {
            return this.sideA * this.sideB;
        }

        public double Perimeter()
        {
            return 2 * (this.sideA + this.sideB);
        }

        public bool IsSquare()
        {
            return sideA.Equals(sideB);
        }

        public void ReplaceSides()
        {
            (this.sideA, this.sideB) = (this.sideB, this.sideA);
        }
    }


    class ArrayRectangles
    {
        private Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            this.rectangle_array = new Rectangle[n];
        }

        public bool AddRectangle(Rectangle rectangle) {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rectangle;
                    return true;
                }
            } return false;
        }

        public int NumberMaxArea()
        {
            double maxArea = 0;
            int maxAreaIndex = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null)
                {
                    if (rectangle_array[i].Area() > maxArea)
                    {
                        maxArea = rectangle_array[i].Area();
                        maxAreaIndex = i;
                    }
                }
            }

            return maxAreaIndex;
        }

        public int NumberMinPerimeter()
        {
            double minPerimeter = double.MaxValue;
            int minPerimeterIndex = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null)
                {
                    if (rectangle_array[i].Perimeter() < minPerimeter)
                    {
                        minPerimeter = rectangle_array[i].Perimeter();
                        minPerimeterIndex = i;
                    }
                }
            }

            return minPerimeterIndex;
        }

        public int NumberSquare()
        {
            int squareCount = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null)
                {
                    if (rectangle_array[i].IsSquare())
                    {
                        squareCount++;
                    }
                }
            }

            return squareCount;
        }
    }
}