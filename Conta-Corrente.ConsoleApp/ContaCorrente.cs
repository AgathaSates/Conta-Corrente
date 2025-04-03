namespace ContaCorrente.ConsoleApp;

class ContaCorrente
{
    public int iD;
    public decimal saldo;
    public decimal lis = 200; //limite Saque
    public decimal LimiteTotalParaSaque;
    public string[] transacoes = new string[100];
    public int transacao;

    public ContaCorrente(decimal saldo)
    {
        GerarID iD = new GerarID();
        this.iD = iD.ObterID();
        this.saldo = saldo;
        lis = lis;
    }

    public decimal LimitedeSaque() 
    {
        LimiteTotalParaSaque = saldo + lis;
        return LimiteTotalParaSaque;
    }

    public void Saque(decimal valor)
    {
        valor = ExcedeuoLimitedeSaque(valor);
        saldo -= valor;
        transacoes[transacao++] = $" Saque de $ {valor}";
    }

    public decimal ExcedeuoLimitedeSaque(decimal valor)
    {
        while (valor > LimitedeSaque())
        {
            Console.WriteLine("Erro valor excede o saldo disponivel");
            Console.Write("digite um valor novamente:");
            valor = Convert.ToDecimal(Console.ReadLine());
        }

        return valor;
    }

    public void Deposito(decimal valor)
    {
        saldo += valor;
        transacoes[transacao++] = $" Déposito de $ {valor}";
    }

    public void ConsultarSaldo()
    {
        Console.WriteLine($"Seu saldo atual é: $ {saldo}");
    }

    public void TransferirParaOutraConta(ContaCorrente conta, decimal valor)
    {
        conta.saldo += valor;
        conta.transacoes[transacao++] = $"Recebeu {valor} de {iD}";
        saldo -= valor;
        transacoes[transacao++] = $"Transferido$ {valor} da conta {iD} para {conta.iD}";
       
    }

    public void Extrato()
    {
        Console.WriteLine("-------Tansações feitas----");
        
        foreach (string transacao in transacoes) 
        {
            if (transacao != null)          
                Console.WriteLine(transacao);
        }
        Console.WriteLine($"seu saldo: {saldo}");
    }
}
