using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class Check
    {
        int id;
        DateTime date;
        double pay;
        List<ProductItem> products;

        public Check(int id, DateTime date, double pay, List<ProductItem> products)
        {
            this.id = id;
            this.date = date;
            this.pay = pay;
            this.products = products;
        }

        public void SaveToFile(string dir)
        {
            string path = $"{dir}\\Чек№{id}.txt";

            List<string> lines = new List<string>();
            lines.Add("\t\tЗоопарк");
            lines.Add($"\tКассовый чек №{id} от {date}");
            lines.Add("");
            double price = 0;
            foreach (var product in products)
            {
                price += product.price * product.count;
                lines.Add($"\t{product.name}\t-\t{product.price} x {product.count}");
            }
            lines.Add("");
            lines.Add($"Итого к оплате: {price}");
            lines.Add($"Внесено: {pay}");
            lines.Add($"Сдача: {pay - price}");

            File.WriteAllLines(path, lines.ToArray());
        }
    }
}
