namespace ElevatorSim
{
    public interface  IElevatorCommand
    {
        Elevator _elevator { get; };

        void Execute();
    }
}