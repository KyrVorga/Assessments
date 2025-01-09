public class FilterCriteria
{
    public string FilterName { get; set; }
    public string Operation { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
        return $"{FilterName}={Operation}:{Value}";
    }
}
