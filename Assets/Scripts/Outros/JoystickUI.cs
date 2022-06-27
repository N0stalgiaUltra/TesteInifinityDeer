using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class JoystickUI : MonoBehaviour, IPointerUpHandler, IPointerDownHandler , IDragHandler
{
    [SerializeField] private RectTransform movementJoystick;

    [SerializeField]
    private float dragThreshold = 0.6f;
    [SerializeField]
    private int dragMovementDistance = 30;
    [SerializeField]
    private int dragOffsetDistance = 100; 

    public event Action<Vector3> OnMove;


    private Vector3 moveInput;

    [SerializeField] private Button shootButton;
    [SerializeField] private Button healButton;

    private void Start()
    {
    }

    #region Movimento via AnalogStickUI
    /// <summary>
    /// Utilizado quando o analog stick é solto, resentando as posições.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        movementJoystick.anchoredPosition = Vector3.zero;
        OnMove?.Invoke(Vector3.zero);
    }

    /// <summary>
    /// Utilizado para fazer o movimento do drag do analog stick e também atribuir movimento ao player via evento
    /// </summary>
    /// <param name="eventData">Dados do objeto a ser manipulado, no caso, o stick menor (branco)</param>
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            movementJoystick,
            eventData.position,
            eventData.pressEventCamera,
            out offset
            );
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        movementJoystick.anchoredPosition = offset * dragMovementDistance;
        print(offset);
        moveInput = MovementInput(offset);
        OnMove?.Invoke(moveInput);
    }

    /// <summary>
    /// Usado somente para não travar o analog stick em uma posição
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    /// <summary>
    /// Método responsável por calcular e retornar um Vector3 para movimentar o player
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public Vector3 MovementInput(Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > dragThreshold ? offset.x : 0;
        float z = Mathf.Abs(offset.y) > dragThreshold ? offset.y : 0;
        return new Vector3(x, 0, z);
    }
    #endregion

 
}
