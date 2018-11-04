namespace KodProvBeamonPeople
{
    /*
         Requirements:


     *"You have two unmarked bottles that can hold 3 liters and 5 liters respectively, and a bathtub with unlimited water.
     * You are allowed to either fill a bottle,
     * empty a bottle or
     * pour one bottle into the other until either the source bottle is empty or the target targetBottle is full.
       
       - how can 1 liter be measured?
       - how can 4 liters be measured?
       
       Implement a solution that would solve this problem and find the minimum amount of steps required to measure the desired amount of water (1 and 4 liters).
       Note that the program should find the shortest solution given only the information above, i.e. the volume of the unmarked bottles and the desired target amount.
       
       Provide the source code (including unit tests) and if necessary, a description of how to execute the code."
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                BottleProblem.Run(args.Length == 0, args);
            }
            
        }
    }
}
