using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module8_2211104008
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig config = BankTransferConfig.LoadConfig();

            Console.WriteLine("Maria Nathasya");
            Console.WriteLine(config.lang == "en" ?
                "Please insert the amount of money to transfer: " :
                "Masukkan jumlah uang yang akan di-transfer: ");

            int amount = int.Parse(Console.ReadLine());
            int fee = amount < config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
            int total = amount + fee;

            // Fee Output
            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {fee}");
                Console.WriteLine($"Total amount = {total}");
                Console.WriteLine("Select transfer method:");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {fee}");
                Console.WriteLine($"Total biaya = {total}");
                Console.WriteLine("Pilih metode transfer:");
            }

            // Print methods
            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }

            Console.ReadLine(); // Method selection input

            // Confirmation
            string confirmKeyword = config.lang == "en" ? config.confirmation.en : config.confirmation.id;
            Console.WriteLine(config.lang == "en" ?
                $"Type '{confirmKeyword}' to confirm the transaction: " :
                $"Ketik '{confirmKeyword}' untuk mengkonfirmasi transaksi:");

            string userConfirm = Console.ReadLine();

            if (userConfirm == confirmKeyword)
            {
                Console.WriteLine(config.lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine(config.lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
            }
        }
    }
}