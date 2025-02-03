namespace CellularAutomata;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main2()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }

    public enum States
    {
        Still,
        Walking,
        Running
    }
    public static bool Condition1(int a) => a == 2;
    public static void Main()
    {
        StateMachine<States, int> stateMachine = new StateMachine<States, int>(States.Still);
        stateMachine.AddTransition(States.Still, States.Walking, i => i == 2);
        Console.WriteLine(stateMachine.CurrentState);
        stateMachine.Step(4);
        Console.WriteLine(stateMachine.CurrentState);
        stateMachine.Step(2);
        Console.WriteLine(stateMachine.CurrentState);

    }
}