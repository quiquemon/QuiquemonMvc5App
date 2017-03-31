namespace QuiquemonMvc5App.Controllers
{
	public abstract class MessageType
	{
		public bool Success { get; protected set; }
		public string Message { get; protected set; }
	}

	public class SuccessMessage : MessageType
	{
		public SuccessMessage(string message)
		{
			Success = true;
			Message = message;
		}
	}

	public class SuccessMessageWithValue<T> : SuccessMessage
	{
		public T Value { get; private set; }

		public SuccessMessageWithValue(string message, T value) : base(message)
		{
			Value = value;
		}
	}

	public class ErrorMessage : MessageType
	{
		public ErrorMessage(string message)
		{
			Success = false;
			Message = message;
		}
	}

	public class ErrorMessageWithValue<T> : ErrorMessage
	{
		public T Value { get; private set; }

		public ErrorMessageWithValue(string message, T value) : base(message)
		{
			Value = value;
		}
	}
}