using System;

namespace TA_LR4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph angola = new Graph();
            for (int i = 0; i < 14; i++)
            {
                for (int j = i + 1; j < 15; j++)
                {
                    angola.GreedySearch(i, j);
                }
            }
        }
    }
}