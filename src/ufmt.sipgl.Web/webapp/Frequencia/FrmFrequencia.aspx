<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmFrequencia.aspx.cs" Inherits="ufmt.sipgl.View.webapp.Frequencia.FrmFrequencia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
    <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <fieldset style="padding: 10px">
        <legend>Curso</legend>

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbCurso" runat="server" Style="font-weight: 700" Text="Curso:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCurso" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbTurma" runat="server" Style="font-weight: 700" Text="Turma:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTurma" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro">
                    <asp:Label runat="server" ID="Label1">Polo:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPolo" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="filtroEncontroPresencial_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPolo" ErrorMessage="Polo" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro">
                    <asp:Label runat="server" ID="Label2">Disciplina:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDisciplina" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="filtroEncontroPresencial_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDisciplina" ErrorMessage="Disciplina" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro">
                    <asp:Label runat="server" ID="Label3">Encontro:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEncontroPresencial" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlEncontroPresencial" ErrorMessage="Encontro" ForeColor="Red">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="LarguraFiltro"></td>
                <td>
                    <asp:LinkButton ID="lnkFiltrar" runat="server" CssClass="minibutton" OnClick="lnkFiltrar_Click">
                                    <asp:Label runat="server">Filtrar</asp:Label>
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
    </fieldset>

    <asp:Panel ID="panelDiscentes" runat="server">
        <fieldset style="padding: 10px">
            <legend>Discentes</legend>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDocentePrincipal" runat="server" Style="font-weight: 700" Text="Docente Principal:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocentePrincipal" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDocenteSecundario" runat="server" Style="font-weight: 700" Text="Docente Secundário:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocenteSecundario" runat="server" Width="500px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />

            <asp:Button runat="server" ID="gerarRelatorioPDF" OnClick="gerarRelatorioPDF_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Gerar Relatório (.pdf)" SkinID="Frequencia_GerarRelatorio" />

            <asp:GridView
                ID="GridViewFrequencia"
                runat="server"
                AllowPaging="false"
                AutoGenerateColumns="false"
                Width="100%"
                CssClass="mGrid"
                OnRowDataBound="GridViewFrequencia_RowDataBound"
                DataKeyNames="preMatriculaInscricaoUID"
                ShowHeaderWhenEmpty="true">

                <Columns>
                    <asp:TemplateField HeaderText="Discente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hddPreMatriculaInscricaoUID" runat="server" Value='<%# Eval("PreMatriculaInscricaoUID") %>' />

                            <asp:Label ID="lbDiscente" runat="server" Text='<%# Eval("NomeDiscente") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="50%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbCPF" runat="server" Text='<%# Eval("CPF") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Situação" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbSituacaoInscricao" runat="server" Text='<%# Eval("TipoSituacaoInscricao") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Presente?" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPresenca" runat="server" AppendDataBoundItems="true">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="10%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div
                        style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                        <asp:Label ID="lblMsgNenhumRegistro" runat="server"
                            Text="Nenhuma discente cadastrado neste polo para esta turma."></asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </fieldset>

        <div style="text-align: center;">
            <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="False" />
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" SkinID="Frequencia_Salvar"/>
        </div>
    </asp:Panel>
</asp:Content>
