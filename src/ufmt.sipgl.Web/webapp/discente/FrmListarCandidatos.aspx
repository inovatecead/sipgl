<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListarCandidatos.aspx.cs" Inherits="ufmt.sipgl.View.webapp.discente.FrmListarCandidatos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function showDialog(id) {
            $('.' + id).dialog("open");
        }

        function closeDialog(id) {
            $('.' + id).dialog("close");
        }
    </script>
</asp:Content>

<asp:Content ID="ContentListarCandidatos" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProjetoPoloCursoUID" runat="server" />

    <div style="padding: 5px; text-align: left;">

        <h1>
            <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
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

            <asp:Panel ID="PanelFiltro" runat="server">

                <table class="Largura100Porcento">
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lblNomeCandidato" runat="server" Style="font-weight: 700" Text="Nome do Candidato"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomeCandidato" runat="server" Width="503px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lblCPF" runat="server" Style="font-weight: 700" Text="CPF"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server" Width="90px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150"></td>
                        <td>
                            <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                               <span>Consultar</span>
                            </asp:LinkButton>

                            <asp:LinkButton ID="lnkMostrarTodos" runat="server" CssClass="minibutton" OnClick="lnkMostrarTodos_Click">
                               <span>Mostrar Todos</span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>

            </asp:Panel>

        </fieldset>

        <asp:Panel ID="PanelAcoes" runat="server" Style="padding: 10px">

            <div style="clear: both"></div>

            <div style="float: left; width: 300px; margin-left: 10px">
                <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>

            <div style="clear: both" />

        </asp:Panel>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" CssClass="mGrid"
            DataKeyNames="preMatriculaPessoaUID"
            OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCodigoCurso" runat="server" Text='<%# Eval("preMatriculaPessoaUID") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Eval("nome") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCpf" runat="server" Text='<%# Eval("CPF") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkInscreverCandidato" runat="server" NavigateUrl='<%# "~/webapp/discente/FrmInscricaoCandidato.aspx?projetoPoloCursoUID=" + hddProjetoPoloCursoUID.Value + "&preMatriculaPessoaUID=" + Eval("preMatriculaPessoaUID") %>'>Inscrever</asp:HyperLink>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

            </Columns>
            <PagerTemplate>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="cmdIr">
                    <div style="text-align: left">
                        <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False"
                            CommandArgument="First" CommandName="Page"
                            ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />
                        &nbsp;<asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False"
                            CommandArgument="Prev" CommandName="Page"
                            ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="cmdNext" runat="server"
                            CausesValidation="False" CommandArgument="Next" CommandName="Page"
                            ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" />
                        &nbsp;<asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False"
                            CommandArgument="Last" CommandName="Page"
                            ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />
                        &nbsp;&nbsp; Ir para a página
                        Ir para a página
                        <asp:TextBox ID="txtPagina" runat="server"
                            Text="<% # GridView1.PageIndex + 1 %>" ValidationGroup="grid" Width="29px"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="cmdIr" runat="server" ImageUrl="../../media/images/btnIr.gif"
                            OnClick="cmdIr2_Click" ValidationGroup="grid" />
                        <b>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtPagina" Display="Dynamic"
                                ErrorMessage="* Entre com um valor para continuar" Font-Bold="False"
                                ValidationGroup="grid"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtPagina" Display="Dynamic"
                                ErrorMessage="* Digite somente números para continuar" Font-Bold="False"
                                ValidationExpression="^[0-9]+$" ValidationGroup="grid">* Digite somente números* Digite somente números</asp:RegularExpressionValidator>
                        </b>
                    </div>
                    <div style="text-align: left">
                        Página&nbsp;Página&nbsp;<asp:Label ID="lblTotalPaginaAtual" runat="server"
                            Font-Bold="True" Text="<%# GridView1.PageIndex + 1 %>"></asp:Label>
                        &nbsp;de&nbsp;&nbsp;de&nbsp;<asp:Label ID="lblTotalPaginas" runat="server"
                            Text="<% # GridView1.PageCount %>"></asp:Label>
                        &nbsp;
                    </div>
                </asp:Panel>
            </PagerTemplate>
            <EmptyDataTemplate>
                <div
                    style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server"
                        Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>


