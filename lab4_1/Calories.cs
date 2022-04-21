using System;
using System.Collections.Generic;
using System.Text;

namespace lab4_1
{
    class Calories
    {
        public double bmr, arm, dailyCalories;
        public double weight, height; public int age;

        public Calories()
        {
        }

        public void bmrCount()
        {
            bmr = 447.593 + 9.247 * weight + 3.098 * height - 4.330 * age;
        }

        public void dailyCaloriesCount()
        {
            dailyCalories=bmr+arm;
        }

        static public double caloriesInMenu(List<double> calories)
        {
            double rez = 0;
            foreach (double d in calories) rez += d;
            return rez;
        }
    }
}
