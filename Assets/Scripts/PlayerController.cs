using BorsalinoTools;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 m_inputMove;

    public void Start()
    {
        CommandsConsole.logAction += ResetPlayerCommand;
        CommandsConsole.RegisterCommand("ResetPlayer");
    }

    public void OnDestroy()
    {
        BorsalinoTools.CommandsConsole.logAction -= ResetPlayerCommand;
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            m_inputMove = ctx.ReadValue<Vector2>();
        }
        if (ctx.canceled)
        {
            m_inputMove = Vector2.zero;
        }
    }

    public void Update()
    {
        transform.position += (Vector3)m_inputMove * speed * Time.deltaTime;
    }

    public void ResetPlayerCommand(string s, object[] parameters)
    {
        if (s == "ResetPlayer")
        {
            transform.position = Vector3.zero;
        }
    }



}
