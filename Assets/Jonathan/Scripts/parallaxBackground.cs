using UnityEngine;

public class ParallaxVertical : MonoBehaviour
{
    public Transform player;
    public float parallaxEffectMultiplier = 0.1f;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += new Vector3(0, deltaMovement.y * parallaxEffectMultiplier, 0);
        lastPlayerPosition = player.position;
    }
}
