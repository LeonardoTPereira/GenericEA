namespace EvolutionaryAlgorithm
{
    public enum StopCriteriaStrategies
    {
        GenerationLimit
    }

    public interface StopCriteriaStrategyInterface
    {
        void UpdateStopCriteria();
        bool HasReachedStopCriteria();
    }
}