namespace NetsSharp
{
    using System;

    public interface IEndpoints
    {
        Uri Register { get; }
        Uri Process { get; }
        Uri Query { get; }
        Uri Terminal { get; }
    }
}