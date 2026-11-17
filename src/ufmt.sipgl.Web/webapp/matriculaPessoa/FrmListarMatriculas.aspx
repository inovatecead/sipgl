<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListarMatriculas.aspx.cs" Inherits="ufmt.sipgl.View.webapp.matriculaPessoa.FrmListarMatriculas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:HiddenField runat="server" ID="hddPreMatriculaPessoaUID" />

    <div style="padding: 5px; text-align: left;">
        <h1>
            <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </h1>


        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nomeDiscente" runat="server" Width="30%" Enabled="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="CPF:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="CPF" runat="server" Width="30%" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridView1" runat="server"
            AllowPaging="True"
            AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            Width="100%"
            CssClass="mGrid"
            DataKeyNames="PreMatriculaPessoaUID"
            PageSize="10">

            <Columns>
                <asp:TemplateField HeaderText="Curso" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCurso" runat="server" Text='<%# Eval("cursoNome") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Polo" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPolo" runat="server" Text='<%# Eval("municipio") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data de Início" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDataInicio" runat="server" Text='<%# Eval("projetoTurmaDataInicio", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data de Fim" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblDataFim" runat="server" Text='<%# Eval("projetoTurmaDataFim", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Situação" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSituacao" runat="server" Text='<%# Eval("tipoSituacaoInscricaoNome") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Histórico Escolar" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="DownloadHistoricoEscolar" runat="server"  ImageUrl="~/media/images/download.png"  OnCommand="DownloadHistoricoEscolar_Command" CommandArgument='<%# Eval("preMatriculaInscricaoUID") %>' CommandName="preMatriculaInscricaoUID" ToolTip="Baixar Histórico" OnClientClick="window.document.forms[0].target='_blank';" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="15%" />
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

                        <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridView1.PageIndex + 1 %>"></asp:Label>

                        <span>de</span>

                        <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridView1.PageCount %>"></asp:Label>
                    </div>
                </asp:Panel>
            </PagerTemplate>

            <EmptyDataTemplate>
                <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
