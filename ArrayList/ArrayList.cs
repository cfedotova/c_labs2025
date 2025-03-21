class ArrayList<T>
{
    private T[] array;
    private int count;

    public ArrayList(int initialSize = 10)
    {
        array = new T[initialSize];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == array.Length)
        {
            Resize();
        }

        array[count++] = item;
    }

    private void Resize()
    {
        int newSize = (int)(1.5 * array.Length) + 1;
        T[] newArray = new T[newSize];
        Array.Copy(array, newArray, array.Length);
        array = newArray;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException();

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        count--;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException();

        if (count == array.Length)
        {
            Resize();
        }

        for (int i = count; i > index; i--)
        {
            array[i] = array[i - 1];
        }

        array[index] = item;
        count++;
    }

    public void Clear()
    {
        count = 0;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException();
        return array[index];
    }

    public int Count => count;

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();
    }
}