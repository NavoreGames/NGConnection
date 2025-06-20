using NGConnection.Models;

namespace NGConnection.Interfaces;

public interface ICommand
{
   Guid Identifier { get; }
   Enums.CommandType CommandType { get; }
   string Query { get; set; }
   List<ConnandParameter> DataParameters { get; set; }
   string Name { get; }
   string Alias { get; }

    void SetCommand(IConnection connection);
}
