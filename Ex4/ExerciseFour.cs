using System;

class ExerciseFour
{
    static void None(string[] args)
    {
        // Sol�licita l'entrada de l'usuari per calcular l'�rea d'un rectangle
        Console.WriteLine("Introdueix l'amplada del rectangle:");
        double width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Introdueix l'altura del rectangle:");
        double height = Convert.ToDouble(Console.ReadLine());

        // Calcula l'�rea
        double area = width * height;
        Console.WriteLine("L'�rea del rectangle �s: " + area);

        // Sol�licita l'entrada de l'usuari per calcular la circumfer�ncia d'un cercle
        Console.WriteLine("Introdueix el radi del cercle:");
        double radius = Convert.ToDouble(Console.ReadLine());
        double circumference = 2 * Math.PI * radius;

        Console.WriteLine("La circumfer�ncia del cercle �s: " + circumference);

        // Imprimeix un missatge basat en el valor de l'�rea
        if (area > 50)
        {
            Console.WriteLine("L'�rea �s m�s gran de 50");
        }
        else if (area > 20)
        {
            Console.WriteLine("L'�rea �s entre 20 i 50");
        }
        else
        {
            Console.WriteLine("L'�rea �s menor o igual a 20");
        }
    }
}