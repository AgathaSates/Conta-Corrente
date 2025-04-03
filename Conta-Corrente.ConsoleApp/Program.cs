namespace ContaCorrente.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        ContaCorrente conta1 = new(1000);
        ContaCorrente conta2 = new(300);

        conta1.Saque(200);
        conta1.Deposito(300);
        conta1.Deposito(500);
        conta1.Saque(200);
        conta1.TransferirParaOutraConta(conta2, 400);

        conta1.Extrato();
        Console.WriteLine();
        conta2.Extrato();        
    }
}
