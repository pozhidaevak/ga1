using System;
using System.Linq;

namespace ga1
{
    public class GreedyCrossover : ICrossover<int>
    {
        public GreedyCrossover(int point1, int point2, int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("matrix", matrix, "matrix must be square");
            }
            this.matrix = matrix;
            this.point1 = point1;
            this.point2 = point2;
        }

        public IChromosome<int>[] Crossover(IChromosome<int> father, IChromosome<int> mother)
        {
            //Checking input variables
            CrossoverTools.CheckChromosomes(father, mother);
            CrossoverTools.CheckPoint(ref point1, matrix.GetLength(0) + 1);
            CrossoverTools.CheckPoint(ref point2, matrix.GetLength(0) + 1);
            if (father.Length != matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("matrix and chromosome must have equal length");
            }

            //cast partents to arrays
            int[] fatherArr = father.ToArray();
            int[] motherArr = mother.ToArray();

            //check uniqueness
            if (!Enumerable.SequenceEqual(fatherArr, fatherArr.Distinct()) ||
            !Enumerable.SequenceEqual(motherArr, motherArr.Distinct()))
            {
                throw new ArgumentOutOfRangeException("father", father, "order crossover works only with unique chromosomes");
            }

            //check for equality of gen sets
            if (!Enumerable.SequenceEqual(fatherArr.OrderBy(x => x), motherArr.OrderBy(x => x)))
            {
                throw new ArgumentOutOfRangeException("father", father, "sets of gens in mother and father aren't equal");
            }

            //initialaize children
            int[] child1 = new int[father.Length];
            int[] child2 = new int[father.Length];

            child1 = BuildChild(child1, point1, fatherArr, motherArr);
            child2 = BuildChild(child2, point2, fatherArr, motherArr);

            //Form children array and return it
            IChromosome<int>[] childArray = new IChromosome<int>[2] { ((IChromosome<int>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
            ((IChromosome<int>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }

        public double CalcFitness(IChromosome<int> chromo)
        {
            int[] gens = chromo.ToArray();
            int res = 0;
            for (int i = 0; i < gens.Length - 1; ++i)
            {
                res += matrix[gens[i] - 1, gens[i + 1] - 1];
            }
            return res;
        }

        private int[] BuildChild(int[] child, int point, int[] father, int[] mother)
        {
            child[0] = point;
            int fatherInd = -1;
            int motherInd = -1;
            int nextCandidate = -1;
            for (int i = 1; i < father.Length; ++i)
            {
                fatherInd = (Array.FindIndex(father, x => x == child[i - 1]) + 1) % father.Length;
                motherInd = (Array.FindIndex(mother, x => x == child[i - 1]) + 1) % mother.Length;
                nextCandidate = matrix[child[i - 1] - 1, father[fatherInd] - 1] <= matrix[child[i - 1] - 1, mother[motherInd] - 1] ? father[fatherInd] : mother[motherInd];
                if (child.Take(i).Contains(nextCandidate))
                {
                    nextCandidate = 0;
                    do
                    {
                        nextCandidate = Program.rnd.Next(1, father.Length + 1);
                        //++nextCandidate;
                    } while (child.Take(i).Contains(nextCandidate));
                }
                child[i] = nextCandidate;
            }
            return child;
        }

        private int point1, point2;

        public int Point1
        {
            get
            {
                return point1;
            }
        }

        public int Point2
        {
            get
            {
                return point2;
            }
        }

        private int[,] matrix;

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
            set
            {
                matrix = value;
            }
        }
    }
}