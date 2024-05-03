using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Produto produto = new Produto();
// produto.setNome("Bolacha");
produto.Nome = "Bolacha";
// Console.WriteLine(produto.getNome());
Console.WriteLine(produto.Nome);

List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto("Celular", "IOS", 4000));
produtos.Add(new Produto("Celular", "Android", 2500));
produtos.Add(new Produto("Televisão", "LG", 2000));
produtos.Add(new Produto("Notebook", "Avell", 5000));

//EndPoints - Funcionalidades
//GET: http://localhost:5225/
app.MapGet("/", () => "Minha primeira API em C# com watch");

//GET: http://localhost:5225/api/produto/listar
app.MapGet("/api/produto/listar", () =>
    produtos);

//GET: http://localhost:5225/api/produto/buscar/id_do_produto
app.MapGet("/api/produto/buscar/{id}", (string id) =>
{
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Id == id)
        {
            return Results.Ok(produtoCadastrado);
        }
    }
    // Produto não encontrado
    return Results.NotFound("Produto não encontrado!");
});

//POST: http://localhost:5225/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar",
    (Produto produto) =>
{
    //Adicionar o produto dentro da lista
    produtos.Add(produto);
    return Results.Created("", produto);
});
//DELETE: http://localhost:5225/api/produto/Deletar
app.MapDelete("/api/produto/deletear/{id}",

    ([FromRoute] String id,
    [FromServices] AppDataContext ctx) =>
 {
    Produto? produto = 
        ctx.Produtos.Find(id);
        if (produto == null)
        {
            return Results.NotFound("Produto não encontrado");
        }
       
        ctx.Produtos.Remove(produto);
        ctx.SaveChanges();
        return Results.Ok("Produto deletado com sucesso");

 });

//DELETE: http://localhost:5225/api/produto/Alterar
 app.MapPut("/api/produto/alterar/{id}",

    ([FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
 {
        if (produto == null)
        {
            return Results.NotFound("Produto não encontrado");
        }
         produto.Nome = produtoAlterado.Nome;
         produto.Descricao = produtoAlterado.Descricao;
         produto.Quantidade = produtoAlterado.Quantidade;
         produto.Valor = produtoAlterado.Valor;



        ctx.Produtos.Update(produto);
        ctx.SaveChanges();
        return Results.Ok("Produto deletado com sucesso");

 });

app.Run();

//1)Cadastrar um produto
//a) Pela URL
//b) Pelo corpo da requisiçao
//2) Remover um produto
//3) Alterar produto
