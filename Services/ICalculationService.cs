using NetworkPlanner.Model;
using NetworkPlanner.ViewModels;

namespace NetworkPlanner.Services
{
    public interface ICalculationService
    {
        double CalculateCellRadius(CellRadiusCalculationViewModel cellRadiusCalculationInputData);

        double CalculateCirf(double requiredCi, CellShape shape);

        int FindMinimalNValue(double cirf, CellShape cellShape);

        double CalculateEirp(double transmitterPower, double cableLoss, double antennaGain);
        double CalculateReuseDistance(double cirf, double cellRange);
        double CalculateCellCapacity(int channelMax, int channelMin, double clusterSize);
    }
}
