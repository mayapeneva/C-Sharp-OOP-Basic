using System;

namespace MordorsCrueltyPlan_EXER
{
    class MoodFactory
    {
        public int FinalMood { get; set; }

        public string GetFinalMood(int mood)
        {
            var result = string.Empty;
            if (mood < -5)
            {
                result = $"{mood}{Environment.NewLine}Angry";
            }
            else if (mood >= -5 && mood <= 0)
            {
                result = $"{mood}{Environment.NewLine}Sad";
            }
            else if (mood > 0 && mood <=15)
            {
                result = $"{mood}{Environment.NewLine}Happy";
            }
            else
            {
                result = $"{mood}{Environment.NewLine}JavaScript";
            }

            return result;
        }
    }
}
