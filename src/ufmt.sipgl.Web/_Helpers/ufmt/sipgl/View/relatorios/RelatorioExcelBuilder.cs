using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;

namespace ufmt.sipgl.View.relatorios;

/// <summary>
/// Gera a exportação em Excel que antes era produzida pelo Stimulsoft Reports
/// (<c>StiReportResponse.ResponseAsExcel2007</c>). Substituído por ClosedXML (MIT).
/// </summary>
public static class RelatorioExcelBuilder
{
    public static byte[] Gerar(string tituloAba, IReadOnlyList<string> colunas, IReadOnlyList<string[]> linhas)
    {
        using var workbook = new XLWorkbook();
        var planilha = workbook.Worksheets.Add(tituloAba);

        for (var i = 0; i < colunas.Count; i++)
        {
            var celula = planilha.Cell(1, i + 1);
            celula.Value = colunas[i];
            celula.Style.Font.Bold = true;
        }

        for (var linha = 0; linha < linhas.Count; linha++)
        {
            for (var coluna = 0; coluna < linhas[linha].Length && coluna < colunas.Count; coluna++)
                planilha.Cell(linha + 2, coluna + 1).Value = linhas[linha][coluna];
        }

        planilha.Columns().AdjustToContents();

        using var memoryStream = new MemoryStream();
        workbook.SaveAs(memoryStream);
        return memoryStream.ToArray();
    }
}
