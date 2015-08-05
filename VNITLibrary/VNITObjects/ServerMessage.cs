namespace VNITLibrary
{
    public class ServerMessage
    {
        public string Message { get; set; }
        public string MessageType { get; set; }
        public string Action { get; set; }
        public string Option { get; set; }

        public ServerMessage() { }
        public ServerMessage(string message, string messageType = SuccessMessage)
        {
            Message = message;
            MessageType = messageType;
        }
        public ServerMessage(string message, string messageType, string action, string option)
        {
            Message = message;
            MessageType = messageType;
            Action = action;
            Option = option;
        }
        public const string SuccessMessage = "success";
        public const string InfoMessage = "info";
        public const string WarningMessage = "warning";
        public const string DangerMessage = "danger";
    }
}
