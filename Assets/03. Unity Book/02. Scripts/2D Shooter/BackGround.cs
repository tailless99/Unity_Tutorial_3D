using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material bgMaterial;

    public float scrollSpeed = .2f;

    private void Update() {
        Vector2 dir = Vector2.up;

        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
