using System.Runtime.InteropServices.JavaScript;

namespace CellularAutomata;

public class StateMachine<TState, TInput>
{
    public TState CurrentState { get; private set; }
    private readonly Dictionary<TState, List<Transition>> _transitions = new();
    public StateMachine(TState initialState)
    {
         CurrentState = initialState;
    }

    public void AddTransition(TState from, TState to, Func<TInput, bool> condition)
    {
        if (!_transitions.TryGetValue(from, out var transitions))
        {
            transitions = new();
            _transitions[from] = transitions;
        }
        transitions.Add(new(condition, to));
    }

    public void Step(TInput input)
    {
        if (!_transitions.TryGetValue(CurrentState, out var transitions))
            return;
        foreach (var transition in transitions)
        {
            if (!transition.Condition(input)) continue;
            CurrentState = transition.Target;
            return;
        }
    }
    private record Transition(Func<TInput, bool> Condition, TState Target);
}