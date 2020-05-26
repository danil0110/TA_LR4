using System;
using System.Collections.Generic;
using System.Linq;

namespace TA_LR4
{
    public class Graph
    {
        private string[] cities =
        {
            "Луанда", "Луена", "Лубанго", "Уамбо", "Сумбе", "Намибе", "Лобиту", "Кабинда", "Сойо",
            "Сауримо", "Лукапа", "Уиже", "Бенгела", "Кашито", "Кубал"
        };

        private int[,] distances = 
        {
            {0, 798, 678, 517, 274, 718, 397, 379, 314, 790, 824, 242, 419, 54, 483},
            {798, 0, 772, 463, 660, 920, 691, 1090, 1036, 241, 381, 704, 709, 768, 628},
            {678, 772, 0, 338, 413, 151, 282, 1047, 983, 946, 1063, 830, 259, 703, 222},
            {517, 463, 338, 0, 270, 472, 241, 890, 825, 613, 727, 578, 253, 518, 165},
            {274, 660, 413, 270, 0, 481, 133, 653, 588, 735, 813, 422, 161, 293, 208},
            {718, 920, 151, 472, 481, 0, 349, 1071, 1007, 1085, 1197, 902, 320, 752, 330},
            {397, 691, 282, 241, 133, 349, 0, 773, 708, 804, 898, 554, 29, 421, 105},
            {379, 1090, 1047, 890, 653, 1071, 773, 0, 66, 1012, 995, 390, 792, 372, 860},
            {314, 1036, 983, 825, 588, 1007, 708, 66, 0, 967, 958, 341, 727, 307, 795},
            {790, 241, 946, 613, 735, 1085, 804, 1012, 967, 0, 140, 629, 828, 749, 768},
            {824, 381, 1063, 727, 813, 1197, 898, 995, 958, 140, 0, 632, 925, 779, 874},
            {242, 704, 830, 578, 422, 902, 554, 390, 341, 629, 632, 0, 585, 189, 612},
            {419, 709, 259, 253, 161, 320, 29, 792, 727, 828, 925, 585, 0, 446, 104},
            {54, 768, 703, 518, 293, 752, 421, 372, 307, 749, 779, 189, 446, 0, 500},
            {483, 628, 222, 165, 208, 330, 105, 860, 795, 768, 874, 612, 104, 500, 0}
        };

        private int[,] mSmezh =
        {
            {0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0},
            {1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0},
            {0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1},
            {1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1},
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
            {1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
            {1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0},
            {1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
            {1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0},
            {1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0},
            {0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0}
        };

        public void OutputTable()
        {
            Console.Write($"{" ",8}");
            for (int i = 0; i < 15; i++)
            {
                Console.Write($"{cities[i], 8}");
            }
            Console.WriteLine();
            for (int i = 0; i < 15; i++)
            {
                Console.Write($"{cities[i], 8}");
                for (int j = 0; j < 15; j++)
                {
                    Console.Write($"{distances[i, j], 8}");
                }
                Console.WriteLine();
            }
        }

        public void GreedySearch(int start, int finish)
        {
            int[] finishDistances = new int[15];
            for (int i = 0; i < 15; i++)
            {
                finishDistances[i] = distances[i, finish];
            }

            int result = 0;
            bool[] visited = new bool[15];
            List<int> path = new List<int> {start};
            List<string> citiesPath = new List<string> {cities[start]};
            visited[start] = true;

            while (path.Last() != finish)
            {
                int min = -1, minCity = 0;
                for (int i = 0; i < 15; i++)
                {
                    if (mSmezh[path.Last(), i] == 1 && !visited[i])
                        if (min == -1)
                        {
                            min = finishDistances[i];
                            minCity = i;
                        }
                        else if (min > finishDistances[i])
                        {
                            min = finishDistances[i];
                            minCity = i;
                        }

                }
                
                result += distances[path.Last(), minCity];
                path.Add(minCity);
                citiesPath.Add(cities[minCity]);
                visited[minCity] = true;
                
            }
            
            Console.Write($"{cities[start]}-{cities[finish]}, Расстояние: {result}км, Маршрут: ");
            Console.WriteLine(String.Join(" -> ", citiesPath));

        }
        
    }
}