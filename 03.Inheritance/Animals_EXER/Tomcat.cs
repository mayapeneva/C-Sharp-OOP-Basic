﻿namespace Animals_EXER
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string Gender => "Male";

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}