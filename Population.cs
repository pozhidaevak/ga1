using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ga1
{
    public class Population<T>
    {
        public delegate double Fitness(IChromosome<T> chromo);

        public Fitness fitness { get; set; }

        public IChromosome<T>[] Chromosomes { get; set; }

        public IMutation<T> Mutation { get; set; }

        public ICrossover<T> Crossover { get; set; }

        public ISelection<T> Selection1 { get; set; }

        public ISelection<T> Selection2 { get; set; }

        private double selectionK = 0.5;

        public double SelectionK
        {
            get
            {
                return selectionK;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("selectionK", selectionK, "selectionK must be in [0,1]");
                }
                else
                {
                    selectionK = value;
                }
            }
        }

        private double mutationProb;

        public double MutationProb
        {
            get
            {
                return mutationProb;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("MutationProb", MutationProb, "probability must be in [0,1]");
                }
                else
                {
                    mutationProb = value;
                }
            }
        }

        private double crossoverProb;

        public double CrossoverProb
        {
            get
            {
                return crossoverProb;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("CrossoverProb", CrossoverProb, "probability must be in [0,1]");
                }
                else
                {
                    crossoverProb = value;
                }
            }
        }

        public Population(IMutation<T> _mutation,
            ICrossover<T> _crossover, ISelection<T> _sel1, ISelection<T> _sel2, Population<T>.Fitness _fitness, double _mutationProb = 0.1, double _crossoverProb = 0.5, IChromosome<T>[] _chromo = null)
        {
            Crossover = _crossover;
            Mutation = _mutation;
            fitness = _fitness;
            MutationProb = _mutationProb;
            CrossoverProb = _crossoverProb;
            Selection1 = _sel1;
            Selection2 = _sel2;
            if (_chromo != null)
            {
                Chromosomes = _chromo;
            }
        }

        public void Generate(int chromoLength, int populationSize)
        {
            Chromosomes = new IChromosome<T>[populationSize];
            for (int i = 0; i < populationSize; ++i)
            {
                if (typeof(T) == typeof(int))
                {
                    Chromosomes[i] = (IChromosome<T>)new DigitalChromosome().Generate(chromoLength);
                }
            }
        }

        public IChromosome<T>[] Iteration()
        {
            //selection 1
            IChromosome<T>[] forSelection = Selection1.Select(Chromosomes, fitness, (int)(Math.Round(Chromosomes.Length * selectionK)));

            //crossover
            List<IChromosome<T>> childs = new List<IChromosome<T>>();
            for (int i = 0; i < forSelection.Length; ++i)
            {
                for (int j = i + 1; j < forSelection.Length; ++j)
                {
                    if (Program.rnd.NextDouble() <= crossoverProb)
                    {
                        Trace.WriteLine("Crossover: " + forSelection[i].ToString() + " with " + forSelection[j].ToString());
                        childs.AddRange(Crossover.Crossover(forSelection[i], forSelection[j]));
                        Trace.WriteLine("Children: " + childs[childs.Count - 2].ToString() + " and " + childs[childs.Count - 1].ToString());
                    }
                }
            }

            //children union with parents
            IChromosome<T>[] afterCrossover = new IChromosome<T>[Chromosomes.Length + childs.Count];
            Array.Copy(Chromosomes, afterCrossover, Chromosomes.Length);
            Array.Copy(childs.ToArray(), 0, afterCrossover, Chromosomes.Length, childs.Count);

            //mutation
            for (int i = 0; i < afterCrossover.Length; ++i)
            {
                if (Program.rnd.NextDouble() <= mutationProb)
                {
                    Trace.WriteLine("Mutate " + afterCrossover[i].ToString());
                    afterCrossover[i] = Mutation.Mutate(afterCrossover[i]);
                    Trace.WriteLine("Result " + afterCrossover[i].ToString());
                }
            }

            //selection2
            return Chromosomes = Selection2.Select(afterCrossover, fitness, Chromosomes.Length);
        }

        public double GetPopulationFitness()
        {
            return Chromosomes.Sum(x => fitness(x)) / Chromosomes.Length;
        }

        public double GetMaxFitness()
        {
            return Chromosomes.Max(x => fitness(x));
        }

        public string GetMaxChromo()
        {
            return Chromosomes.Where(x => fitness(x) == Chromosomes.Max(y => fitness(y))).ToArray()[0].ToString();
        }
    }
}