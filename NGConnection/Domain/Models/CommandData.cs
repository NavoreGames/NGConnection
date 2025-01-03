using NGConnection.Interfaces;

namespace NGConnection.Models
{
	public class CommandData
	{
		public Guid Identifier { get; protected set; }
        public Enums.CommandType CommandType { get; protected set; }
        public Type ConnectionType { get; protected set; }
        public ICommand Command { get; set; }

        internal CommandData() { }
        public CommandData(Enums.CommandType commandType, ICommand command) 
        { 
            Identifier = Guid.NewGuid();
            CommandType = commandType;
            Command = command;
        }

        public CommandData SetCommand(Type connectionType)
        {
            return new()
            {
                Identifier = this.Identifier,
                CommandType = this.CommandType,
                ConnectionType = connectionType,
                Command = this.Command.SetCommand(connectionType)
            };
        }

        public override string ToString() => Command.ToString();
    }
}
