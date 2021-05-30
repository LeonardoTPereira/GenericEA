using System;
namespace EvolutionaryAlgorithm
{
    public class RandomMutationStrategy : MutationStrategyInterface
    {
        public void Mutate(Individual individual, double mutationRate)
        {
            for (int currentGene = 0; currentGene < individual.Chromossome.Length; ++currentGene)
            {
                if (RandomSingleton.GetInstance().Random.NextDouble() < mutationRate)
                {
                    individual.InitializeRandomGene(currentGene);
                }
            }
        }
    }
}