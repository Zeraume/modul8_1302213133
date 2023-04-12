using modul8_1302213133;
internal class Program
{
    private static void Main(string[] args)
    {

        BankTransferConfig con = new BankTransferConfig();  

        if (con.config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else if (con.config.lang.Equals("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        string transfer = Console.ReadLine();
        int jumlahTransfer = (int) Convert.ToInt32(transfer);
        int biaya = 0;

        if(jumlahTransfer <= con.config.transfer.threshold)
        {
            biaya = con.config.transfer.low_fee;
        } else if (jumlahTransfer > con.config.transfer.threshold)
        {
            biaya = con.config.transfer.high_fee;
        }

        if (con.config.lang.Equals("en"))
        {
            Console.WriteLine("Transfer fee = " + biaya + " Total amount = " + (jumlahTransfer + biaya));
        } else if (con.config.lang.Equals("id"))
        {
            Console.WriteLine("Biaya transfer = " + biaya + " Total biaya  " + (jumlahTransfer + biaya));
        }

        if (con.config.lang.Equals("en"))
        {
            Console.WriteLine("Select transfer method: ");
        } else if (con.config.lang.Equals("id"))
        {
            Console.WriteLine("Pilih metode transfer: ");
        }

        for (int i = 0; i < con.config.methods.Count; i++)
        {
            Console.WriteLine((i + 1) + ", " + con.config.methods[i]);
        }

        Console.WriteLine("Pilih = "); ;
        string method = Console.ReadLine();
        int transferMethod = (int)Convert.ToInt32(transfer);

        if (con.config.lang.Equals("en"))
        {
            Console.WriteLine("Please type " + con.config.confirmation.en + " to confirm the transaction");
        } else if (con.config.lang.Equals("id")){
            Console.WriteLine("Ketik " + con.config.confirmation.id + " untuk mengkonfirmasi transaksi");
        }

        string confirm = Console.ReadLine();

        if (con.config.lang.Equals("en"))
        {
            if (confirm.Equals(con.config.confirmation.en))
            {
                Console.WriteLine("The transfer is completed");
            } else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        } else if (con.config.lang.Equals("id"))
        {
            if (confirm.Equals(con.config.confirmation.id))
            {
                Console.WriteLine("Prses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}