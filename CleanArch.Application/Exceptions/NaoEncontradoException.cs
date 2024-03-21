namespace CleanArch.Application;

public class NaoEncontradoException : Exception
{
    public NaoEncontradoException(string? message) : base(message)
    { }
}
