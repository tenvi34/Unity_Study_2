using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void SetOwner(GameObject gameObject);
    void Excute();
    void Undo();
}

public abstract class Command : ICommand
{
    public GameObject Owner;

    public void SetOwner(GameObject gameObject)
    {
        Owner = gameObject;
    }
    public abstract void Excute();
    public abstract void Undo();
}

public class MoveCommand : Command
{
    private Vector3 movePosition = new Vector3(10, 0, 0);
    
    public override void Excute()
    {
        Owner.transform.position += movePosition;
    }

    public override void Undo()
    {
        Owner.transform.position += -movePosition;
    }
}

public class CommandManager
{
    public GameObject Owner;
    
    private Stack<ICommand> History = new Stack<ICommand>();

    public void Excute(ICommand command)
    {
        command.SetOwner(Owner);
        command.Excute();
        History.Push(command);
    }

    public void Undo()
    {
        if (History.Count > 0)
        {
            History.Pop().Undo();
        }
    }
}

public class CommandPattern : MonoBehaviour
{
    private CommandManager _commandManager = new CommandManager();
    
    // Start is called before the first frame update
    void Start()
    {
        _commandManager.Owner = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _commandManager.Excute(new MoveCommand());
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            _commandManager.Undo();
        }
    }
}
