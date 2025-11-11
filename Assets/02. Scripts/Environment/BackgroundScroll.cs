using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public Material BackgroundMaterial;
    public float scrollSpeed = 0.1f;

    private void Start()
    {
        BackgroundMaterial = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        Vector2 direction = Vector2.up;
        BackgroundMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
