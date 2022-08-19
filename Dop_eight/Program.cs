
// 8. Написать программу со следующими командами:
// - SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив - completed
// - AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву - completed
// - RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
// - Numbers – ввывод текущего массива
// - Sum – найдется сумма всех элементов чисел
// Можно добавить своих команд для работы с числовыми массивами
Console.Clear();
void SetNumbers(ref int[] myArray)
{
    myArray = Array.ConvertAll(Console.ReadLine().Split( ' ' ),int.Parse);
}
void PrintArr(ref int[] myArray)
{
    for(int i =0; i < myArray.Length; i++)
    {
        Console.Write($"{myArray[i]} ");
    }
    Console.WriteLine();
}
void AddNumbers(ref int[] myArray,ref int[]myArrayTwo,int lengt)   
{
    Array.Resize(ref myArray, (myArray.Length + myArrayTwo.Length));
    for(int i =lengt, b = 0 ; i < myArray.Length;i++,b++)
    {
        myArray[i] = myArrayTwo[b];
    }


}
int RemoveNumbers(ref int[] myArray,int number)
{
    int icopy =0;
    int[] myarr ={};
    for(int i =0; i < myArray.Length; i++)
    {
        if(myArray[i]==number)
        {       
            icopy = i;   
            int b =0;
            myarr =new int[myArray.Length - (icopy+1)];
            i++;
            while(i<myArray.Length)
            {        
                myarr[b]=myArray[i];
                b++;
                i++; 
            }
                  
        }              
    }
    Array.Resize(ref myArray,(myArray.Length-1));
    for(int c = icopy,b=0;c < myArray.Length;c++,b++)
    {           
            myArray[c] = myarr[b];
    }
    return number;
}
int Sum(int[] myArray)
{
    int sum =0;
    for(int i =0; i < myArray.Length; i++)
    {
        sum+=Convert.ToInt32(myArray[i]);
    }
    return sum;
}
bool CheckForInteraction(ref int[] myArray)
{
    bool res = true;
    if(myArray.Length==0)
    {
        Console.WriteLine("Чтобы взаимодействовать с массивом, нужно сначала добавить в него начальные элементы");
        Console.Write("Хотите это сделать?(Yes or not): ");
        string decisionAdd = Console.ReadLine();
        if(decisionAdd.ToLower() == "yes")
        {
            Console.Write("Введите числа через пробел: "); 
            SetNumbers(ref myArray);
            res = true;
        }
        else
        {
            Console.WriteLine("Добавление отменено)!");
        }
    }
    return res;
}



//*******************************GETTINGCODE//*******************************//


bool isWork = true;
int[] myArray= {};
while(isWork)
{
    Console.Write("Напишите команду(Если не знаете команд - напишите -'help'):");
    string decisionIsWork = Console.ReadLine() ;
    switch(decisionIsWork.ToLower())
    {
        case "sum":
            int sum = Sum(myArray);
            Console.WriteLine($"Сумма равна {sum}");
            break;
        case "removenumbers":
            if(CheckForInteraction(ref myArray))
            {
                while(isWork)
                {
                    Console.Write("Введите число, которое хотите удалить(Или напишите - 'exit', чтобы выйти): ");
                    string decisionNumber = Console.ReadLine();
                    if(decisionNumber.ToLower() == "exit")
                    {
                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine($"Число {RemoveNumbers(ref myArray, Convert.ToInt32(decisionNumber))} удалено!("); 
                    }                
                }
            
            }
            isWork=true;
            break;
        case "addnumbers":          
            if(CheckForInteraction(ref myArray))
            {                
                Console.Write("Введите числа через пробел, которые надо будет добавить к существующему массиву: ");
                int[] myArrayTwo =  Array.ConvertAll(Console.ReadLine().Split( ' ' ),int.Parse);
                AddNumbers(ref myArray,ref myArrayTwo,myArray.Length);
                Console.WriteLine("Числа добавлены ")  ;
            }
            break;
        case "setnumbers":
            Console.Write("Введите числа через пробел, которые мы добавим в массив: ");
            SetNumbers(ref myArray);
            Console.WriteLine("Элементы добавлены)!");
            break;
        case "numbers":
            if(CheckForInteraction(ref myArray))
            {
                PrintArr(ref myArray);  
            }           
            break;
        case "exit":
            isWork = false;
            break;
        case "help":
            Console.WriteLine("SetNumbers - запоминание чисел в массив, введенных через пробел.\n" +
                              "AddNumbers - добавление чисел к существующему массиву\n"+
                              "RemoveNumbers - удалить числа из массива, если они там имеются.\n"+
                              "Numbers - вывод текущего массива.\n"+
                              "Sum - сложиться цифры в массиве.");
            break;
    }
}