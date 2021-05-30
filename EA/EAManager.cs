using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionaryAlgorithm
{
    public class EAManager
    {
        private static readonly int POPULATION_SIZE = 100, MAX_GENERATIONS = 100;
        private static readonly double CROSSOVER_RATE = 0.9, MUTATION_RATE = 0.05;

        public static void Main()
        {
            List<double> valueList;
            EvolutionaryAlgorithm evolutionaryAlgorithm = EvolutionaryAlgorithm.InitializeEAWithDefaultStrategies(
                POPULATION_SIZE, MAX_GENERATIONS, CROSSOVER_RATE, MUTATION_RATE
            );
            evolutionaryAlgorithm.Evolve();
            valueList = evolutionaryAlgorithm.bestFitnessPerGeneration;
            Plot(valueList);

        }

        private static void Plot(List<double> valueList)
        {
            var plt = new ScottPlot.Plot(800, 600);
            plt.AddScatter(Array.ConvertAll<int, double>(Enumerable.Range(0, MAX_GENERATIONS).ToArray(), x => x), valueList.ToArray());
            plt.Title("Best Fitness per Generation");
            plt.XLabel("Generation");
            plt.YLabel("Fitness");
            plt.SaveFig("generationFitness.png");
        }
    }
}