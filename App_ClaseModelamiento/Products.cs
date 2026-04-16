using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ClaseModelamiento
{
    public class Products
    {
        private int id;
        private string name;
        private double price;
        private int amount;

        public Products(int id, string name, double price, int amount)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.amount = amount;
        }

        public Products()
        {
            this.id = 0;
            this.name = "NA";
            this.price = 0;
            this.amount = 0;
        }

        public int _Id
        {
            get{
                if (this.id > 0)
                {
                    return this.id;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value > 0)
                {
                    this.id=value;
                }
                else
                {
                    this.id = 0;
                }
            }
        }

        public string _Name{
             get
            { if(this.name != null)
                {
                    return this.name;
                }
                else
                {
                    return "NA";
                }
            }  
            set {
                if(value != null)
                {
                    this.name = value;
                }
                else
                {
                    this.name = "NA";
                }
            }
        }

        public double _Price
        {
            get { 
                if (this.price > 0)
                {
                    return this.price;
                }
                else
                {
                    return 0;
                }
            }
            set
            {

                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    this.price = 0;
                }
            }
               
        }

        public int _Amount
        {
            get {
                if (this.amount > 0)
                {
                    return this.amount;
                }
                else
                {
                    return 0;
                }
            
            }
            set
            {
                if (value > 0)
                {
                    this.amount=0;
                }
                else
                {
                    this.amount = 0;
                }
            }
        }
    }
}
