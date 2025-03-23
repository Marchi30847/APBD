using APBD2.Containers.Abstract;

namespace APBD2.Transports;

using System;
using System.Text;
using System.Collections.Generic;

public class ContainerShip
{
    public double MaxSpeed { get; }
    public int MaxContainerCapacity { get; }
    public double MaxWeightCapacity { get; }
    public List<Container> Containers { get; } = new List<Container>();

    public ContainerShip(double maxSpeed, int maxContainerCapacity, double maxWeightCapacity)
    {
        MaxSpeed = maxSpeed > 0 ? maxSpeed : throw new ArgumentException("Max speed must be greater than 0");
        MaxContainerCapacity = maxContainerCapacity > 0
            ? maxContainerCapacity
            : throw new ArgumentException("Max container capacity must be greater than 0");
        MaxWeightCapacity = maxWeightCapacity > 0
            ? maxWeightCapacity
            : throw new ArgumentException("Max weight capacity must be greater than 0");
    }

    public void LoadContainer(Container container)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container), "Container is null");
        }

        if (Containers.Count >= MaxContainerCapacity)
        {
            throw new InvalidOperationException("Maximum ship capacity is exceeded");
        }

        double totalWeight = GetCurrentWeight() + container.GetCompleteWeight();
        if (totalWeight > MaxWeightCapacity)
        {
            throw new InvalidOperationException("Maximum ship weight capacity is exceeded");
        }

        Containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded");
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public Container UnloadContainer(string serialNumber)
    {
        if (serialNumber == null)
        {
            throw new ArgumentNullException(nameof(serialNumber), "serial number is null");
        }

        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new KeyNotFoundException($"Container {serialNumber} not found");
        }

        Containers.Remove(container);
        Console.WriteLine($"Container {serialNumber} has been unloaded.");
        return container;
    }

    public Container ReplaceContainer(string serialNumber, Container newContainer)
    {
        if (newContainer == null)
        {
            throw new ArgumentNullException(nameof(newContainer), "new container is null");
        }
        
        var container = UnloadContainer(serialNumber);
        LoadContainer(newContainer);
        return container;
    }

    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        if (targetShip == null)
        {
            throw new ArgumentNullException(nameof(targetShip), "Target ship is null");
        }
        
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new KeyNotFoundException($"Container {serialNumber} not found");
        }

        targetShip.LoadContainer(container);
        Containers.Remove(container);
        Console.WriteLine($"Container {serialNumber} transferred");
    }

    public double GetCurrentWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
        {
            totalWeight += container.GetCompleteWeight();
        }

        return totalWeight;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(
            $"Speed: {MaxSpeed} knots, " +
            $"Max Containers: {MaxContainerCapacity}, " +
            $"Max Weight: {MaxWeightCapacity} tons"
        );
        builder.AppendLine(
            $"Current Containers: {Containers.Count}, " +
            $"Current Weight: {GetCurrentWeight()} tons"
        );

        foreach (var container in Containers)
        {
            builder.AppendLine($" - {container.SerialNumber} ({container.GetCompleteWeight()} tons)");
        }

        return builder.ToString();
    }
}