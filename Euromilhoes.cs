public class Euromilhoes
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
        }

        #endregion

        #region Public Methods

        ///<summary>
        ///Validates whether a ticket is valid or not.
        ///</summary>
        public bool Validate(List<int> numbers, List<int> stars)
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
    }
}