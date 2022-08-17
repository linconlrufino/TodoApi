namespace Shared.Commands;

public interface ICommand
{
    bool Validate(out List<string> validationsErrors);
}
