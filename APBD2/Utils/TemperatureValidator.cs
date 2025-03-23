using APBD2.Enums;

namespace APBD2;


public class TemperatureValidator
{
    public static bool IsValidTemperature(ProductType productType, double temperature)
    {
        var allowedTemperature = GetTemperature(productType);
        return temperature >= allowedTemperature;
    }

    public static double GetTemperature(ProductType productType)
    {
        var temperature = productType switch
        {
            ProductType.Bananas => 13.3,
            ProductType.Chocolate => 18.0,
            ProductType.Meat => -15.0,
            ProductType.Fish => 2.0,
            ProductType.IceCream => -18.0,
            ProductType.FrozenPizza => -30.0,
            ProductType.Cheese => 7.2,
            ProductType.Sausages => 5.0,
            ProductType.Butter => 20.5,
            ProductType.Eggs => 19.0,
            _ => throw new ArgumentException("Invalid productType")
        };
        
        return temperature;
    }
}