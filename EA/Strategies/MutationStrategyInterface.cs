namespace EvolutionaryAlgorithm
{
    public enum MutationStrategies
    {
        Random
    }
    public interface MutationStrategyInterface
    {
        void Mutate(Individual individual, double mutationRate);
    }
}