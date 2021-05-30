using System;
namespace EvolutionaryAlgorithm
{
    public class Individual : ICloneable
    {
        protected double[] chromossome;
        protected double fitness;
        protected readonly double geneRange = 10;

        public Individual()
        {
            chromossome = new double[6];
            for (int currentGene = 0; currentGene < chromossome.Length; ++currentGene)
                chromossome[currentGene] = RandomSingleton.GetInstance().Random.NextDouble() * geneRange - geneRange;
            fitness = double.MaxValue;
        }

        public void InitializeRandomGene(int geneIndex)
        {
            chromossome[geneIndex] = RandomSingleton.GetInstance().Random.NextDouble() * geneRange - geneRange;
            fitness = double.MaxValue;
        }

        public double[] Chromossome { get => chromossome; set => chromossome = value; }

        public double Fitness
        {
            get { return (fitness == double.MaxValue) ? calculateFitness() : fitness; }
            set => fitness = value;
        }

        public double calculateFitness()
        {
            Fitness = Math.Abs((Chromossome[0] * 5.3 + Chromossome[1] * 3.2 + Chromossome[2] * 7.84
                    + Chromossome[3] * 1.52 + Chromossome[4] * 14.76 + Chromossome[5] * 0.52) - 50);
            //a*5.3 + b*3.2 + c*7.84 + d*1.52 + e*14.76 + f*0.52 = 50
            return Fitness;
        }

        public object Clone()
        {
            Individual clone = new Individual
            {
                Chromossome = chromossome,
                Fitness = fitness
            };
            return clone;
        }

        public override string ToString()
        {
            return base.ToString() + $": Fitness = {fitness}" +
                $"\nVariables: a = {Chromossome[0]}, b = {Chromossome[1]}, c = {Chromossome[2]}" +
                $", d = {Chromossome[3]}, e = {Chromossome[4]}, f = {Chromossome[5]}";
        }
    }
}