using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Header("Backgrounds")]
    [SerializeField] private Transform fondoActual;
    [SerializeField] private Transform fondoAuxiliar;

    [Header("Scroll Settings")]
    [SerializeField] private float scrollSpeed = 2f;

    private float spriteWidth;
    private float startX;

    void Start()
    {
        spriteWidth = fondoActual.GetComponent<SpriteRenderer>().bounds.size.x;
        startX = fondoActual.position.x;
    }

    void Update()
    {
        float move = scrollSpeed * Time.deltaTime;

        fondoActual.position += Vector3.left * move;
        fondoAuxiliar.position += Vector3.left * move;

        if (fondoActual.position.x < startX - spriteWidth)
        {
            SwapBackgrounds();
        }
    }

    void SwapBackgrounds()
    {
        Transform temp = fondoActual;
        fondoActual = fondoAuxiliar;
        fondoAuxiliar = temp;

        fondoAuxiliar.position = new Vector3(
            fondoActual.position.x + spriteWidth,
            fondoActual.position.y,
            fondoActual.position.z
        );
    }
}