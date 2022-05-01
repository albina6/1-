using System;
using System.Collections.Generic;
using System.Text;

namespace _1лаб
{
    public class FunctionMembership//type 0
    {
        /*
        type 0 базовая функция
        type 1 Треугольная
        type 2 Трапецеидальная
        type 3 Z-образная
        type 4 S-образная
        
        */
        private string name;
        private double a, b;
        private double max = 1.0;
       // private ref Criterion parent;
        //public void Init
        public FunctionMembership()
        {
            name = "null";
            A = B = 100;
        }
        
        public FunctionMembership(string name, double[] options)
        {
            this.Name = name;
            this.Options(options);
        }

        public FunctionMembership(FunctionMembership alt)
        {
            this.Name = alt.Name;
            this.Options( alt.Options());
        }

        public FunctionMembership( string name,double a,double b)
        {
            this.name = name;
            this.A = a;
            this.B = b;
        }

        public virtual void Options(double[] options)
        {
            this.A = options[0];
            this.B = options[1];

        }

        public virtual double[] Options()
        {
            return new double[] { A, B };
        }
        public virtual FunctionMembership CreateCopy()
        {
            return new FunctionMembership(Name, A, B);
           
        }
        public virtual int GetType()
        {
            return 0;
        }
        public virtual string GetTypeSTR
        {
            get=> "Базовая функция";
        }
        public virtual double[] GetOptions()
        {
            double[] options = new double[] { 0, A, B };
            return options;

        }

        public virtual double GetY(double x)
        {
            // fun.GetY(x);
            return 100.0;
        }

        public double GetYNew(double x)
        {
            // fun.GetY(x);
            
            return Math.Min(GetY(x),max);
        }

        public double Max
        {
            get => max;
            set => max = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public double A
        {
            get => a;
            set => a= value;
        }
        public double B
        {
            get => b;
            set => b = value;
        }



    }
}
