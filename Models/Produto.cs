namespace API.Models;

public class Produto
{
    //Construtores
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public Produto
        (string nome, string descricao, 
        double valor)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    //Características - Atributos e propriedades
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }
    public int Quantidade { get; set; }
}