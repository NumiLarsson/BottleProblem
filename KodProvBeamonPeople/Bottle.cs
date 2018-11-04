namespace KodProvBeamonPeople
{
    public class Bottle
    {
        private readonly int _maxVolume;
        private int _minVolume = 0;
        public int CurrentVolume { get; private set; } = 0;

        public Bottle(int maxVolume)
        {
            _maxVolume = maxVolume;
        }

        public Bottle(Bottle bottleToCopyFrom)
        {
            _maxVolume = bottleToCopyFrom._maxVolume;
            CurrentVolume = bottleToCopyFrom.CurrentVolume;
            _minVolume = bottleToCopyFrom._minVolume;
        }

        public int RemainingVolume() => _maxVolume - CurrentVolume;

        public void Fill()
        {
            CurrentVolume = _maxVolume;
        }

        public void Empty()
        {
            CurrentVolume = _minVolume;
        }

        public void RemoveVolume(int amountToRemove)
        {
            if (amountToRemove > CurrentVolume)
                this.CurrentVolume = 0;
            else 
                this.CurrentVolume -= amountToRemove;
        }

        public void AddToVolumeFromThisBottle(Bottle targetBottle)
        {
            int amountToAdd = targetBottle.CurrentVolume;

            //If the bottle we're pouring from contains more than we can hold, only take what we can handle.
            if (this.RemainingVolume() < amountToAdd)
            {
                amountToAdd = this.RemainingVolume();
                targetBottle.RemoveVolume(amountToAdd);
            }
            else
            {
                targetBottle.Empty();
            }

            this.CurrentVolume += amountToAdd;
        }
    }
}