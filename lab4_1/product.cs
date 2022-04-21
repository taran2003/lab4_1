using System;
using System.Collections.Generic;
using System.Text;

namespace lab4_1
{
    class product
    {
        public string name;
        public int gramms;
        public double protein, fats, carbs, calories;

        public product(List<string> product)
        {
            name = product[0];
            gramms = int.Parse(product[1]);
            protein = double.Parse(product[2]);
            fats = double.Parse(product[3]);
            carbs = double.Parse(product[4]);
            calories = double.Parse(product[5]);

        }

        public product()
        {
        }

        public void grammsChange(int Gramms)
        {
            calories = (Gramms * calories) / gramms;
            carbs = (Gramms * carbs) / gramms;
            fats = (Gramms * fats) / gramms;
            protein = (Gramms * protein) / gramms;
            gramms = Gramms;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name.Trim());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as product);
        }

        public bool Equals(product obj)
        {
            return obj != null && name==obj.name;
        }
    }
}
