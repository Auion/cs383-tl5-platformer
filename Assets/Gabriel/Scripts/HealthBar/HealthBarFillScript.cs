using UnityEngine;

public class HealthBarFill : MonoBehaviour
{
    // Player
    [SerializeField] GameObject player;
    private PlayerScript playerScript;

    private RectTransform _rectTransform;

    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBarFill();
    }

    void UpdateHealthBarFill()
    {
        float BarMovement = 18.88f * (9 - playerScript.health);
        _rectTransform.anchorMin = new Vector2(BarMovement, _rectTransform.anchorMin.y);
    }
}
