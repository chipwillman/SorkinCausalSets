namespace Annealing
{
    using System;
    using System.Collections.Generic;

    public class CausalSet
    {
        private int spaceDimensions;

        public CausalSet(int matrixSize, int maxDimensions)
        {
            this.MatrixSize = matrixSize;
            this.MaxDimensions = maxDimensions;
            this.Zeta = new bool[this.MatrixSize, this.MatrixSize];
            this.E = new double[100];
            this.Seed = 1959;
            this.Rand = new Rand();
        }

        public List<AnnealResults> Data = new List<AnnealResults>();

        public int Seed { get; set; }
        
        public int MatrixSize { get; private set; }

        public bool[,] Zeta { get; private set; }

        public int MaxDimensions { get; private set; }

        public int NumberElements { get; set; }

        public double SpecificHeat { get; set; }

        public double Temperature { get; set; }

        public int TotalCount { get; set; }

        public double Eaverage { get; set; }

        public double Evariance { get; set; }

        public int SpaceDimensions
        {
            get
            {
                return this.spaceDimensions;
            }
            set
            {
                this.spaceDimensions = value;
                OnSpaceTimeDimensionsChanged();
            }
        }

        public void Anneal()
        {
            this.Count = 0;
            while (this.Count < 100 && E[0] > 0.0)
            {
                this.Reconfigure();
                this.Energy();
                this.Decide();
            }
            this.Statistics();
            this.Ndata++;
            this.Data.Add(new AnnealResults { Eaverage = this.Eaverage, NData = this.Ndata, Temperature = this.Temperature, Variance = this.Evariance, TotalEnergy = this.E[0] });
        }

        public void Statistics()
        {
            Eaverage = 0.0;
            var e2 = 0.0;
            for (int i = 0; i < 100; i++)
            {
                Eaverage = Eaverage + E[i];
                e2 = e2 + E[i] * E[i];
            }

            Eaverage = Eaverage / 100;
            e2 = e2 / 100;
            Evariance = Math.Sqrt(e2 - (Eaverage * Eaverage));
            if (this.TotalCount == 0) this.Temperature = 100.0;
            if (this.Temperature > 0) this.SpecificHeat = Math.Pow(this.Evariance / this.Temperature, 2.0);
            this.TotalCount += 100;
        }

        public void WarmUp()
        {
            this.Count = 0;
            while (this.Count < 100 && E[0] > 0)
            {
                this.Reconfigure();
                this.Energy();
                this.Update();
                this.Count++;
            }
        }

        public void ZetaFrom(string incidentMatrix)
        {
            var lines = incidentMatrix.Split('\n');
            if (lines.Length > 1)
            {
                this.NumberElements = int.Parse(lines[0]);
                if (this.NumberElements < this.MatrixSize)
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        for (int j = 0; j < lines[i].Length / 2; j++)
                        {
                            if (lines[i][2 * j] == '1')
                            {
                                this.Zeta[i - 1, j] = true;
                            }
                        }
                    }
                }
                else
                {
                    throw new ApplicationException("IncidentMatrix is of the wrong size");
                }
            }
        }

        #region Implementation

        private static readonly double Roottwo = Math.Sqrt(2.0);
        protected double Raverage { get; set; }
        public double R { get; set; }
        public double[] E { get; set; }
        protected double[,] Enew { get; set; }
        protected double[,] Eold { get; set; }
        public  double[,] Xnew { get; set; }
        protected double[,] Xold { get; set; }
        public double[] Rnew { get; set; }
        protected double[] Rold { get; set; }

        protected bool[] Change { get; set; }
        protected int Count { get; set; }
        protected double DeltaE { get; set; }
        public readonly Rand Rand;

        protected int Ndata { get; set; }

        private void Decide()
        {
            if (this.DeltaE < 0)
            {
                this.Update();
                this.Count++;
            }
            else
            {
                if (this.Temperature > 0)
                {
                    var random = Rand.Ran2(this.Seed);
                    if (random < 4 * Math.Exp(-this.DeltaE / this.Temperature))
                    {
                        this.Update();
                        this.Count++;
                    }
                }
            }
        }


        private void Energy()
        {
            this.DeltaE = 0.0;
            for (int i = 0; i < this.NumberElements; i++)
            {
                for (int j = i + 1; j < this.NumberElements; j++)
                {
                    var rij = this.Rnew[i] - Rnew[j];
                    var xij = 0.0;
                    for (int k = 0; k < this.SpaceDimensions; k++)
                    {
                        xij += (Xnew[i, k] - Xnew[j, k]) * (Xnew[i, k] - Xnew[j, k]);
                    }
                    var rijSquared = Math.Pow(rij, 2);
                    var s2 = -(rijSquared) + xij;
                    if (xij < 0)
                    {
                        System.Diagnostics.Debug.WriteLine("xij is below 0");
                    }
                    xij = Math.Sqrt(xij);
                    if (this.Zeta[i, j])
                    {
                        if (s2 > 0)
                        {
                            this.Enew[i, j] = (xij + rij)/(Roottwo*Raverage);
                        }
                        else
                        {
                            if (rij > 0)
                            {
                                Enew[i, j] = Math.Sqrt(s2 + 2 * (rijSquared)) / Raverage;
                            }
                            else
                            {
                                Enew[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        if (s2 > 0)
                        {
                            Enew[i, j] = 0;
                        }
                        else
                        {
                            Enew[i, j] = (Math.Abs(rij) - xij) / (Roottwo * Raverage);
                        }
                    }
                    this.DeltaE = this.DeltaE + Enew[i, j] - Eold[i, j];
                }
            }
        }

        private void OnSpaceTimeDimensionsChanged()
        {
            this.Change = new bool[this.NumberElements];
            this.Xnew = new double[this.NumberElements, this.SpaceDimensions];
            this.Xold = new double[this.NumberElements, this.SpaceDimensions];
            this.Rnew = new double[this.NumberElements];
            this.Rold = new double[this.NumberElements];
            this.Enew = new double[this.NumberElements, this.NumberElements];
            this.Eold = new double[this.NumberElements, this.NumberElements];
            for (int i = 0; i < this.Change.Length; i++)
            {
                this.Change[i] = true;
                for (int j = 0; j < this.SpaceDimensions; j++)
                {
                    this.Xnew[i, j] = 0;
                    this.Rnew[i] = i + 1;
                }
            }
            this.Raverage = this.NumberElements + 4 / 2.0;
            this.Energy();
            this.Update();
        }

        private void Update()
        {
            for (int i = E.Length - 1; i > 0; i--)
            {
                this.E[i] = this.E[i - 1];
            }
            E[0] = 0;
            var rmin = Rnew[0];
            for (int i = 0; i < this.NumberElements; i++)
            {
                if (Rnew[i] < rmin)
                {
                    rmin = Rnew[i];
                }
                if (Change[i])
                {
                    for (int k = 0; k < this.SpaceDimensions; k++)
                    {
                        Xold[i, k] = Xnew[i, k];
                    }
                    Rold[i] = Rnew[i];
                }
                for (int j = i+1; j < this.NumberElements; j++)
                {
                    if (this.Change[i] || this.Change[j])
                    {
                        Eold[i, j] = Enew[i, j];
                    }
                }
                Eold[i, i] = 0;
                for (int j = 0; j < i - 1; j++)
                {
                    Eold[i, i] = Eold[i, i] + Eold[j, i] / 2;
                }
                for (int j = i+1; j < this.NumberElements; j++)
                {
                    Eold[i, i] = Eold[i, i] + Eold[i, j] / 2;
                }
                if (double.IsNaN(Eold[i, i]))
                {
                    System.Diagnostics.Debug.WriteLine("Error");
                }
                E[0] += Eold[i, i];
                if (double.IsNaN(E[0]))
                {
                    System.Diagnostics.Debug.WriteLine("Error");
                }
            }
            for (int i = 0; i < this.NumberElements; i++)
            {
                if (double.IsNaN(rmin) || Math.Abs(rmin - 0) < 0.00000001)
                {
                    System.Diagnostics.Debug.WriteLine("Error");
                }
                for (int k = 0; k < this.SpaceDimensions; k++)
                {
                    Xold[i, k] = Xold[i, k] / rmin;
                }
                Rold[i] = Rold[i] / rmin;
            }
            Raverage = Raverage / rmin;
            R = Raverage;
        }

        private void Reconfigure()
        {
            var displacement = new double[this.spaceDimensions + 1];
            this.Raverage = this.R;
            for (int i = 0; i < this.NumberElements; i++)
            {
                var efraction = 2 * this.Eold[i, i] / this.E[0];
                var randomNumber = this.Rand.Ran2(this.Seed) - 0.5;
                if (randomNumber > efraction)
                {
                    Change[i] = true;
                }
                else
                {
                    Change[i] = false;
                }
                do
                {
                    double norm;
                    do
                    {
                        norm = 0.0;
                        for (int k = 0; k < this.SpaceDimensions + 1; k++)
                        {
                            displacement[k] = 2* this.Rand.Ran2(this.Seed) - 1;
                            norm = norm + displacement[k] * displacement[k];
                        }
                    }
                    while (Math.Abs(norm) >= 1);
                    
                    var gasdev = this.Rand.Gasdev(this.Seed);
                    norm = Eold[i, i] * this.R * gasdev / Math.Sqrt(norm);
                    for (int k = 0; k < this.SpaceDimensions; k++)
                    {
                        Xnew[i, k] = Xold[i, k] + displacement[k] * norm;
                    }
                    Rnew[i] = Rold[i] + displacement[this.SpaceDimensions] * norm;

                }
                while (Rnew[i]<=0);
                Raverage = Raverage + (Rnew[i] - Rold[i]) / this.NumberElements;
            }
        }


        #endregion

    }
}
