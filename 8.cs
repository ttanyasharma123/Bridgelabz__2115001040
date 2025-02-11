using System;

class TextNode
{
    public string Content;
    public TextNode Prev;
    public TextNode Next;

    public TextNode(string content)
    {
        Content = content;
        Prev = null;
        Next = null;
    }
}

class TextEditor
{
    private TextNode current;
    private int historyLimit = 10;
    private int historyCount = 0;

    public void AddState(string content)
    {
        TextNode newState = new TextNode(content);
        if (current == null)
        {
            current = newState;
        }
        else
        {
            newState.Prev = current;
            current.Next = newState;
            current = newState;
            historyCount++;
        }
        TrimHistory();
    }

    private void TrimHistory()
    {
        while (historyCount > historyLimit)
        {
            TextNode temp = current;
            while (temp.Prev != null)
            {
                temp = temp.Prev;
            }
            temp.Next.Prev = null;
            historyCount--;
        }
    }

    public void Undo()
    {
        if (current != null && current.Prev != null)
        {
            current = current.Prev;
            Console.WriteLine("Undo: " + current.Content);
        }
        else
        {
            Console.WriteLine("No more undo available.");
        }
    }

    public void Redo()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            Console.WriteLine("Redo: " + current.Content);
        }
        else
        {
            Console.WriteLine("No more redo available.");
        }
    }

    public void DisplayCurrentState()
    {
        if (current != null)
        {
            Console.WriteLine("Current State: " + current.Content);
        }
        else
        {
            Console.WriteLine("No content available.");
        }
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();

        editor.AddState("Hello");
        editor.AddState("Hello, World");
        editor.AddState("Hello, World!");
        editor.DisplayCurrentState();

        editor.Undo();
        editor.Undo();
        editor.Redo();
        editor.DisplayCurrentState();
    }
}
