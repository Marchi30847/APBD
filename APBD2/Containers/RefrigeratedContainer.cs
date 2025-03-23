using System.Text;
using APBD2.Containers.Abstract;
using APBD2.Enums;
using APBD2.Utils;

namespace APBD2.Containers;

public class RefrigeratedContainer : Container
{
    public ProductType ProductType { get; }
    public double MaintainedTemperature { get; }

    public RefrigeratedContainer(
        double height,
        double depth,
        double tareWeight,
        double maxPayload,
        ProductType productType,
        double maintainedTemperature
    )
        : base(
            height,
            depth,
            tareWeight,
            maxPayload,
            'C'
        )
    {
        if (TemperatureValidator.IsValidTemperature(productType, maintainedTemperature))
        {
            ProductType = productType;
            MaintainedTemperature = maintainedTemperature;
        }
        else
        {
            throw new ArgumentException("Maintained temperature is not valid for the given product");
        }
    }
    
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(base.ToString());
        builder.Append($"product type: {ProductType}, maintained temperature: {MaintainedTemperature}");
        
        return builder.ToString();
    }
}