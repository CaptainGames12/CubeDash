
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EditManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _showingDepth;
    public InputActionReference deleteBlockAction;
    public InputActionReference mouseFOV;
    public GameObject addableBlock;
    public GameObject chosenBlock;
    public float cameraDepth = 0f;
    public Camera mainCamera;
    
    private Vector3 worldPos;
    private bool _blockIsCreating;
    void FixedUpdate()
    {
        cameraDepth += Mathf.Clamp(mouseFOV.action.ReadValue<Vector2>().normalized.y, -1f, 1f);
        _showingDepth.text = "Distance of mouse: " + cameraDepth.ToString();
        Vector3 posWithDepth = new(CameraManagerEditMode.ClampedMousePos().x, CameraManagerEditMode.ClampedMousePos().y, cameraDepth);
        worldPos = mainCamera.ScreenToWorldPoint(posWithDepth);
        if (Mouse.current.leftButton.isPressed)
        {
            PlaceOrMoveBlock();
        }
        else
        {
            _blockIsCreating = false;
        }
        if (deleteBlockAction.action.IsPressed())
        {
            Destroy(chosenBlock);
        }

    }
    void PlaceOrMoveBlock()
    {
        if (chosenBlock == null && !_blockIsCreating)
        {
            _blockIsCreating = true;
            GameObject instantiatedBlock = Instantiate(addableBlock);

            DontDestroyOnLoad(instantiatedBlock);
            instantiatedBlock.transform.position = worldPos;
        }
        else if (chosenBlock != null)
        {
            chosenBlock.transform.position = worldPos;
        }

    }
    public void ChangeBlock(GameObject block)
    {
        addableBlock = block;
    }
    
}
