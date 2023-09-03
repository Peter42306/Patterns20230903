using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestingPatterns
{
    public interface ISortStrategy
    {
        void Sort(List<int> list);
    }
    public class AscendingSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            list.Sort();
            Console.WriteLine("Sort by ascending: " + string.Join(", ", list));
        }
    }

    public class DescendingSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            list.Sort();
            list.Reverse();
            Console.WriteLine("Sort be descending: " + string.Join(", ", list));
        }
    }
    public class Sorter
    {
        private ISortStrategy strategy;
        public Sorter(ISortStrategy strategy)
        {
            this.strategy = strategy;
        }
        public void SetStrategy(ISortStrategy strategy)
        {
            this.strategy = strategy;
        }
        public void SortList(List<int> list)
        {
            this.strategy.Sort(list);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 50, 2, 91, 45, 7, 19 };
            Sorter sorter = new Sorter(new AscendingSortStrategy());
            sorter.SortList(numbers);

            sorter.SetStrategy(new DescendingSortStrategy());
            sorter.SortList(numbers);

            numbers.Add(519);
            numbers.Add(876);
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }
    }
}
