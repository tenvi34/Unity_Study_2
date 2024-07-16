using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JWT_Tool_Editor : EditorWindow
{
    private CommandManager_JWT _commandManagerJwt = new CommandManager_JWT();
    private Material material;
    //private Color basicColor = Color.white;
    private float colorSliderValue = 1.0f;
    private GameObject selectedObject;
    
    private float rValue = 1.0f;
    private float gValue = 1.0f;
    private float bValue = 1.0f;

    [MenuItem("Tools/JWT Tool")]
    public static void ShowWindow()
    {
        GetWindow<JWT_Tool_Editor>("JWT Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Command Tool", EditorStyles.boldLabel);

        // 선택한 게임 오브젝트 표시
        selectedObject = EditorGUILayout.ObjectField("Target Object", selectedObject, typeof(GameObject), true) as GameObject;
        
        if (selectedObject != null)
        {
            _commandManagerJwt.Owner = selectedObject;
            material = selectedObject.GetComponent<UnityEngine.Renderer>()?.material;
        }

        if (material == null)
        {
            EditorGUILayout.HelpBox("게임 오브젝트 추가", MessageType.Warning);
            return;
        }

        // 이동 버튼들
        if (GUILayout.Button("X 이동"))
        {
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(1, 0, 0)));
        }

        if (GUILayout.Button("Y 이동"))
        {
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(0, 1, 0)));
        }

        if (GUILayout.Button("Z 이동"))
        {
            _commandManagerJwt.ExecuteCommand(new MoveCommand_JWT(new Vector3(0, 0, 1)));
        }

        // 회전 버튼들
        if (GUILayout.Button("X 회전"))
        {
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(30, 0, 0)));
        }

        if (GUILayout.Button("Y 회전"))
        {
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(0, 30, 0)));
        }

        if (GUILayout.Button("Z 회전"))
        {
            _commandManagerJwt.ExecuteCommand(new RotateCommand_JWT(new Vector3(0, 0, 30)));
        }

        // Undo 버튼
        if (GUILayout.Button("Undo"))
        {
            _commandManagerJwt.UndoCommand();
        }

        // RGB 색상 변경 슬라이더
        GUILayout.Label("R G B 색상 코드");

        float newRValue = EditorGUILayout.Slider("R", rValue, 0, 1);
        float newGValue = EditorGUILayout.Slider("G", gValue, 0, 1);
        float newBValue = EditorGUILayout.Slider("B", bValue, 0, 1);

        if (Mathf.Abs(newRValue - rValue) > 0.01f || Mathf.Abs(newGValue - gValue) > 0.01f || Mathf.Abs(newBValue - bValue) > 0.01f)
        {
            rValue = newRValue;
            gValue = newGValue;
            bValue = newBValue;
        
            Color newColor = new Color(rValue, gValue, bValue);
            var colorChangeCommand = new ChangeColorCommand_JWT(material, newColor);
            _commandManagerJwt.ExecuteCommand(colorChangeCommand);
        }
    }
}
