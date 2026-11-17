<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.encontroPresencial.FrmListar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
    <asp:HiddenField ID="hddProjetoDisciplinaUID" runat="server" />
    <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

    <div style="padding: 5px; text-align: left;">
        <h1>
            <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
            &nbsp;<asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </h1>
        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <fieldset style="padding: 10px">
            <legend>
                <img alt="Filtrar Registros" class="style2" src="../../media/images/ico_filters.png" />
                <span>Filtrar Registros</span>
            </legend>

            <table>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="Unidade Adm./Acadêmica:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUnidade" runat="server" AppendDataBoundItems="true" Width="20%">
                            <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="LarguraFiltro"></td>
                    <td>
                        <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                            <span>Consultar </span>
                        </asp:LinkButton>

                        <asp:LinkButton ID="lnkMostrarTodos" runat="server" CssClass="minibutton" OnClick="lnkMostrarTodos_Click">
                            <span>Mostrar Todos </span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </fieldset>

        <br />

        <asp:Panel ID="PanelAcoes" runat="server">

            <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton" SkinID="EncontroPresencial_NovoEncontro">
                <span>
                    <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; 
                    <asp:Label runat="server">Adicionar Registro</asp:Label>  
                </span>
            </asp:HyperLink>

            <div style="float: right;">
                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>

        </asp:Panel>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AutoGenerateColumns="False"
            Width="100%"
            CssClass="mGrid"
            DataKeyNames="projetoEncontroPresencialUID"
            PageSize="10"
            ShowHeaderWhenEmpty="true"
            OnRowDataBound="GridView1_RowDataBound">

            <Columns>
                <asp:TemplateField HeaderText="Código" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSigla" runat="server" Text='<%# Eval("projetoEncontroPresencialUID") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Turma" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("nomeTurma") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Unidade Adm./Acadêmica" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("identificacaoEndereco") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Data do Encontro" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# string.Format("{0:dd/MM/yyyy}", Eval("dataEncontro")) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Obrigatório?" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# (bool)Eval("isObrigatorio") == false ? "Não" : "Sim" %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkAtualizarRegistro" runat="server" NavigateUrl='<%# "~/webapp/encontroPresencial/FrmAlterar.aspx?projetoEncontroPresencialUID=" + Eval("projetoEncontroPresencialUID") + "&projetoDisciplinaUID=" + Eval("projetoDisciplinaUID") + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value%>' ToolTip="Editar Dados" SkinID="EncontroPresencial_Editar">[ Editar ]</asp:HyperLink>
                        <br />
                        <asp:LinkButton ID="lnkExcluirRegistro" runat="server" OnClientClick="return confirm('Deseja realmente excluir este registro?');" CommandName="projetoEncontroPresencialUID" CommandArgument='<%# Eval("projetoEncontroPresencialUID") %>'  OnClick="lnkExcluirRegistro_Click"  ToolTip="Excluir" SkinID="EncontroPresencial_Excluir">[ Excluir ]</asp:LinkButton>
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
