using System;
using System.Collections.Generic;
using System.Linq;

namespace KodProvBeamonPeople
{
    /// <summary>   
    /// TODO: Make state immuntable to work with AddAnotherRound()
    /// </summary>
    public class StateOfBottles
    {
        public Bottle FiveLiterBottle;
        public Bottle ThreeLiterBottle;
        public int ActionsTaken = 0;
        public StateOfBottles ParentState;
        public ValidActions? ActionTaken;
        public StateOfBottles()
        {
            FiveLiterBottle = new Bottle(5);
            ThreeLiterBottle = new Bottle(3);
        }

        /// <summary>
        /// Be careful using this constructor, it's intended to be used internally.
        /// </summary>
        /// <param name="parentState"></param>
        /// <param name="actionToTake"></param>
        private StateOfBottles(StateOfBottles parentState, ValidActions actionToTake)
        {
            //TODO: Verify if simply FiveLiterBottle = ParentState.FiveLiterBottle is a copy or a reference
            //For now we play safe and copy manually
            FiveLiterBottle = new Bottle(parentState.FiveLiterBottle);
            ThreeLiterBottle = new Bottle(parentState.ThreeLiterBottle);

            this.ParentState = parentState;

            ActionTaken = actionToTake;

            ActionsTaken = parentState.ActionsTaken + 1;
            switch (actionToTake)
            {
                case ValidActions.Fill5:
                    FiveLiterBottle.Fill();
                    break;
                case ValidActions.Fill3:
                    ThreeLiterBottle.Fill();
                    break;
                case ValidActions.Empty5:
                    FiveLiterBottle.Empty();
                    break;
                case ValidActions.Empty3:
                    ThreeLiterBottle.Empty();
                    break;
                case ValidActions.Pour5To3:
                    ThreeLiterBottle.AddToVolumeFromThisBottle(FiveLiterBottle);
                    break;
                case ValidActions.Pour3To5:
                    FiveLiterBottle.AddToVolumeFromThisBottle(ThreeLiterBottle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionToTake), actionToTake, null);
            }
        }

        public bool EvaluateIfTargetIsReached(int target)
        {
            return target == FiveLiterBottle.CurrentVolume
                   ||
                   target == ThreeLiterBottle.CurrentVolume
                   || target == FiveLiterBottle.CurrentVolume + ThreeLiterBottle.CurrentVolume;
        }

        private StateOfBottles Perform(ValidActions action)
        {
            return new StateOfBottles(this, action);
        }

        /// <summary>
        ///     Adds all actions used in ValidActions to the end of the provided list.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="state"></param>
        /// <returns>List, with all actions from ValidActions applied to the end, using the supplied state as first action.</returns>
        public static List<StateOfBottles> AddAnotherRound(List<StateOfBottles> list, StateOfBottles state)
        {
            var variant = Enum.GetValues(typeof(ValidActions)).Cast<ValidActions>();
            foreach (var action in variant)
            {
                //Console.WriteLine($"Performing action: {action}");
                list.Add(state.Perform(action));
            }
            return list;
        }
    }
}