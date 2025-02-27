using UnityEngine;
using TMPro;

public class FruitManager : MonoBehaviour
{
    public static FruitManager Instance { get; private set; }

    private int _fruitCount;
    [SerializeField] private TextMeshProUGUI _fruitCounterText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        _fruitCount++;
        _fruitCounterText.text = $"Fruit: {_fruitCount}";
    }
}