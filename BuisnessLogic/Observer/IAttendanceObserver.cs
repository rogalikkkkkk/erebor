using Erebor.Models;

namespace Erebor.Observer
{
	public abstract class IAttendanceObserver
	{
		public abstract bool IsNeedNotify(List<Attendance> attendances);
		public abstract void Notify(Attendance attendance);
		protected abstract void Execute(string virtualAddress, string text);
	}
}
