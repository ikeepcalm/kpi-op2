using System.Collections;

namespace ShortList;

public class ShortList : IEnumerable
{
    private class Node
    {
        public short Value { get; set; }
        public Node? Next { get; set; }

        public Node(short value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _head;
    private int _count;

    public ShortList(params short[] contents)
    {
        _head = null;
        _count = 0;
        AddRange(contents);
    }

    public void Add(short item)
    {
        Node? newNode = new Node(item);
        newNode.Next = _head;
        _head = newNode;
        _count++;
    }

    public void AddRange(params short[] items)
    {
        foreach (short item in items)
        {
            Add(item);
        }
    }

    public short? FindDivisibleByThree()
    {
        Node? current = _head;
        while (current != null)
        {
            if (current.Value % 3 == 0)
            {
                return current.Value;
            }
            current = current.Next;
        }
        return null;
    }

    public short[] GetDivisibleByThree()
    {
        short[] divisible = new short[_count];
        Node? current = _head;
        int index = 0;
        while (current != null)
        {
            if (current.Value % 3 == 0)
            {
                divisible[index] = current.Value;
                ++index;
            }
            current = current.Next;
        }
        Array.Resize(ref divisible, index);
        return divisible;
    }

    public double FindMultiplicationOfLessThanMedium()
    {
        double medium = FindMedium();

        double multiplication = 1;
        Node? current = _head;
        while (current != null)
        {
            if (current.Value < medium && current.Value != 0)
            {
                multiplication *= current.Value;
            }
            current = current.Next;
        }
        return multiplication;
    }

    public void DeleteElementsGreaterThanMedium()
    {
        double medium = FindMedium();
        Node? previous = null;
        Node? current = _head;

        while (current != null)
        {
            if (current.Value > medium)
            {
                if (previous == null)
                {
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                
                current = current.Next;
            }
            else
            {
                previous = current;
                current = current.Next;
            }
        }
    }


    public void WriteOut()
    {
        Console.Write("[");
        Node? current = _head;
        while (current != null)
        {
            Console.Write(current.Value);
            if (current.Next != null)
            {
                Console.Write(", ");
            }
            current = current.Next;
        }
        Console.WriteLine("]");
    }

    private double FindMedium()
    {
        if (_count == 0)
            return 0;

        double medium = 0;
        int amount = 0;

        Node? current = _head;
        while (current != null)
        {
            if (current.Value != 0)
            {
                medium += current.Value;
                amount++;
            }
            current = current.Next;
        }

        return medium / amount;
    }
    
    public IEnumerator<short> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}