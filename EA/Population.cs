namespace EvolutionaryAlgorithm
{
    public class Population
    {
        protected Individual[] currentPopulation, intermediatePopulation;

        public Individual[] CurrentPopulation { get => currentPopulation; set => currentPopulation = value; }
        public Individual[] IntermediatePopulation { get => intermediatePopulation; set => intermediatePopulation = value; }

        public Population(int populationSize)
        {
            currentPopulation = new Individual[populationSize];
            intermediatePopulation = new Individual[populationSize];
        }

        public void Initialize()
        {
            for (int currentIndividual = 0; currentIndividual < currentPopulation.Length; ++currentIndividual)
            {
                currentPopulation[currentIndividual] = new Individual();
                currentPopulation[currentIndividual].calculateFitness();
            }
        }
    }

}
