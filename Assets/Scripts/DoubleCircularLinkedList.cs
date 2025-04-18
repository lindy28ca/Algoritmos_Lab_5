using UnityEngine;

public class DoubleCircularLinkedList<T> : MonoBehaviour
{
    public Node<T> lastNode = null;

    public Node<T> head = null;

    public int count = 0;

    /* public DoubleCircularLinkedList (T value)
     {
    
     }*/

    public virtual void Add(T newValue)
    {
        Node<T> newNode = new Node<T>(newValue);

        count++;
        if (head == null)
        {
            lastNode = newNode;


            head = newNode;
            head.SetNext(head);
            head.SetPrev(head);
            return;
        }
        lastNode.SetNext(newNode);

        newNode.SetPrev(lastNode);

        lastNode = newNode;

        head.SetPrev(lastNode);
        lastNode.SetNext(head);
    }
    public virtual void ShowAllElements(Node<T> element = null, int _count = 0)
    {
        if (element == null)
        {
            element = head;
        }
        if (_count == count)
        {
            print("Se recorrio toda la lista");
            return;
        }
        print("Node name:" + element.Value.ToString());

        ShowAllElements(element.Next, _count++);
    }
}

public class Node<T>
{
    #region Private
    private T value;
    private Node<T> next = null;
    private Node<T> prev = null;
    #endregion
    #region Getters
    public T Value => value;
    public Node<T> Next => next;
    public Node<T> Prev => prev;
    #endregion
    #region Setter
    public Node(T _value)
    {
        value = _value;
    }

    public void SetNext(Node<T> _next)
    {
        next = _next;
    }
    public void SetPrev(Node<T> _prev)
    {
        prev = _prev;
    }
    #endregion
}
