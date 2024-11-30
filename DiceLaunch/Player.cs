namespace DiceLaunch
{
    public class Player
    {
        const int FACE = 6;
        private int[] _counters = new int[FACE];
        private int[] _points;
        public int[] Counters
        {
            get { return _counters; }
        }
        public int[] Points
        {
            get { return _points; }
        }
        public int TotPoints
        {
            get
            {
                int sum = 0;
                foreach (int point in Points)
                {
                    sum += point;
                }
                return sum * Counters[5];
            }
        }

        public Player(int numLaunches)
        {
            if (numLaunches <= 0) throw new ArgumentOutOfRangeException("The number of launches need to be more than 0");
            _points = new int[numLaunches];
        }

        public int[] InWhatLaunch(int num)
        {
            if (num < 1 || num > FACE) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            int j = 0;
            int[] count = new int[Counters[num - 1]];
            for (int i = 0; i < Points.Length; i++)
            {
                if (Points[i] == num)
                {
                    count[j] = i;
                    j++;
                }
            }
            return count;
        }

        public int HowManyTimes(int num)
        {
            if (num < 1 || num > FACE) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            return Counters[num - 1];
        }

        public double FrequencyPlayerNum(int num)
        {
            if (num < 1 || num > FACE) throw new ArgumentOutOfRangeException("Num need to be a valid number");
            return (double)Counters[num - 1] / Points.Length * 100;
        }

        internal bool isValid()
        {
            int count = 0;
            bool valid = true;
            while (valid && count < 6)
            {
                if (Counters[count] > Points.Length / 2) valid = false;
                count++;
            }
            return valid;
        }

        internal void launch()
        {
            Random rand = new Random();
            int num;
            for (int i = 0; i < Points.Length; i++)
            {
                num = rand.Next(1, FACE + 1);
                Points[i] = num;
                Counters[num - 1]++;
            }
        }
    }
}
