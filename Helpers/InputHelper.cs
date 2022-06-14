namespace Helpers;
public static class InputHelper
{
    public static String Menu(String menu, String? title = null, String prompt = ">")
    {
        Console.Clear();
        if (title is not null)
            Console.WriteLine(title);

        Console.WriteLine(menu);
        Console.Write($"\n\n {prompt}");
        return Console.ReadLine()?.ToLower() ?? "";
    }
    public static void EnterToContinue()
    {
        Console.WriteLine("\n\n[Enter] to continue\n\n");
        Console.ReadLine();
    }

}
