namespace ga1
{
    public class OnePointSwapMutation<T> : IMutation<T>
    {
        public OnePointSwapMutation(int point)
        {
            this.point = point;
        }

        public IChromosome<T> Mutate(IChromosome<T> chromo)
        {
            CrossoverTools.CheckPoint(ref point, chromo.Length);
            SwapMutation<T> swapMutation = new SwapMutation<T>(point - 1, point);
            return swapMutation.Mutate(chromo);
        }

        private int point;

        public int Point
        {
            get
            {
                return point;
            }
        }
    }
}