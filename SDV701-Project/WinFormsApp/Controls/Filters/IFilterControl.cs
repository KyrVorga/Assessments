namespace AdminClient.Controls.Filters
{
    public interface IFilterControl
    {
        string FilterName { get; set; }

        string FilterOperand { get; }
        string FilterValue { get; }
        //ICollection<T> FilterValues { get; set; }
    }
}