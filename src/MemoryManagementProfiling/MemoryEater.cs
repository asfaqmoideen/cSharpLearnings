namespace MemoryManagementProfiling
{
    /// <summary>
    /// Reprsents the methods which creates maximum memoery leak
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Creates infiite array of integers to the list _memAlloc
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                try
                {
                    this._memAlloc.Add(new int[1000]);
                    Thread.Sleep(10);
                }
                finally
                {
                    this._memAlloc.Clear();
                }
            }
        }
    }
}
