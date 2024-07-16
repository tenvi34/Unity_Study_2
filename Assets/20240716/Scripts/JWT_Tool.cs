using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICommand_JWT
{
    void SetOwner(GameObject gameObject);
    void Execute();
    void Undo();
}

public abstract class Command_JWT : ICommand_JWT
{
    public GameObject Owner;

    public void SetOwner(GameObject gameObject)
    {
        Owner = gameObject;
    }
    public abstract void Execute();
    public abstract void Undo();
}

public class MoveCommand_JWT : Command_JWT
{
    private Vector3 movePosition;

    public MoveCommand_JWT(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
    
    public override void Execute()
    {
        Owner.transform.position += movePosition;
    }

    public override void Undo()
    {
        Owner.transform.position -= movePosition;
    }
}

public class RotateCommand_JWT : Command_JWT
{
    public Vector3 rotation;

    public RotateCommand_JWT(Vector3 rotation)
    {
        this.rotation = rotation;
    }
    
    public override void Execute()
    {
        Owner.transform.Rotate(rotation);
    }

    public override void Undo()
    {
        Owner.transform.Rotate(-rotation);
    }
}

public class ChangeColorCommand_JWT : Command_JWT
{
    private Material material;
    private Color color;
    private Color _previousColor;

    public ChangeColorCommand_JWT(Material material, Color newColor)
    {
        this.material = material;
        this.color = newColor;
    }

    public override void Execute()
    {
        _previousColor = material.color;
        material.color = color;
    }

    public override void Undo()
    {
        material.color = _previousColor;
    }
}

public class CommandManager_JWT
{
    public GameObject Owner;

    private Stack<ICommand_JWT> History = new Stack<ICommand_JWT>();

    public void ExecuteCommand(ICommand_JWT command)
    {
        command.SetOwner(Owner);
        command.Execute();
        History.Push(command);
    }

    public void UndoCommand()
    {
        if (History.Count > 0)
        {
            Debug.Log("Undo 실행");
            History.Pop().Undo();
        }
        else
        {
            Debug.Log("이전 기록이 없습니다.");
        }
    }
}

public class JWT_Tool : MonoBehaviour
{
    private CommandManager_JWT _commandManagerJwt = new CommandManager_JWT();
    
    private Material material;
    public Slider colorSlider;
    public Color basicColor = Color.white;
    
    void Start()
    {
        _commandManagerJwt.Owner = this.gameObject;
        material = _commandManagerJwt.Owner.GetComponent<UnityEngine.Renderer>().material;
        
        colorSlider.onValueChanged.AddListener(SliderColorChange);
    }

    void Update()
    {
        // 이동
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(1, 0 ,0)));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(0, 1 ,0)));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(0, 0 ,1)));
        }
        
        // 회전
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(30, 0 ,0)));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(0, 30 ,0)));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("6번 버튼 클릭");
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(0, 0 ,30)));
        }

        // Undo
        if (Input.GetKeyDown(KeyCode.U))
        {
            _commandManagerJwt.UndoCommand();
        }
    }

    void SliderColorChange(float value)
    {
        Color newColor = basicColor * value;
        var colorChangeCommand = new ChangeColorCommand_JWT(material, newColor);
        colorChangeCommand.SetOwner(_commandManagerJwt.Owner);
        _commandManagerJwt.ExecuteCommand(colorChangeCommand);
    }
}
