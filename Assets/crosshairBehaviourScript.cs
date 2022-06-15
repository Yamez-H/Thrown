using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairBehaviourScript : MonoBehaviour
{
    public Vector2 mousePos;
    public Vector2 crosshairPos;
    public float mouseDeltaX = 12;
    public float mouseDeltaY = 8;
    public float mouseSpeed = 1;

    public float mouseSpeedX = 1.4f;
    public float mouseSpeedY = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        crosshairPos = mousePos;
        crosshairPos = crosshairPos * (mouseSpeed );
        crosshairPos.x = (crosshairPos.x * (mouseSpeed * mouseSpeedX)) - mouseDeltaX;
        crosshairPos.y = (crosshairPos.y * (mouseSpeed * mouseSpeedY)) - mouseDeltaY;
        transform.position = crosshairPos;
    }

    public Vector2 getCrosshairPos()
    {
        return crosshairPos;
    }
}
