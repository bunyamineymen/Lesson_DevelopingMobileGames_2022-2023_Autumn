using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Pipe))]
public class PipeEditor : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        IMGUIContainer defaultInspector = new IMGUIContainer(() => DrawDefaultInspector());

        root.Add(defaultInspector);
        root.Add(new Label("Part Selection")
        {
            style =
            {
                marginTop = 10,
                marginBottom = 4,
                unityFontStyleAndWeight = FontStyle.Bold
            }
        });
        root.Add(CreatePartButtons());
        root.Add(new Label("Rotation")
        {
            style =
            {
                unityFontStyleAndWeight = FontStyle.Bold,
                marginBottom = 4,
            }
        });
        root.Add(CreateRotateButtons());
        return root;
    }

    private VisualElement CreatePartButtons()
    {
        VisualElement partButtons = new VisualElement()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                justifyContent = Justify.Center,
                marginBottom = 10,
                paddingTop = 5,
                paddingBottom = 5,
                borderBottomLeftRadius = 10,
                borderTopLeftRadius = 10,
                backgroundColor = new Color(0.3f, 0.3f, 0.3f)
            }
        };

        VisualElement straightPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Straight.prefab"))
        {
            text = "Straight Part"
        };
        
        VisualElement cornerPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Corner.prefab"))
        {
            text = "Corner Part"
        };
        
        VisualElement intersectionPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Intersection.prefab"))
        {
            text = "Intersection Part"
        };
        
        VisualElement ioPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-IO.prefab"))
        {
            text = "IO Part"
        };
        
        VisualElement tankPartButton = new Button(() => SetModel("Assets/Prefabs/Pipes/Pipe-Tank.prefab"))
        {
            text = "Tank Part"
        };
        
        partButtons.Add(straightPartButton);
        partButtons.Add(cornerPartButton);
        partButtons.Add(intersectionPartButton);
        partButtons.Add(ioPartButton);
        partButtons.Add(tankPartButton);

        return partButtons;
    }

    private VisualElement CreateRotateButtons()
    {
        VisualElement rotateButtons = new VisualElement()
        {
            style =
            {
                flexDirection = FlexDirection.Row,
                justifyContent = Justify.Center,
                marginBottom = 10,
                paddingTop = 5,
                paddingBottom = 5,
                borderBottomLeftRadius = 10,
                borderTopLeftRadius = 10,
                backgroundColor = new Color(0.3f, 0.3f, 0.3f)
            }
        };

        Button rotateRightButton = new Button(() => Rotate(90))
        {
            text = ">"
        };
        
        Button rotateLeftButton = new Button(() => Rotate(-90))
        {
            text = "<"
        };
        
        Button rotateOpposite = new Button(() => Rotate(180))
        {
            text = "O"
        };
        
        rotateButtons.Add(rotateLeftButton);
        rotateButtons.Add(rotateOpposite);
        rotateButtons.Add(rotateRightButton);
        return rotateButtons;
    }

    private void SetModel(string assetPath)
    {
        Pipe pipe = (Pipe) serializedObject.targetObject;
        Transform head = pipe.transform.Find("Head");

        foreach (Transform child in head)
        {
            DestroyImmediate(child.gameObject);
        }

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        GameObject gameObject = (GameObject) PrefabUtility.InstantiatePrefab(prefab);
        gameObject.transform.SetParent(head, false);
    }

    private void Rotate(float degrees)
    {
        Pipe pipe = (Pipe) serializedObject.targetObject;
        pipe.transform.Find("Head").Rotate(0, degrees, 0);
    }
}