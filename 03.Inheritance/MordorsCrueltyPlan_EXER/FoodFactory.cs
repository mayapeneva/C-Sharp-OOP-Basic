namespace MordorsCrueltyPlan_EXER
{
    public class FoodFactory
    {
        private int mood;

        public string Food { get; set; }

        public int Mood => this.mood;

        public void GetFed(string food)
        {
            switch (food.ToLower())
            {
                case "cram":
                    mood += 2;
                    break;
                case "lembas":
                    mood += 3;
                    break;
                case "apple":
                    mood += 1;
                    break;
                case "melon":
                    mood += 1;
                    break;
                case "honeycake":
                    mood += 5;
                    break;
                case "mushrooms":
                    mood -= 10;
                    break;
                default:
                    mood -= 1;
                    break;
            }
        }

        public int GetMood()
        {
            return Mood;
        }
    }
}
