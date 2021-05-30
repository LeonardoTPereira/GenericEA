namespace EvolutionaryAlgorithm
{
    public enum SelectionStrategies
    {
        Tournament
    }
    public interface SelectionStrategyInterface
    {
        Individual Selection(Population population);
    }
}