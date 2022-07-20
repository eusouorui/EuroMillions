public class Euromillions
{

    public class Ticket
    {
        #region Public Properties

        #region Lists

        public List<int> Numbers = new List<int>();
        public List<int> Stars = new List<int>();

        #endregion

        #region Constants

        public const int NUMBERS_ALLOWED = 5;
        public const int HIGHEST_NUMBER_ALLOWED = 50;
        public const int SMALLEST_NUMBER_ALLOWED = 1;

        public const int STARS_ALLOWED = 2;
        public const int HIGHEST_STAR_ALLOWED = 12;
        public const int SMALLEST_STARS_ALLOWED = 1;

        #endregion

        #endregion

        #region Constructors

        public Ticket(List<int> numbers, List<int> stars)
        {
            this.Numbers = numbers;
            this.Stars = stars;

            this.Numbers.Sort();
            this.Stars.Sort();
        }

        #endregion

        #region Public Methods

        ///<summary>
        ///Validates whether a ticket is valid or not when provided numbers and stars
        ///</summary>
        public static bool Validate(List<int> numbers, List<int> stars)
        {
            return !((
                numbers.Any(n => n > HIGHEST_NUMBER_ALLOWED) ||
                numbers.Any(n => n < SMALLEST_NUMBER_ALLOWED) ||
                stars.Any(s => s > HIGHEST_NUMBER_ALLOWED) ||
                stars.Any(s => s < SMALLEST_NUMBER_ALLOWED)) ||
                stars.Count != STARS_ALLOWED ||
                numbers.Count != NUMBERS_ALLOWED
            );
        }
        #endregion

        public List<int> GenerateRandomList(int totalNumbers, int lowestAllowed, int highestAllowed)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            int sortedNumber = 0;
            
            while(list.Count < totalNumbers)
            {
                sortedNumber = random.Next(lowestAllowed, highestAllowed);
                if(!list.Contains(sortedNumber))
                {
                    list.Add(sortedNumber);
                }
            }

            return list;
        }

        public void PrintTicket()
        {
            Console.WriteLine("Your ticket:\n\n");
            Console.WriteLine("Numbers:");

            Console.WriteLine(string.Join(", ", Numbers));

            Console.WriteLine("\n\nStars:");
            Console.WriteLine(string.Join(", ", Stars));
        }
    }
}