using System;

namespace Ex1
{
    public class Ex1
    {
        public String getNumPrimosUntill(int x)
        {
            if (x > 1000000 || x < 0) return "El parámetro debe ser un número válido";
            else
            {
                bool[] criba = new bool[x];
                for (int i = 2; i < Math.Sqrt(x); ++i)
                {
                    if (!criba[i])
                    {
                        for (int j = i + i; j < x; j += i) criba[j] = true;
                    }
                }
                String s = "";
                for (int i = 2; i < x; ++i)
                {
                    if (!criba[i]) s = s+i.ToString()+" ";
                }
                if (s.Length > 0) return (s.Remove(s.Length - 1));
                else return s;
            }
        }
    }
}
