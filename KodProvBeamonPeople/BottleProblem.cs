using System;
using System.Collections.Generic;
using System.Linq;

namespace KodProvBeamonPeople
{
    public class BottleProblem
    {
        public static int Run(bool isRanByUser, string[] args)
        {
            int target = -1;
            target = !isRanByUser ? int.Parse(args[0]) : GetParametersFromConsole();

            if (target > 8 || target < 0) throw new ArgumentException("We're not ready to handle values over 8 or below 0 yet");

            List<StateOfBottles> listOfStates = new List<StateOfBottles>();
            //In order to perform a breadth-first search we must populate this list sorted by actions taken.

            StateOfBottles state = new StateOfBottles();
            listOfStates.Add(state);

            int variant = 0;
            while (true)
            {
                
                if (state.EvaluateIfTargetIsReached(target))
                    break;

                state = listOfStates.First();
                listOfStates.Remove(state);

                //Only used for manual debugging.
                //Console.WriteLine($"Itteration: {variant}, Five: {state.FiveLiterBottle.CurrentVolume}, Three: {state.ThreeLiterBottle.CurrentVolume}, Target: {target}, ActionTaken: {state.ActionTaken}");                

                listOfStates = StateOfBottles.AddAnotherRound(listOfStates, state);
                variant += 1;
            }

            Console.WriteLine($"To find {target} requires {state.ActionsTaken} steps, we evaluated {variant} different states in order to find this path.");
            Console.WriteLine("Press Enter to display the actions taken");
            if (isRanByUser)
            {
                Console.ReadLine();
            }

            Console.WriteLine($"Actions Taken to reach the route:");
            var statesToAccomplishTask = CalculateStepsTaken(new List<ValidActions>(), state);
            foreach (var x in statesToAccomplishTask)
            {
                Console.WriteLine((object) x);
            }

            if (isRanByUser)
            {
                Console.ReadLine();
            }

            return state.ActionsTaken;
        }

        private static int GetParametersFromConsole()
        {
            Console.WriteLine("Enter a target volume to measure");
            string inputString = Console.ReadLine();

            if (inputString != null && inputString.Length == 0)
            {
                Console.WriteLine("Not a valid input, try again");
                return GetParametersFromConsole();
            }
            int target = int.Parse(inputString);
            return target;
        }

        private static List<ValidActions> CalculateStepsTaken(List<ValidActions> list, StateOfBottles state)
        {
            if (state == null)
            {
                list.Reverse(); //Reverse the list in order to output the actions in correct order (the state without a parent is the first action we take).
                return list;
            }
            if (state.ActionTaken.HasValue)
                list.Add(state.ActionTaken.Value);

            return CalculateStepsTaken(list, state.ParentState);
        }
    }
}