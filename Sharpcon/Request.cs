namespace Sharpcon
{
    class Request
    {
        public int Identifier;
        public string Message;
        public string Name;

        public Request(string message, int identifier = 1, string name = "WebRcon")
        {
            Identifier = identifier;
            Message = message;
            Name = name;
        }
    }
}
