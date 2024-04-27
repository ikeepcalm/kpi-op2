namespace PrBx8;

public static class Interface
{
    public static int CreateLayout(string label, params string[] options)
    {
        const int startX = 2;
        const int startY = 6;
        const int optionsPerLine = 1;
        const int spacingPerLine = 20;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.Clear();

            Console.SetCursorPosition((Console.WindowWidth - label.Length) / 2, startY - 2);
            Console.WriteLine(label);

            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine,
                    startY + i / optionsPerLine * 2);

                if (i == currentSelection)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (currentSelection % optionsPerLine > 0)
                        currentSelection--;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (currentSelection % optionsPerLine < optionsPerLine - 1)
                        currentSelection++;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (currentSelection >= optionsPerLine)
                        currentSelection -= optionsPerLine;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (currentSelection + optionsPerLine < options.Length)
                        currentSelection += optionsPerLine;
                    break;
                }
            }
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
    }
}