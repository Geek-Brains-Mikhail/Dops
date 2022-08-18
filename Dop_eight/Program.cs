
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
void AddNumbers(ref int[] myArray,string decision)   
{
    Array.Resize(ref myArray, (myArray.Length + 1));
    myArray[myArray.Length - 1] = Convert.ToInt32(decision);
}
void RemoveNumbers(ref int[] myArray,string number)
{
    int icopy =0;
    int[] myarr ={};
    for(int i =0; i < myArray.Length; i++)
    {
        if(myArray[i]==Convert.ToInt32(number))
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
                        RemoveNumbers(ref myArray, decisionNumber);
                        Console.WriteLine($"Число {number} удалено!("); 
                    }                
                }
            
            }
            isWork=true;
            break;
        case "addnumbers":          
            if(CheckForInteraction(ref myArray))
            {                
                while(isWork)
                {
                    Console.Write("Напишите число, которое надо добавить:(Если хотите прекратить добавлять числа - напишите 'exit'): ");
                    string decision = Console.ReadLine();
                    if(decision.ToLower() == "exit")
                    {
                        isWork = false;
                    }
                    else
                    {
                        AddNumbers(ref myArray, decision);
                        Console.WriteLine("Чило было успешно добавлено в массив!)");
                    }
                }
                isWork = true;
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
            Console.WriteLine("SetNumbers - запоминание чисел в массив, введенных через пробел.\nAddNumbers - добавление чисел к существующему массиву\nRemoveNumbers - удалить числа из массива, если они там имеются.\nNumbers - вывод текущего массива.\nSum - сложиться цифры в массиве. ")     ;
            break;
    }
}