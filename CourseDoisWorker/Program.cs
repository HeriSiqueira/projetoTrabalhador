using System;
using CourseDoisWorker.Entities.Enums;
using CourseDoisWorker.Entities;
using System.Globalization;

namespace CourseDoisWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Leval (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker trabalhador = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("Quantos contratos esse trabalhador terá? ");
            int quCon = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quCon; i++)
            {
                Console.WriteLine($"Entre com os dados do contrato #{i}");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int horas = int.Parse(Console.ReadLine());

                HourContract contrato = new HourContract(date, valorPorHora, horas);

                trabalhador.AddContract(contrato);
            }

            Console.WriteLine();
            Console.Write("Entre com o mês e ano (MM/YYYY) para calcular o ganho: ");
            string mesEAnno = Console.ReadLine();
            int mes = int.Parse(mesEAnno.Substring(0, 2));
            int ano = int.Parse(mesEAnno.Substring(3));
            Console.WriteLine("Nome: " + trabalhador.Name);
            Console.WriteLine("Departamento: " + trabalhador.Department.Name);
            Console.WriteLine("Income for " + mesEAnno + ": " + 
            trabalhador.Income(ano, mes).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
