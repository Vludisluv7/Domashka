/*

int EnterNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[] InputArray(int length)
{
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = EnterNum($"Введите {i + 1} элемент: ");
    }
    return array;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.WriteLine($"a[{i}] = {array[i]}");
    }
}

int CortNum(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i] > 0)
        {
            count++;
        }
    }
    return count;
}

int length = EnterNum("Ведите количество элементов: ");
int[] array;
array = InputArray(length);
PrintArray(array);
System.Console.WriteLine($"Больше нуля {CortNum(array)}");
*/

using System.Net;
using System.Reflection.Metadata;

const int COEFFICIENT = 0;
const int CONSTANT = 1;
const int X_COORD = 0;
const int Y_COORD = 1;
const int LINE1 = 1;
const int LINE2 = 2;

double[] lineData1 = InputLineData(LINE1);
double[] lineData2 = InputLineData(LINE2);

if (ValidateLines(lineData1, lineData2))
{
    double[] coord = FindCoords(lineData1, lineData2);
    System.Console.WriteLine($"Точка пересечения уравнений y ={lineData1[COEFFICIENT]}*x+{lineData1[CONSTANT]} и y={lineData2[COEFFICIENT]}*x+{lineData2[CONSTANT]}");
    System.Console.WriteLine($" Имеет координаты ({coord[X_COORD]}, {coord[Y_COORD]} )");

}

double EnterNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

double[] InputLineData(int numberOfLine)
{
    double[] lineData = new double[2];
    lineData[COEFFICIENT] = EnterNum($"Введите коэффициент для {numberOfLine} прямой: ");
    lineData[CONSTANT] = EnterNum($"Введите константу для {numberOfLine} прямой: ");
    return lineData;
}

double[] FindCoords(double[] lineData1, double[] lineData2)
{
    double[] coord = new double[2];
    coord[X_COORD] = (lineData1[CONSTANT] - lineData2[CONSTANT]) / (lineData2[COEFFICIENT] - lineData1[COEFFICIENT]);
    coord[Y_COORD] = lineData1[CONSTANT] * coord[X_COORD] + lineData1[CONSTANT];
    return coord;
}

bool ValidateLines(double[] lineData1, double[] lineData2)
{
    if (lineData1[COEFFICIENT] == lineData2[COEFFICIENT])
    {
        if (lineData1[CONSTANT] == lineData2[CONSTANT])
        {
            System.Console.WriteLine("Прямые совпадают");
            return false;
        }
        else
        {
            System.Console.WriteLine("Прямые параллельны");
            return false;
        }
    }
    return true;
}