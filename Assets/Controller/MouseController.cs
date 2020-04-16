using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject MouseCursor;

    private Vector2 lastFramePosition;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
    }

    void Update()
    {
        Vector2 currentFramePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Tile tileUnderMouse = GetTileAtWorldCoordinates(currentFramePosition);
        if (tileUnderMouse != null)
        {
            MouseCursor.SetActive(true);
            Vector2 newCursorPosition = new Vector2(tileUnderMouse.X, tileUnderMouse.Y);
            MouseCursor.transform.position = newCursorPosition;
        }
        else
            MouseCursor.SetActive(false);


        if (Input.GetMouseButton(1))
        {
            Vector2 diff = lastFramePosition - currentFramePosition;
            mainCamera.transform.Translate(diff);
        }

        lastFramePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Tile GetTileAtWorldCoordinates(Vector2 position)
    {
        int x = Mathf.FloorToInt(position.x);
        int y = Mathf.FloorToInt(position.y);

        return WorldController.Instance.GetTileAt(x, y);
    }
}