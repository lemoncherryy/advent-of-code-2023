using System.IO;

namespace day1;
class Program
{
    static string SearchAndReplaceTextRepresentations(string line)
    {
        string[] validStringNumbers = new string[10]{"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};;
        char[] modifiedLine = line.ToCharArray();
        int currentPositionThroughFind;
        int startingIndex;
        int index = 0;
        foreach (string numberToFind in validStringNumbers)
        {
            currentPositionThroughFind = 0;
            startingIndex = 0;
            foreach (char character in line)
            {
                if (character == numberToFind[currentPositionThroughFind])
                {
                    currentPositionThroughFind++;
                    if (currentPositionThroughFind == numberToFind.Length)
                    {
                        modifiedLine[startingIndex] = index.ToString()[0];
                        startingIndex += currentPositionThroughFind;
                        currentPositionThroughFind = 0;
                    }
                }
                else if (character == numberToFind[0])
                {
                    currentPositionThroughFind = 1;
                    startingIndex += currentPositionThroughFind + 1;
                }
                else
                {
                    startingIndex += currentPositionThroughFind + 1;
                    currentPositionThroughFind = 0;
                }
            }
            index++;
            
        }
        return new string(modifiedLine);
    }
    static void part1()
    {
        char[] validNumberCharacters = new char[10]{'1','2','3','4','5','6','7','8','9','0'};
        int total = 0;
        int currentNumber = 0;
        foreach(string line in File.ReadLines("input"))
        {
            foreach (char character in line)
            {
                if (validNumberCharacters.Contains(character))
                {
                    currentNumber = (int)Char.GetNumericValue(character) * 10;
                    break;
                }
            }
            foreach (char character in line.Reverse())
            {
                if (validNumberCharacters.Contains(character))
                {
                    currentNumber += (int)Char.GetNumericValue(character);
                    break;
                }
            }
            total += currentNumber;
        }
        Console.WriteLine(total);
    }

    static void part2()
    {
        char[] validNumberCharacters = new char[10]{'1','2','3','4','5','6','7','8','9','0'};
        int total = 0;
        int currentNumber = 0;
        foreach(string line in File.ReadLines("input"))
        {
            string modifiedLine = SearchAndReplaceTextRepresentations(line);
            foreach (char character in modifiedLine)
            {
                
                if (validNumberCharacters.Contains(character))
                {
                    currentNumber = (int)Char.GetNumericValue(character) * 10;
                    break;
                }
            }
            foreach (char character in modifiedLine.Reverse())
            {
                if (validNumberCharacters.Contains(character))
                {
                    currentNumber += (int)Char.GetNumericValue(character);
                    break;
                }
            }
            total += currentNumber;
        }
        Console.WriteLine(total);
    }
    
    static void Main(string[] args)
    {
        part1();
        part2();
    }
}