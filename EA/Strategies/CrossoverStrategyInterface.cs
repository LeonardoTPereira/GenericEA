using System.Collections.Generic;

namespace EvolutionaryAlgorithm
{
    public enum CrossoverStrategies
    {
        BLXAlpha
    }
    public interface CrossoverStrategyInterface
    {
        Individual[] Crossover(Individual[] parents, double crossoverRate);
    }

}