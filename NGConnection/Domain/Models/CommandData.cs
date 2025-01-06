using NGConnection.Interfaces;

namespace NGConnection.Models
{
	public class CommandData
	{
		public Guid Identifier { get; protected set; }
        public Enums.CommandType CommandType { get; protected set; }
        public ICommand Command { get; set; }

        internal CommandData() { }
        public CommandData(Guid identifier, Enums.CommandType commandType, ICommand command)
        {
            Identifier = identifier;
            CommandType = commandType;
            Command = command;
        }
        public CommandData(Enums.CommandType commandType, ICommand command) 
        { 
            Identifier = Guid.NewGuid();
            CommandType = commandType;
            Command = command;
        }

        public override string ToString() => Command.ToString();
    }
}
