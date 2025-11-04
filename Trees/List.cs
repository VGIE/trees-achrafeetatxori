//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;
    public ListNode<T> Previous = null;
    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        ListNode<T> node = First;
        int count = 0;
        while (node != null)
        {
            node = node.Next;
            count++;
        }
        return count;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds

        if (index < 0 || index >= Count())
        {
            return default(T);
        }

        ListNode<T> node = First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node.Value;
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> node = new ListNode<T>(value);
        if (First == null)
        {
            First = node;
            Last = node;
        }
        else
        {
            node.Previous = Last;
            Last.Next = node;
            Last = node;
        }
        
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        
        ListNode<T> rNode;
        ListNode<T> node = First;
        if (index < 0 || index >= Count())
        {
            return default(T);
        }
    
        if (index == 0)
        {
            rNode = First;
            First = First.Next;
            if (First != null)
            {
                First.Previous = null;
            }
            else
            {
                Last = null;
            }
            return rNode.Value;
        }


        for (int i = 0; i < index - 1; i++)
        {
            node = node.Next;
        }
        
        rNode = node.Next;
        node.Next = rNode.Next;

        if (rNode.Next != null)
        {
            rNode.Next.Previous = node;
        }
        else
        {
            Last = node;
        }
        
        return rNode.Value;
        
    }

    public void Clear()
    {
        First = null;
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        ListNode<T> node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
            
        
    }
}