using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// This class defines Spider behaviour by sending it specified action commands
/// Implementers of this class can invoke events which can be listened by spider to do these actions
/// Its basically brain of spider sending commands to its body (hence the naming)
/// </summary>
public abstract class SpiderBrain : MonoBehaviour
{
    public event EventHandler Jump;
    
    public event EventHandler Movement;
    
    protected void InvokeJump()
    {
        Jump?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Invokes Movement with given normalized movement vector
    /// </summary>
    /// <param name="movement">Normalized movement vector</param>
    protected void InvokeMovement(Vector2 movement)
    {
        // I should pass movement as event agr but eh Ill do it later
        Movement?.Invoke(this, EventArgs.Empty);
    }


    /// <summary>
    /// Abstract method designated to return movement vector2
    /// </summary>
    /// <returns>Normalized movement vector2</returns>
    public abstract Vector2 GetMovement();
}
