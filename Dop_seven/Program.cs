//7. Написать функцию Shuffle, которая перемешивает элементы массива в случайном порядке.
int[] Shuffle(int[] arr)
{
    int temporaryVariable;
    int randomIndex;
    for(int i =0; i < arr.Length; i++)
    {
        randomIndex =new Random().Next(0,arr.Length);
        temporaryVariable = arr[i];
        arr[i] = arr[randomIndex];
        arr[randomIndex] = temporaryVariable;
    }
    return arr;
}
void PrintArr(int[] arr)
{
    for(int i =0; i < arr.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
}
int[] myArray = {1,2,3,4,5,6,7,8,9,10};
PrintArr(Shuffle(myArray));
