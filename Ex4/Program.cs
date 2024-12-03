﻿namespace Ex4
{
    internal class Program
    {
        const string MsgInpRectangleWidth = "Introdueix l'amplada del rectangle:";
        const string MsgInpRectangleHeight = "Introdueix l'altura del rectangle:";
        const string MsgRectangleArea = "L'àrea del rectangle és: ";
        const string MsgInpCircleRadius = "Introdueix el radi del cercle:";
        const string MsgCircumferenceCircle = "La circumferència del cercle és: ";
        const string MsgAreaHigher = "L'àrea és més gran de 50";
        const string MsgAreaBetween = "L'àrea és entre 20 i 50";
        const string MsgAreaLower = "L'àrea és menor o igual a 20";
        static void Main(string[] args)
        {
            double width = 0, height = 0, area = 0, radius = 0, circumference = 0;

            // Sol·licita l'entrada de l'usuari per calcular l'àrea d'un rectangle
            Console.WriteLine(MsgInpRectangleWidth);
            width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(MsgInpRectangleHeight);
            height = Convert.ToDouble(Console.ReadLine());

            // Calcula l'àrea
            area = width * height;
            Console.WriteLine(MsgRectangleArea + area);

            // Sol·licita l'entrada de l'usuari per calcular la circumferència d'un cercle
            Console.WriteLine(MsgInpCircleRadius);
            radius = Convert.ToDouble(Console.ReadLine());
            circumference = 2 * Math.PI * radius;

            Console.WriteLine(MsgCircumferenceCircle + circumference);

            // Imprimeix un missatge basat en el valor de l'àrea
            if (area > 50)
            {
                Console.WriteLine(MsgAreaHigher);
            }
            else if (area > 20)
            {
                Console.WriteLine(MsgAreaBetween);
            }
            else
            {
                Console.WriteLine(MsgAreaLower);
            }
        }
    }
}