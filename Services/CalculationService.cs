using NetworkPlanner.Helpers;
using NetworkPlanner.Model;
using NetworkPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkPlanner.Services
{
    public class CalculationService : ICalculationService
    {

        public double CalculateCellRadius(CellRadiusCalculationViewModel cellRadiusCalculationInputData)
        {
            var eirp = CalculateEirp(cellRadiusCalculationInputData.TransmitterPower, cellRadiusCalculationInputData.CableLoss, cellRadiusCalculationInputData.AntennaGain);

            var frequencyEquationComponent = 69.55 + 26.16 * Math.Log10(cellRadiusCalculationInputData.Frequency);
            var transmittigEquationComponent = 13.82 * Math.Log10(cellRadiusCalculationInputData.TransmitterHeight);
            var distanceLogMultiplier = 44.9 - (6.55 * Math.Log10(cellRadiusCalculationInputData.TransmitterHeight));
            var antennaCorrectionFactor = CalculateAntennaCorrectionFactor(cellRadiusCalculationInputData.Frequency, Constants.Data.ReceiverHeight, cellRadiusCalculationInputData.AreaType);
            var cFactor = GetCFactor(cellRadiusCalculationInputData.Frequency, cellRadiusCalculationInputData.AreaType);

            double averagePathLoss = CalculateAveragePathLoss(eirp);
            var distanceLog10 =
                (
                averagePathLoss
                - frequencyEquationComponent
                - cFactor
                + transmittigEquationComponent
                + antennaCorrectionFactor) / distanceLogMultiplier;

            return Math.Round(Math.Pow(10, distanceLog10), 3);
        }

        private double CalculateAveragePathLoss(double eirp)
        {
            return
                eirp
                - Constants.Data.MobileStationSensitivity
                - Constants.Data.IntererenceMargin
                - Constants.Data.FastFadeMargin
                - Constants.Data.ConnectorLoss
                + Constants.Data.ReceiverAntennaGain;
        }

        public double CalculateEirp(double transmitterPower, double cableLoss, double antennaGain)
        {
            return transmitterPower - cableLoss + antennaGain;
        }
        private double GetCFactor(double frequency, AreaType areaType)
        {
            switch (areaType)
            {
                case AreaType.LargeCity:
                    return 0;
                case AreaType.SmallCity:
                    return 0;
                case AreaType.Suburb:
                    return (-2 * Math.Pow(Math.Log10(frequency / 28), 2)) - 5.4;
                case AreaType.RularArea:
                    return (-4.78 * Math.Pow(Math.Log10(frequency / 28), 2))
                        + (18.33 * Math.Log10(frequency))
                        - 49.98;
                default:
                    return 0;
            }
        }
        private double CalculateAntennaCorrectionFactor(double frequency, double receiverHeight, AreaType areaType)
        {
            switch (areaType)
            {
                case AreaType.LargeCity:
                    if (frequency >= 300)
                    {
                        return (3.2 * Math.Pow(Math.Log10(11.75 * receiverHeight), 2)) - 4.97;
                    }
                    else
                    {
                        return (8.29 * Math.Pow(Math.Log10(11.54 * receiverHeight), 2)) - 1.1;
                    }
                case AreaType.Suburb:
                case AreaType.SmallCity:
                case AreaType.RularArea:
                    return ((1.1 * Math.Log10(frequency) - 0.7) * receiverHeight) - (1.56 * Math.Log10(frequency) - 0.8);
                default:
                    return 0;
            }
        }

        public double CalculateCirf(double requiredCi, CellShape shape)
        {
            var requriedCiInHz = Math.Pow(10, requiredCi / 10d);
            return Math.Pow((Constants.Data.CellShapeData[shape].SidesNumber * requriedCiInHz), (1d / 4d));
        }

        public int FindMinimalNValue(double cirf, CellShape cellShape)
        {
            var nValues = new Dictionary<CellShape, List<int>>
            {
                {
                    CellShape.Hexagonal,
                    new List<int> {1, 3, 4, 7, 9,12, 13 }
                },
                {
                    CellShape.Square, new List<int> { 1, 2, 4, 5, 8, 9, 10, 13, 16, 17, 18, 20, 22 }
                }
            };

            var v = Math.Ceiling(Math.Pow(cirf, 2)) / Constants.Data.CellShapeData[cellShape].CirfNValueMultiplier;
            var nValue = nValues[cellShape].First(x => x >= v);

            return nValue;
        }

        private int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        public double CalculateReuseDistance(double cirf, double cellRange)
        {
            return cirf * cellRange;
        }

        public double CalculateCellCapacity(int channelMax, int channelMin, double clusterSize)
        {
            var channelNumber = (channelMax - channelMin) / clusterSize;
            var timeSlotsNumber = 8/*time slots8 */* channelNumber; //per cell

            return timeSlotsNumber;
        }

        private class HataModelCalculationFactor
        {
            public Func<double, double> AntennaCorrectionFactor { get; set; }
            public Func<double, double> CFactor { get; set; }
        }
    }
}

