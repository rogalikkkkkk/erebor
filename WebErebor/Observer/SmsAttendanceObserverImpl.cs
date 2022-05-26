namespace Erebor.Observer
{
    public class SmsAttendanceObserverImpl : SmsAttendanceObserver
    {
        private ILogger<SmsAttendanceObserver> _logger;

        public SmsAttendanceObserverImpl(ILogger<SmsAttendanceObserver> logger)
        {
            _logger = logger;
        }

        protected override void Execute(string virtualAddress, string text)
        {
            _logger.LogInformation("\nPhone: {ST}\n{t}\n", virtualAddress, text);
        }
    }
}
