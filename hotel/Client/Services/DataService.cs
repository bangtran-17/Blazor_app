namespace Hotel.Client.Services
{
	public class DataService
	{
		public event Action OnEditFormSubmitted;

		public void TriggerEditFormSubmitted()
		{
			OnEditFormSubmitted?.Invoke();
		}
	}
}
