using System;
namespace EvolutionaryAlgorithm
{
    class TournamentSelection : SelectionStrategyInterface
    {
        public Individual Selection(Population population)
        {
            Individual[] contestants = new Individual[2];
            int contestantIndex = RandomSingleton.GetInstance().Random.Next(population.CurrentPopulation.Length);
            contestants[0] = population.CurrentPopulation[contestantIndex];
            int contestant2Index;
            do
            {
                contestant2Index = RandomSingleton.GetInstance().Random.Next(population.CurrentPopulation.Length);
            }
            while (contestantIndex == contestant2Index);
            contestants[1] = population.CurrentPopulation[contestant2Index];
            return (contestants[0].Fitness < contestants[1].Fitness) ? contestants[0] : contestants[1];
        }
    }
}