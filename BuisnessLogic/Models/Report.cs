namespace Erebor.Models
{
    public class Report<T>
    {
        public List<ReportEntity<T>> Data { get; set; }
    }
}
