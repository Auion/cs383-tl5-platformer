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
        _rectTransform.anchorMin = new Vector2(0, _rectTransform.anchorMin.y);
        _rectTransform.anchorMax = new Vector2(0, _rectTransform.anchorMax.y);
        _rectTransform.pivot = new Vector2(0, _rectTransform.pivot.y);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBarFill();
    }

    void UpdateHealthBarFill()
    {
        float newWidth = playerScript.health / 9f;
        newWidth *= 173f;
        _rectTransform.sizeDelta = new Vector2(newWidth, _rectTransform.sizeDelta.y);
    }
}