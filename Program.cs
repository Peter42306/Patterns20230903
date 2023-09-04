using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestingPatterns
{
    public class MyArray
    {
        private int[] array;
        
        Random random=new Random();

        public MyArray(int minValue, int maxValue, int size)
        {
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
        }

        public void Show()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
        public int[] ToArray()
        {
            return array;
        }
    }

    public class MyArray2D
    {
        private int[,] array2D;

        Random random = new Random();
        public MyArray2D(int minValue, int maxValue, int rows, int columns)
        {
            array2D = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array2D[i, j] = random.Next(minValue, maxValue);
                }
            }
        }
        public void Show()
        {
            int rows=array2D.GetLength(0);
            int columns=array2D.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array2D[i, j]+" ");
                }
                Console.WriteLine();
            }
        }


        public int[] ToArray()
        {
            int rows = array2D.GetLength(0);
            int columns = array2D.GetLength(1);

            int[] flattenedArray = new int[rows * columns];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flattenedArray[index] = array2D[i, j];
                    index++;
                }
            }

            return flattenedArray;
        }

    }

    // Общий интерфейс для всех стратегий
    public interface IStrategySorting
    {
        void Sort(int[] myArray);
    }

    public interface IStrategyArithmaticOps
    {
        void ArithmaticOp(int[] myArray);
    }

    // Каждая конкретная стратегия реализует общий интерфейс своим способом
    public class ConcreteSortingAscending : IStrategySorting
    {
        public void Sort(int[] myArray)
        {
            Array.Sort(myArray);
        }
    }
    public class ConcreteSortingDescending : IStrategySorting
    {
        public void Sort(int[] myArray)
        {
            Array.Sort(myArray);
            Array.Reverse(myArray);
        }
    }    

    // Контекст
    public class ContextSorting
    {
        private IStrategySorting sortingStrategy;
        public ContextSorting(IStrategySorting sortingStrategy)
        {
            this.sortingStrategy = sortingStrategy;
        }
        public void SetSortingStrategy(IStrategySorting sortingStrategy)
        {
            this.sortingStrategy = sortingStrategy;
        }
        public void Sorting(int[] myArray)
        {
            this.sortingStrategy.Sort(myArray);
        }        
    }    

    internal class Program
    {
        static void Main(string[] args)
        {
            MyArray array1 = new MyArray(100, 999, 100);
            Console.WriteLine("Array 1d:");
            array1.Show();
            Console.WriteLine();            

            Console.WriteLine();
            ContextSorting contextSorting=new ContextSorting(new ConcreteSortingAscending());
            contextSorting.Sorting(array1.ToArray());
            Console.WriteLine("Array 1d, ascended:");
            array1.Show();
            Console.WriteLine();

            contextSorting.SetSortingStrategy(new ConcreteSortingDescending());
            contextSorting.Sorting(array1.ToArray());
            Console.WriteLine("Array 1d: descended:");
            array1.Show();
            Console.WriteLine();

            MyArray2D array2 = new MyArray2D(100, 999, 10, 50);
            Console.WriteLine("Array 2d:");
            array2.Show();            
        }
    }
}
