namespace Annealing.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CausalSetTest
    {
        [TestMethod]
        public void WhenCreatingANewCausalSet()
        {
            var set = new CausalSet(20, 10);
            Assert.AreEqual(20, set.MatrixSize, "It contains the matrix size");
            Assert.IsNotNull(set.Zeta, "It contains a representation of the incidence matrix (zeta function)");
            Assert.AreEqual(400, set.Zeta.Length, "The matrix is of dimension size 20x20");
            Assert.AreEqual(10, set.MaxDimensions, "The maximum space dimensions to be considered");
        }

        [TestMethod]
        public void WhenLoadingTheIncidenceMatrix()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);

            Assert.AreEqual(19, set.NumberElements, "Has the correct number of causal set elements");
            Assert.AreEqual(true, set.Zeta[2, 17], "Matrix Value should be set");
        }

        [TestMethod]
        public void ItAllowsTheChoiceOfNumberOfSpaceTimeDimensions()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);

            set.SpaceDimensions = 3;

            Assert.IsTrue(set.R > 0, "Average Radius should be larger than 0");
            Assert.IsTrue(set.E[0] > 0, "Energy level should be > 0");
        }

        [TestMethod]
        public void ItWarmsUpToAnInitialState()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            Assert.IsTrue(set.E[1] > 0, "Historical energy should be > 0");
        }

        [TestMethod]
        public void ItProvidesStatisticsAfterWarmsUp()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            set.Statistics();
            Assert.IsTrue(set.SpecificHeat > 0, "Specific Heat should be > 0");
            Assert.IsTrue(set.Eaverage > 0, "Average Energy should be > 0");
            Assert.IsTrue(set.Evariance > 0, "Variance should be > 0");
        }

        [TestMethod]
        public void ItCanPerformASingleAnnealOperation()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            set.Statistics();
            var initialSpecificHeat = set.SpecificHeat;
            var initialEnergy = set.Eaverage;
            var initialVariance = set.Evariance;
            set.Anneal();
            set.Statistics();
            Assert.IsTrue(Math.Abs(set.Eaverage - initialEnergy) > 0.01, "After Anneal, the energy levels change and should go down");
            Assert.IsTrue(Math.Abs(set.Evariance - initialVariance) > 0.01, "After Anneal, the variance change and should decrease");
            Assert.IsTrue(Math.Abs(set.SpecificHeat - initialSpecificHeat) > 0.01, "After Anneal, the specific heat will change and should decrease");
        }

        [TestMethod]
        public void ItCanPerformMultiplePassesOnTheAnnealOperation()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            set.Statistics();
            for (int i = 0; i < 1000; i++)
            {
                var initialSpecificHeat = set.SpecificHeat;
                var initialEnergy = set.Eaverage;
                var initialVariance = set.Evariance;
                set.Anneal();
                set.Statistics();
                Assert.IsTrue(Math.Abs(set.Eaverage - initialEnergy) > 0.0001, "After Anneal, the energy levels change and should go down");
                Assert.IsTrue(Math.Abs(set.Evariance - initialVariance) > 0.0001, "After Anneal, the variance change and should decrease");
                Assert.IsTrue(Math.Abs(set.SpecificHeat - initialSpecificHeat) > 0.00000001, "After Anneal, the specific heat will change and should decrease");

                if (set.Rand.Ran2(set.Seed) > 0.5)
                {
                    set.Temperature *= 0.9;
                }
                else
                {
                    set.Temperature /= 0.9;
                }
            }

            Assert.IsTrue(Math.Abs(set.Data[0].Eaverage - set.Data[set.Data.Count - 1].Eaverage) > 0.01, "The average energy should have changed");
        }

        [TestMethod]
        public void ItCanPerformMultiplePassesOnTheAnnealOperationToSimulateCooling()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            set.Statistics();
            for (int i = 0; i < 35; i++)
            {
                var initialSpecificHeat = set.SpecificHeat;
                var initialEnergy = set.Eaverage;
                var initialVariance = set.Evariance;
                set.Anneal();
                set.Statistics();
                Assert.IsTrue(Math.Abs(set.Eaverage - initialEnergy) > 0.0001, "After Anneal, the energy levels change and should go down");
                Assert.IsTrue(Math.Abs(set.Evariance - initialVariance) > 0.0001, "After Anneal, the variance change and should decrease");
                Assert.IsTrue(Math.Abs(set.SpecificHeat - initialSpecificHeat) > 0.000001, "After Anneal, the specific heat will change and should decrease");
                set.Temperature *= 0.9;
            }

            Assert.IsTrue(Math.Abs(set.Data[0].Eaverage - set.Data[set.Data.Count - 1].Eaverage) > 0.01, "Average energy levels should have changed between runs");
        }

        [TestMethod]
        public void ItRepresentsMinkowskiSpaceAsSpheresOfSpaceTime()
        {
            var set = new CausalSet(20, 10);
            set.ZetaFrom(IncidentMatrix);
            set.SpaceDimensions = 3;
            set.WarmUp();
            set.Statistics();
            for (int i = 0; i < 35; i++)
            {
                set.Anneal();
                set.Statistics();
                set.Temperature *= 0.9;
            }

            for (int i = 0; i < set.NumberElements; i++)
            {
                for (int k = 0; k < set.SpaceDimensions; k++)
                {
                    Assert.AreNotEqual(0.0, set.Xnew[i,k], "sphere should have a coordinate");
                }
                Assert.AreNotEqual(0.0, set.Rnew[i], "Sphere should have a radius");
            }
        }

        #region Sample Incident Matrix
        // Number of elements in the causal and incidence matrix for causal set Pdelta(4)
        private const string IncidentMatrix = @"19
0 0 0 1 0 0 0 1 0 0 1 1 0 0 1 1 1 1
  0 0 0 1 0 0 1 1 0 0 0 1 1 0 1 1 1
    0 0 0 1 0 0 1 1 0 1 0 1 1 0 1 1
      0 0 0 1 0 0 1 1 0 1 1 1 1 0 1
        0 0 0 0 0 0 0 0 0 0 0 0 0 0
          0 0 0 0 0 0 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 0 0 0 0 0
              0 0 0 0 0 0 0 0 0 0 0
                0 0 0 0 0 0 0 0 0 0
                  0 0 0 0 0 0 0 0 0
                    0 0 0 0 0 0 0 0
                      0 0 0 0 0 0 0
                        0 0 0 0 0 0
                          0 0 0 0 0
                            0 0 0 0
                              0 0 0
                                0 0
                                  0
";

        #endregion
    }
}
