using TMPro;
using UnityEngine;

public static class Util
{
    public static Vector3 GetMouseWorldPosition2D()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera camera)
    {
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    public static TextMeshPro CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default,
        int fontSize = 12, Color? color = null,
        TextAlignmentOptions textAlignment = TextAlignmentOptions.TopLeft, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAlignment, sortingOrder);
    }
    public static TextMeshPro CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize,
        Color color, TextAlignmentOptions textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMeshPro));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMeshPro textMesh = gameObject.GetComponent<TextMeshPro>();
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    public static RaycastHit2D Raycast2DFromMainToMouse()
    {
        return Raycast2DFromMain(Input.mousePosition);
    }
    public static RaycastHit2D Raycast2DFromMainToMouse(float distance)
    {
        return Raycast2DFromMain(Input.mousePosition, distance);
    }
    public static RaycastHit2D Raycast2DFromMain(Vector3 targetPosition)
    {
        return Raycast2DFromCamera(Camera.main, targetPosition);
    }
    public static RaycastHit2D Raycast2DFromMain(Vector3 targetPosition, float distance)
    {
        return Raycast2DFromCamera(Camera.main, targetPosition, distance);
    }
    public static RaycastHit2D Raycast2DFromCamera(Camera camera, Vector3 targetPosition)
    {
        return Raycast2DFromCamera(camera, targetPosition);
    }
    public static RaycastHit2D Raycast2DFromCamera(Camera camera, Vector3 targetPosition, float distance = Mathf.Infinity)
    {
        Vector3 cameraPosition = camera.transform.position;
        // make sure the raycast is on 2d plane
        Vector3 direction = GetMouseWorldPositionWithZ();
        RaycastHit2D hit = Physics2D.Raycast(cameraPosition, direction, distance);
        return hit;
    }
}
