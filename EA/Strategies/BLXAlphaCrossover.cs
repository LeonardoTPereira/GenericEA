namespace EvolutionaryAlgorithm
{
    class BLXAlphaCrossover : CrossoverStrategyInterface
    {
        private double alpha = 0.1;
        public Individual[] Crossover(Individual[] parents, double crossoverRate)
        {
            Individual[] children = new Individual[2];
            children[0] = new Individual();
            children[1] = new Individual();
            if (RandomSingleton.GetInstance().Random.NextDouble() < crossoverRate)
            {
                for (int currentGene = 0; currentGene < parents[0].Chromossome.Length; ++currentGene)
                {
                    double max, min, range;
                    double parent1Gene, parent2Gene;
                    parent1Gene = parents[0].Chromossome[currentGene];
                    parent2Gene = parents[1].Chromossome[currentGene];
                    if (parent1Gene > parent2Gene)
                    {
                        max = parent1Gene;
                        min = parent2Gene;
                    }
                    else
                    {
                        max = parent2Gene;
                        min = parent1Gene;
                    }
                    range = (max + alpha) - (min - alpha);
                    children[0].Chromossome[currentGene] = RandomSingleton.GetInstance().Random.NextDouble() * range + (min - alpha);
                    children[1].Chromossome[currentGene] = RandomSingleton.GetInstance().Random.NextDouble() * range + (min - alpha);
                }
            }
            else
            {
                children[0] = (Individual)parents[0].Clone();
                children[1] = (Individual)parents[1].Clone();
            }
            return children;
        }
    }
}