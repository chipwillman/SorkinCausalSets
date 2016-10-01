namespace Annealing
{
    using System;

    public class Rand
    {
        public Rand()
        {
            this.Glir = new int[97];
            this.Gliy = 0;
        }

        public Random Random = new Random();

        public int Gliset { get; set; }
        public double Glgset { get; set; }

        public double Ran2(int idum)
        {
            return Random.NextDouble();
            // Below is what was in the paper, but as idum is always > 0, it will return un-initialized value.
            // In Pascal, declarations should have a default initialized value just as in c#. Variable idum must have 
            // been set to a negative number and this method called for to ever return a non zero number and is
            // not in the paper.  If the intent was to use the uninitiallized data returned from the alloc as the 
            // randomizing factor, it would have only worked in c or with a custom memory allocation procedure.
            //const int m = 714025;
            //const int ia = 1366;
            //const int ic = 150889;
            //const double rm = 1.400512e-6;

            //int j;
            //if (idum < 0)
            //{
            //    idum = idum - idum % m;
            //    for (j = 0; j < 97; j++)
            //    {
            //        idum = (ia * idum + ic) % m;
            //        Glir[j] = idum;
            //    }
            //    idum = (ia * idum + ic) % m;
            //    Gliy = idum;
            //}
            //j = 1 + (97 * Gliy) / m;
            //if (j >= 97 || j < 0) System.Diagnostics.Debug.WriteLine("pause in routine RAN2");
            //this.Gliy = Glir[j];
            //var result = Gliy * rm;
            //idum = (ia * idum + ic) % m;
            //Glir[j] = idum;
            //return result;
        }

        public double Gasdev(int idum)
        {
            double result;
            if (this.Gliset == 0)
            {
                double r;
                double v1;
                double v2;
                do
                {
                    v1 = this.Ran2(idum);
                    v2 = this.Ran2(idum);
                    r = Math.Sqrt(v1) + Math.Sqrt(v2);
                }
                while (r >= 1.0);
                double fac = Math.Sqrt(-2.0 * Math.Log(r) / r);
                Glgset = v1 * fac;
                result = v2 * fac;
                Gliset = 1;
            }
            else
            {
                result = Glgset;
                Gliset = 0;
            }
            return result;
        }

        #region Implementation

        protected int[] Glir { get; set; }
        protected int Gliy { get; set; }

        #endregion
    }
}
