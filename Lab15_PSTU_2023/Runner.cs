namespace Lab15_PSTU_2023
{
    public class Runner
    {
        public static int runnerCount = 0;


        public Runner()
        {
            runnerCount += 1;
            this.Id = runnerCount;
        }
        
        
        public int Id { get; }
    }
}