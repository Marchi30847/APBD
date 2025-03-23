using System.Text;
using APBD2.Containers.Abstract;

namespace APBD2.Containers;

public class LiquidContainer : HazardousContainer
{
    private readonly double _allowedMaxPayload;

    public bool IsCargoHazardous { get; }

    public LiquidContainer(
        double height,
        double depth,
        double tareWeight,
        double maxPayload,
        bool isCargoHazardous 
    )
        : base(
            height,
            depth,
            tareWeight,
            maxPayload,
            'L'
        )
    {
        IsCargoHazardous = isCargoHazardous;
        var capacityLimit = isCargoHazardous ? 0.5 : 0.9;
        _allowedMaxPayload = maxPayload * capacityLimit;
    }

    protected override bool CanLoadCargo(double mass) => CargoMass + mass <= _allowedMaxPayload;
    
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(base.ToString());
        builder.Append($"max payload: {_allowedMaxPayload}, hazardous: {IsCargoHazardous}");
        
        return builder.ToString();
    }
}