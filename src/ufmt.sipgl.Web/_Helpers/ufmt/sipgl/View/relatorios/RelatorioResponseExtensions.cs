using System.Web;

namespace ufmt.sipgl.View.relatorios;

/// <summary>
/// Substitui <c>StiReportResponse.PrintAsPdf</c> / <c>ResponseAsExcel2007</c>
/// (Stimulsoft) por escrita direta na resposta HTTP.
/// </summary>
public static class RelatorioResponseExtensions
{
    public static void EscreverPdf(this HttpResponse response, byte[] pdf, string nomeArquivo)
    {
        response.Clear();
        response.ContentType = "application/pdf";
        response.AddHeader("Content-Disposition", "inline; filename=" + nomeArquivo);
        response.BinaryWrite(pdf);
        response.End();
    }

    public static void EscreverExcel(this HttpResponse response, byte[] excel, string nomeArquivo)
    {
        response.Clear();
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.AddHeader("Content-Disposition", "attachment; filename=" + nomeArquivo);
        response.BinaryWrite(excel);
        response.End();
    }
}
