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
<<<<<<< HEAD
        public ServerMessage(string message, string messageType, string action, string option)
        {
            Message = message;
            MessageType = messageType;
            Action = action;
            Option = option;
        }
=======

>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
        public const string SuccessMessage = "success";
        public const string InfoMessage = "info";
        public const string WarningMessage = "warning";
        public const string DangerMessage = "danger";
    }
}
