List<string> lista = new();
try
{
    StreamReader sr = new StreamReader(".\\binarne.txt");
    string line = sr.ReadLine();
    while (line != null)
    {
        lista.Add(line);
        line = sr.ReadLine();
    }
    sr.Close();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    //sortowanie
    lista = lista.OrderByDescending(x => x.Length).ToList();
    //numerowanie
    for (int i = 0; i < lista.Count(); i++)
    {
        lista[i] = $"{i.ToString().PadLeft(3, '0')} {lista[i]}";
    }
    //znajdywanie lini

    for (int i = 0; i < lista.Count; i++)
    {
        string binaryLine = lista[i];
        for (int j = 0; j <= binaryLine.Length - 4; j++)
        {
            int onesCount = 0;
            for (int k = j; k < j + 4; k++) if (binaryLine[k] == '1') onesCount++;
            if (onesCount >= 4) Console.WriteLine($"Found at index {i}, starting at position {j} horizontally.");
        }
        for (int j = 0; j < binaryLine.Length; j++)
        {
            int onesCount = 0;
            for (int k = i; k < lista.Count; k++) if (lista[k][j] == '1') onesCount++;
            if (onesCount >= 4) Console.WriteLine($"Found at index {i}, starting at position {j} vertically.");
        }
    }

    //all one and zero
    List<string> AllOne = new();
    List<string> AllZero = new();
    foreach (string l in lista)
    {
        bool isAllOne = true;
        bool isAllZero = true;
        for (int i = 4; i < l.Length; i++)
        {
            char c = l[i];
            if (c != '1') isAllOne = false;
            if (c != '0') isAllZero = false;
        }
        if (isAllOne) AllOne.Add(l);
        if (isAllZero) AllZero.Add(l);
    }
    //output
    //for (int i = 0; i < lista.Count(); i++)
    //{
    //    Console.WriteLine(lista[i]);
    //}
    //for (int i = 0; i < AllOne.Count(); i++)
    //{
    //    Console.WriteLine(AllOne[i]);
    //}
    //for (int i = 0; i < AllZero.Count(); i++)
    //{
    //    Console.WriteLine(AllZero[i]);
    //}

    static void FindLinesWithFourOrMoreOnes(List<string> binaryValues, int minOnesInLine)
    {
        
    }
}
