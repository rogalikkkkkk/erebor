using BuisnessLogic.Observer;

namespace WebErebor.Observer
{
	public class EmailAttendanceObserverImpl : EmailAttendanceObserver
	{
		private ILogger<EmailAttendanceObserver> _logger;

		public EmailAttendanceObserverImpl(ILogger<EmailAttendanceObserver> logger)
		{
			_logger = logger;
		}

		protected override void Execute(string virtualAddress, string text)
		{
			_logger.LogInformation("\nEmail: {ST}\n{t}\n", virtualAddress, text);
		}
	}
}
