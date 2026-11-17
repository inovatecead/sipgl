using System.Collections.Generic;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace ufmt.sipgl.View.relatorios;

/// <summary>
/// Gera os relatórios em PDF que antes eram produzidos pelo Stimulsoft Reports
/// (componente comercial, removido deste repositório público). Substitui o
/// antigo `.mrt` + <c>StiReport</c> por um documento construído em código com
/// PdfSharp/MigraDoc (MIT), mantendo o mesmo conteúdo: cabeçalho institucional,
/// linhas de contexto (rótulo: valor) e uma tabela de dados, com numeração de
/// página no rodapé.
/// </summary>
public static class RelatorioPdfBuilder
{
    public static byte[] Gerar(
        string titulo,
        IReadOnlyList<KeyValuePair<string, string>> cabecalho,
        IReadOnlyList<string> colunas,
        IReadOnlyList<string[]> linhas)
    {
        var document = new Document();
        document.Info.Title = titulo;

        var section = document.AddSection();
        section.PageSetup.Orientation = Orientation.Portrait;
        section.PageSetup.LeftMargin = "20mm";
        section.PageSetup.RightMargin = "15mm";
        section.PageSetup.TopMargin = "15mm";
        section.PageSetup.BottomMargin = "15mm";

        var topoCabecalho = section.Headers.Primary.AddParagraph();
        topoCabecalho.Format.Alignment = ParagraphAlignment.Center;
        topoCabecalho.AddFormattedText("Universidade Federal de Mato Grosso", TextFormat.Bold);
        topoCabecalho.AddLineBreak();
        topoCabecalho.AddText("Sistema de Pós-graduação Lato Sensu");

        var rodape = section.Footers.Primary.AddParagraph();
        rodape.Format.Alignment = ParagraphAlignment.Center;
        rodape.AddText("Página ");
        rodape.AddPageField();
        rodape.AddText(" de ");
        rodape.AddNumPagesField();

        var paragrafoTitulo = section.AddParagraph(titulo);
        paragrafoTitulo.Format.Font.Size = 14;
        paragrafoTitulo.Format.Font.Bold = true;
        paragrafoTitulo.Format.SpaceAfter = "4mm";

        foreach (var linhaCabecalho in cabecalho)
        {
            var paragrafo = section.AddParagraph();
            paragrafo.AddFormattedText(linhaCabecalho.Key + ": ", TextFormat.Bold);
            paragrafo.AddText(linhaCabecalho.Value ?? "");
        }

        if (cabecalho.Count > 0)
            section.AddParagraph().Format.SpaceAfter = "3mm";

        var tabela = section.AddTable();
        tabela.Borders.Width = 0.5;
        tabela.Borders.Color = Colors.Gray;

        foreach (var _ in colunas)
            tabela.AddColumn();

        var linhaCabecalhoTabela = tabela.AddRow();
        linhaCabecalhoTabela.Shading.Color = Colors.LightGray;
        linhaCabecalhoTabela.HeadingFormat = true;
        for (var i = 0; i < colunas.Count; i++)
        {
            var celula = linhaCabecalhoTabela.Cells[i].AddParagraph(colunas[i]);
            celula.Format.Font.Bold = true;
        }

        foreach (var linha in linhas)
        {
            var linhaTabela = tabela.AddRow();
            for (var i = 0; i < linha.Length && i < colunas.Count; i++)
                linhaTabela.Cells[i].AddParagraph(linha[i] ?? "");
        }

        var renderer = new PdfDocumentRenderer(unicode: true) { Document = document };
        renderer.RenderDocument();

        using var memoryStream = new MemoryStream();
        renderer.PdfDocument.Save(memoryStream, false);
        return memoryStream.ToArray();
    }
}
