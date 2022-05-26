namespace Erebor.Models
{
    public class ReportEntity<T>
    {
        public T Entity { get; set; }
        public bool Attanded { get; set; }
        public int Grade { get; set; }

    }
}
