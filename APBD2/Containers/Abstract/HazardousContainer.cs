using APBD2.Interfaces;

namespace APBD2.Containers;

public abstract class HazardousContainer : Container, IHazardNotifier
{
    public HazardousContainer(
        double height,
        double depth,
        double tareWeight,
        double maxPayload,
        char containerType
    )
        : base(
            height,
            depth,
            tareWeight,
            maxPayload,
            containerType
        )
    {
    }

    public override void LoadCargo(double mass)
    {
        if (mass <= 0) throw new ArgumentException("Mass must be greater than zero");

        if (!CanLoadCargo(mass))
        {
            NotifyHazard("Loading cargo will cause overfill");
            throw new OverflowException("Can't load cargo");
        }

        CargoMass += mass;
    }

    public void NotifyHazard(string messsage)
    {
        Console.WriteLine($"Hazardous situation occured for container {SerialNumber}" +
                          $"\n{messsage}");
    }
}