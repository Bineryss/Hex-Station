using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RessourcesManager : MonoBehaviour
{
    [SerializeField] private int Hex;
    [SerializeField] private int Square;
    [SerializeField] private int Rhombus;
    [SerializeField] private UIDocument root;

    private Label hex;

    public static RessourcesManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        hex = root.rootVisualElement.Q<Label>("hex");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseHex(int amount = 1)
    {
        Hex += amount;
        hex.text = Hex.ToString();
    }
}
