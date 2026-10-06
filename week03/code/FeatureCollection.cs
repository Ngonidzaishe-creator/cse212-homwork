public class FeatureCollection
{
    public string Type { get; set; }
    public Feature[] Features { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}
