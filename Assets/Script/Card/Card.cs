namespace Assets.Script.CardPackage
{
    public class Card
    {
        private Value value;
        private Color color;

        /**
		 * Constructor
		 * @param value
		 * @param color
		 */
        public Card(Value value, Color color)
        {
            this.value = value;
            this.color = color;
        }

        /**
		 * @return the color's name of the card
		 */
        public Color GetColor()
        {
            return color;
        }

        /**
		 * @return the points of the card
		 */
        public Value GetValue()
        {
            return value;
        }

    }
}
