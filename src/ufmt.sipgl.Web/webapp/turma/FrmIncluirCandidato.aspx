<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmIncluirCandidato.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmIncluirCandidato" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddProjetoCursoUID" />
    <asp:HiddenField runat="server" ID="hddProjetoTurmaUID" />

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <fieldset style="padding: 10px">
        <legend>
            <img alt="Filtrar Registros" class="style2" src="../../media/images/ico_filters.png" />
            <span>Filtrar Registros</span>
        </legend>

        <asp:Panel ID="PanelFiltro" runat="server">
            <table class="Largura100Porcento">
                <tr>
                    <td class="LarguraFiltro">
                        <asp:Label ID="lbFiltroNome" runat="server">Nome:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LarguraFiltro">
                        <asp:Label ID="lbFiltroCPF" runat="server">CPF:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCPF"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LarguraFiltro"></td>

                    <td>
                        <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                            <span>Consultar</span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>

    <br />

    <asp:Panel ID="PanelAcoes" runat="server">
        <div class="addbutton" style="float: left; margin-right: 5px">
            <asp:HyperLink ID="lnkCadastrarDiscente" runat="server" CssClass="minibutton" SkinID="IncluirDiscente_CadastrarDiscente">
            <span>
                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Cadastrar Discente
            </span>
            </asp:HyperLink>
        </div>
        <div style="float: right">
            <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
        </div>
    </asp:Panel>

    <asp:GridView
        ID="GridViewPessoas"
        runat="server"
        AllowPaging="True"
        AutoGenerateColumns="False"
        OnPageIndexChanging="GridView1_PageIndexChanging"
        Width="100%"
        CssClass="mGrid"
        DataKeyNames="preMatriculaPessoaUID"
        PageSize="10"
        ShowHeaderWhenEmpty="true"
        OnRowDataBound="GridViewPessoas_RowDataBound">

        <Columns>
            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbPreMatriculaPessoaUID" runat="server" Text='<%# Eval("preMatriculaPessoaUID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbNome" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="25%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbCPF" runat="server" Text='<%# Eval("cpf") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkIncluirDiscente" runat="server" CommandName="lnkIncluirDiscente_Click" OnCommand="lnkIncluirDiscente_Click" CommandArgument='<%# Eval("preMatriculaPessoaUID") %>'>[ Incluir Candidato]</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>

        </Columns>
        <PagerTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div style="text-align: left">
                    <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                    <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                    <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" CssClass="espacamentoPaginador" />

                    <asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />

                    <span class="espacamentoPaginador">Página</span>

                    <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridViewPessoas.PageIndex + 1 %>"></asp:Label>

                    <span>de</span>

                    <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridViewPessoas.PageCount %>"></asp:Label>
                </div>
            </asp:Panel>
        </PagerTemplate>
        <EmptyDataTemplate>
            <div
                style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>
