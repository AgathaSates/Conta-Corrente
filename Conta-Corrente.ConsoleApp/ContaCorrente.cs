namespace ContaCorrente.ConsoleApp;

class ContaCorrente
{
    public int iD;
    public decimal saldo;
    public decimal lis = 0; //limite Saque
    public decimal LimiteTotalParaSaque;
    public string[] transacoes = new string[10];
    public int transacao;

    public ContaCorrente(decimal saldo)
    {
        GerarID iD = new GerarID();
        this.iD = iD.ObterID();
        this.saldo = saldo;
        lis = lis;
    }

    public void Saque(decimal valor)
    {
        valor = ExcedeuoLimitedeSaque(valor);
        saldo -= valor;
        transacoes[transacao++] = $"Saque de $ {valor}";
    }

    public void Deposito(decimal valor)
    {
        saldo += valor;
        transacoes[transacao++] = $"Depósito de $ {valor}";
    }

    public void TransferirParaOutraConta(ContaCorrente conta, decimal valor)
    {
        conta.saldo += valor;
        conta.transacoes[transacao++] = $"Recebido $ {valor} da conta {iD}";
        saldo -= valor;
        transacoes[transacao++] = $"Transferido $ {valor} para a conta {conta.iD}";
    }

    public void ConsultarSaldo()
    {
        Console.WriteLine($"---------Conta #{iD}--------");
        Console.WriteLine($"Seu saldo atual é: $ {saldo}");
    }

    public void Extrato()
    {
        Console.WriteLine($"-------- Extrato da Conta #{iD} --------");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("             Transações");
        Console.WriteLine("---------------------------------------");
        MostrarTransacoes();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"Saldo atual: {saldo}");
        Console.WriteLine("---------------------------------------");
    }

    private void MostrarTransacoes()
    {
        if (transacoes[0] == null)
            Console.WriteLine("Não foram registradas transações");
        else
            foreach (string transacao in transacoes)
            {
                if (transacao != null)
                    Console.WriteLine(transacao);
            }
    }

    public decimal LimitedeSaque()
    {
        LimiteTotalParaSaque = saldo + lis;
        return LimiteTotalParaSaque;
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
}
