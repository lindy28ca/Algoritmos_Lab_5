using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectorDePersonajes : MonoBehaviour
{
    [SerializeField] Image[] images;
    DoubleCircularLinkedList<Image> selector = new DoubleCircularLinkedList<Image>();

    Node<Image> currentNode;

    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        for (int i = 0; i < images.Length; ++i)
        {
            selector.Add(images[i]);
        }
        currentNode = selector.head;
        UpdateVisuals();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentNode = currentNode.Prev;
            UpdateVisuals();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentNode = currentNode.Next;
            UpdateVisuals();
        }
    }

    private void UpdateVisuals()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1, 1, 1, 0.4f); 
        }

        currentNode.Value.color = new Color(1, 1, 1, 1f);
        text.text = "" + currentNode.Value.name;
    }
}
