using System.Text;
using APBD2.Containers.Abstract;

namespace APBD2.Containers;

public class GasContainer : HazardousContainer
{
    public double Pressure { get; }

    public GasContainer(
        double height,
        double depth,
        double tareWeight,
        double maxPayload,
        double pressure
    )
        : base(
            height,
            depth,
            tareWeight,
            maxPayload,
            'G'
        )
    {
        Pressure = pressure > 0 ? pressure : throw new ArgumentException("Pressure must be greater than zero");
    }

    public override void EmptyCargo() => CargoMass *= 0.05;

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(base.ToString());
        builder.Append($"pressure: {Pressure}");

        return builder.ToString();
    }
}