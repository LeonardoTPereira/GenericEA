using System.Collections.Generic;

namespace EvolutionaryAlgorithm
{
    public class EvolutionaryAlgorithm
    {
        protected SelectionStrategyInterface selectionStrategy;
        protected CrossoverStrategyInterface crossoverStrategy;
        protected MutationStrategyInterface mutationStrategy;
        protected StopCriteriaStrategyInterface stopCriteriaStrategy;

        protected Population population;
        protected double crossoverRate, mutationRate;
        public List<double> bestFitnessPerGeneration;

        public void Evolve()
        {
            do
            {
                Individual[] selectedParents = Select();
                Crossover(selectedParents);
                Mutate();
                CalculateFitness();
                Replace();
                stopCriteriaStrategy.UpdateStopCriteria();
                SaveBestIndividualInList();
            } while (!stopCriteriaStrategy.HasReachedStopCriteria());
        }

        protected Individual[] Select()
        {
            Individual[] parents = new Individual[population.CurrentPopulation.Length];
            for (int currentIndividualIndex = 0; currentIndividualIndex < population.CurrentPopulation.Length; ++currentIndividualIndex)
            {
                parents[currentIndividualIndex] = selectionStrategy.Selection(population);
            }
            return parents;
        }

        private void Crossover(Individual[] selectedParents)
        {
            Individual[] currentParents = new Individual[2];
            Individual[] currentChildren;
            for (int currentIndividualIndex = 0; currentIndividualIndex < population.CurrentPopulation.Length / 2; ++currentIndividualIndex)
            {
                currentParents[0] = selectedParents[2 * currentIndividualIndex];
                currentParents[1] = selectedParents[2 * currentIndividualIndex + 1];
                currentChildren = crossoverStrategy.Crossover(currentParents, crossoverRate);
                population.IntermediatePopulation[currentIndividualIndex * 2] = currentChildren[0];
                population.IntermediatePopulation[currentIndividualIndex * 2 + 1] = currentChildren[1];
            }
        }

        private void Mutate()
        {
            for (int currentIndividualIndex = 0; currentIndividualIndex < population.CurrentPopulation.Length; ++currentIndividualIndex)
            {
                mutationStrategy.Mutate(population.IntermediatePopulation[currentIndividualIndex], mutationRate);
            }
        }

        private void CalculateFitness()
        {
            for (int currentIndividualIndex = 0; currentIndividualIndex < population.CurrentPopulation.Length; ++currentIndividualIndex)
            {
                population.IntermediatePopulation[currentIndividualIndex].calculateFitness();
            }
        }

        private void Replace()
        {
            for (int currentIndividualIndex = 0; currentIndividualIndex < population.CurrentPopulation.Length; ++currentIndividualIndex)
            {
                population.CurrentPopulation[currentIndividualIndex] = population.IntermediatePopulation[currentIndividualIndex];
            }
        }

        public void SetSelectionStrategy(SelectionStrategyInterface selectionStrategy)
        {
            this.selectionStrategy = selectionStrategy;
        }

        public void SetCrossoverStrategy(CrossoverStrategyInterface crossoverStrategy)
        {
            this.crossoverStrategy = crossoverStrategy;
        }

        public void SetMutationStrategy(MutationStrategyInterface mutationStrategy)
        {
            this.mutationStrategy = mutationStrategy;
        }

        public void SetStopCriteriaStrategy(StopCriteriaStrategyInterface stopCriteriaStrategy)
        {
            this.stopCriteriaStrategy = stopCriteriaStrategy;
        }

        public void SaveBestIndividualInList()
        {
            Individual bestIndividual;
            bestIndividual = population.CurrentPopulation[0];
            for (int currentIndividualIndex = 1; currentIndividualIndex < population.CurrentPopulation.Length; ++currentIndividualIndex)
            {
                if (bestIndividual.Fitness > population.CurrentPopulation[currentIndividualIndex].Fitness)
                    bestIndividual = population.CurrentPopulation[currentIndividualIndex];
            }
            bestFitnessPerGeneration.Add(bestIndividual.Fitness);
        }

        private EvolutionaryAlgorithm() {
            bestFitnessPerGeneration = new List<double>();
        }

        public static EvolutionaryAlgorithm InitializeEAWithDefaultStrategies(int popSize, int maxGenerations, double crossoverRate, double mutationRate)
        {
            EvolutionaryAlgorithm evolutionaryAlgorithm = new EvolutionaryAlgorithm
            {
                population = new Population(popSize),
                crossoverRate = crossoverRate,
                mutationRate = mutationRate,
                selectionStrategy = new TournamentSelection(),
                crossoverStrategy = new BLXAlphaCrossover(),
                mutationStrategy = new RandomMutationStrategy(),
                stopCriteriaStrategy = new GenerationLimitStopCriteriaStrategy(maxGenerations)
            };
            evolutionaryAlgorithm.population.Initialize();
            return evolutionaryAlgorithm;
        }

        public static EvolutionaryAlgorithm InitializeEAWithAllStrategies(int popSize, int maxGenerations, double crossoverRate, double mutationRate,
        SelectionStrategyInterface selectionStrategy, CrossoverStrategyInterface crossoverStrategy,
        MutationStrategyInterface mutationStrategy, StopCriteriaStrategyInterface stopCriteriaStrategy)
        {
            EvolutionaryAlgorithm evolutionaryAlgorithm = new EvolutionaryAlgorithm
            {
                population = new Population(popSize),
                crossoverRate = crossoverRate,
                mutationRate = mutationRate,
                selectionStrategy = selectionStrategy,
                crossoverStrategy = crossoverStrategy,
                mutationStrategy = mutationStrategy,
                stopCriteriaStrategy = stopCriteriaStrategy
            };
            evolutionaryAlgorithm.population.Initialize();
            return evolutionaryAlgorithm;
        }
    }
}