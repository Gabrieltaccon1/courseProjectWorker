using System;
using System.Collections.Generic;
using System.Text;
using ENUMERACAO_EXERCICIO.Entities.Enums;

namespace ENUMERACAO_EXERCICIO.Entities
{
    class Worker
    {
        public string Nome { get; set; }
        public WorkerLevel Level { get; set; } // chamando a enumeração
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        // fazendo associação entre 2 classes diferentes

        //------------------------------------------------------------

        // criando lista de contratos para a classe trabalhador
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        // já fazendo sua instancia para que evite da lista ficar fazia


        //criando construtor padrão
        public Worker()
        {

        }


        // sempre que haver uma associação para muitos = * desmarcar do construtor pois ela pode ser vazia.
        public Worker(string nome, WorkerLevel level, double baseSalary, Departament departament)
        {
            Nome = nome;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        // implementando metodos 
        //         este metodo recebe um contrato e add o contrato dentro da lista de contratos

        public void AddContract(HourContract contract)
        // metodo recebe ^^
        {
            Contracts.Add(contract);
            //acessar a lista de contratos e add na lista o contrato que chegar como parametro de entrada
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }


        public double Income(int year, int month)
        {
            double sum = BaseSalary; 
            // pois o trabalhador de qualquer forma ganha esse salario
            // mesmo que no mes e ano não tenha nenhum contrato ele recebe sua base

            foreach (HourContract contract in Contracts)
             //para cada contrato de hora na lista de contratos 

            {
                if(contract.Date.Year == year && contract.Date.Month == month)

                    // se esse contrato da lista na data dele, se o ano do contrato for igual o ano que recebi de argumento
                    // e tambem o mes for igual a este mes
                    //significa que o contrato entraram na soma
                {
                    sum = sum + contract.TotalValue();

                    // soma recebe ela mesma + o valor total do contrato

                }

            }
            return sum;

        }


    }

}
