namespace ContaCorrente.ConsoleApp;

class GerarID
{
    public int iD;
    public int[] listaIDs = new int[100];
    public int iDs;

    public int ObterID() 
    {
        GerarIDAleatorio();
        IDJaExiste();
        AdicionarnaListadeID();

        return iD;
    }

    public void GerarIDAleatorio()
    {
        Random geraID = new();
        iD = geraID.Next(1000);     
    }

    public void IDJaExiste()
    {
        while (true)
        {
            if (listaIDs.Contains(iD))
               GerarIDAleatorio();
            else
                break;
        }
    }

    public void AdicionarnaListadeID()
    {
        listaIDs[iDs++] = iD;
    }

    public override string ToString()
    {
        return iD.ToString();
    }
}
