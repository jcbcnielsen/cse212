public class FeatureCollection
{
    public Earthquake[] Features { get; set; }
}

public class Earthquake
{
    public Data Properties { get; set; }
}

public class Data
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}