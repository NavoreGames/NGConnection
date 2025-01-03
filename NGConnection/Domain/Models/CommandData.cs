using NGConnection.Interfaces;

namespace NGConnection.Models
{
	public class CommandData
	{
		internal Guid Identifier { get; set; }
        internal Enums.CommandType CommandType { get; set; }
        internal Type ConnectionType { get; set; }
        internal ICommand Command { get; set; }

        internal CommandData() { }
        internal CommandData(Enums.CommandType commandType, ICommand command) 
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
