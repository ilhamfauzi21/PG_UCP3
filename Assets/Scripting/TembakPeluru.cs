using UnityEngine;
using UnityEngine.InputSystem;

public class TembakPeluru : MonoBehaviour
{
    public GameObject peluru;

    public InputActionAsset inputActions;

    private InputAction tembakAction;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tembakAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (tembakAction.WasReleasedThisFrame())
        {
            Tembak();
        }
    }

    void Tembak()
    {
        Instantiate(peluru, transform.position, peluru.transform.rotation);
    }
}
