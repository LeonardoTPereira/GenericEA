namespace EvolutionaryAlgorithm
{
    public class GenerationLimitStopCriteriaStrategy : StopCriteriaStrategyInterface
    {
        int actualGeneration, maxGenerations;

        public GenerationLimitStopCriteriaStrategy(int maxGenerations)
        {
            actualGeneration = 0;
            this.maxGenerations = maxGenerations;
        }

        public bool HasReachedStopCriteria()
        {
            return actualGeneration >= maxGenerations;
        }

        public void UpdateStopCriteria()
        {
            actualGeneration++;
            //Debug.Log("Generation: " + actualGeneration);
        }
    }
}