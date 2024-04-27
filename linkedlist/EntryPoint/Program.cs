
Console.WriteLine("======= ADD METHOD ========");
TestAdd();
Console.WriteLine("===== FIRST DIVISIBLE =====");
TestFirstDivisible();
Console.WriteLine("===== ALL DIVISIBLE =======");
TestDivisible();
Console.WriteLine("===== MULTIPLICATION ======");
TestMultiplication();
Console.WriteLine("======== DELETION =========");
TestDelete();
Console.WriteLine("======= ENUMERATOR ========");
ShortList.ShortList shortList = new ShortList.ShortList(1, 2, 3, 4, 5, 6);
Console.WriteLine("Original list:");
shortList.WriteOut();
Console.WriteLine("Iterating through list using foreach:");
foreach (short element in shortList)
{
    Console.Write(element + " ");
}


void TestAdd()
{
    ShortList.ShortList shortList = new ShortList.ShortList(0, 0, 0, 0, 0);
    Console.WriteLine("Original list:");
    shortList.WriteOut();
    Console.WriteLine("Adding 3:");
    shortList.Add(3);
    shortList.WriteOut();
    Console.WriteLine("Adding 6:");
    shortList.Add(6);
    shortList.WriteOut();
}

void TestFirstDivisible()
{
    ShortList.ShortList shortList = new ShortList.ShortList(1, 2, 3, 4, 5, 6);
    Console.WriteLine("Original list:");
    shortList.WriteOut();
    short? result = shortList.FindDivisibleByThree();
    Console.Write("First divisible by 3: ");
    Console.WriteLine(result);
}

void TestDivisible()
{
    ShortList.ShortList shortList = new ShortList.ShortList(1, 2, 3, 4, 5, 6);
    Console.WriteLine("Original list:");
    short[] result = shortList.GetDivisibleByThree();
    Console.Write("All divisible by 3: ");
    Console.Write("[");
    for (int i = 0; i < result.Length; i++)
    {
        Console.Write(result[i]);
        if (i < result.Length - 1 && result[i] != 0)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine("]");
}

void TestMultiplication()
{
    ShortList.ShortList shortList = new ShortList.ShortList(1, 2, 3, 4, 5, 6);
    Console.WriteLine("Original list:");
    double result = shortList.FindMultiplicationOfLessThanMedium();
    Console.Write("Multiplication of elements less than medium: ");
    Console.WriteLine(result);
}

void TestDelete()
{
    ShortList.ShortList shortList = new ShortList.ShortList(1, 8, 3, 10, 5, 6);
    Console.WriteLine("Original list:");
    shortList.WriteOut();
    shortList.DeleteElementsGreaterThanMedium();
    Console.WriteLine("After deletion:");
    shortList.WriteOut();
}