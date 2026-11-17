<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.docente.FrmListar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        $('.mestre').live('click', function () {
            $(this).siblings('.detalhes').toggle(500);
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding: 5px; text-align: left;">
        <h1>
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

            <asp:Panel ID="PanelFiltro" runat="server" DefaultButton="lnkConsultar">

                <table>
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lbNome" runat="server">Nome:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="400px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lbCpf" runat="server">CPF:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LarguraFiltro"></td>
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

        <asp:Panel ID="PanelAcoes" runat="server">
            <div class="addbutton" style="float: left; margin-right: 5px">
                <asp:HyperLink ID="lnkCadastrarDocenteInterno" runat="server" CssClass="minibutton" SkinID="MenuDocentes_NovoDocenteInterno">
                    <span><img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Interno</span>
                </asp:HyperLink>

                <asp:HyperLink ID="lnkCadastrarDocenteExterno" runat="server" CssClass="minibutton" SkinID="MenuDocentes_NovoDocenteExterno">
                    <span><img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Externo</span>
                </asp:HyperLink>
            </div>

            <div style="float: right;">
                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>

            <div style="clear: both" />
            <asp:GridView
                ID="GridViewCorpoDocente"
                runat="server"
                AllowPaging="True"
                AutoGenerateColumns="False"
                CssClass="mGrid"
                DataKeyNames="projetoCorpoDocenteUID"
                OnPageIndexChanging="GridViewCorpoDocente_PageIndexChanging"
                OnRowDataBound="GridViewCorpoDocente_RowDataBound"
                Width="100%"
                PageSize="10"
                ShowHeaderWhenEmpty="true">

                <Columns>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblProjetoCorpoDocenteUID" runat="server" Text='<%# Eval("ProjetoCorpoDocenteUID") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Siape" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblSiape" runat="server" Text='<%# Eval("Siape") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a class="mestre" href="javascript:void(0);"><%# Eval("Nome")%></a>
                            <div class="detalhes"
                                style="display: none; background-color: #EBEBEB; color: Black; margin-top: 5px">
                                <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
                                <fieldset>
                                    <legend>Dados</legend>

                                    <span><b>Titulação:&nbsp;</b></span><%# Eval("DescricaoTipoTitulacao")%>
                                    <br />
                                    <span><b>E-mail:&nbsp;</b></span><%# Eval("Email")%>
                                    <br />
                                    <span><b>Celular:&nbsp;</b></span><%# Eval("Celular")%>
                                </fieldset>
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCpf" runat="server" Text='<%# Eval("Cpf") %>' Visible="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkEditarDocenteExterno" runat="server" NavigateUrl='<%# "~/webapp/docente/FrmEditarExterno.aspx?&projetoCorpoDocenteUID=" + Eval("projetoCorpoDocenteUID")%>' ToolTip="Editar Dados" SkinID="MenuDocentes_Editar">[ Editar ]</asp:HyperLink>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>

                </Columns>

                <PagerTemplate>
                    <asp:Panel ID="Panel2" runat="server">
                        <div style="text-align: left">
                            <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                            <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                            <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" CssClass="espacamentoPaginador" />

                            <asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />

                            <span class="espacamentoPaginador">Página</span>

                            <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridViewCorpoDocente.PageIndex + 1 %>"></asp:Label>

                            <span>de</span>

                            <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridViewCorpoDocente.PageCount %>"></asp:Label>
                        </div>
                    </asp:Panel>
                </PagerTemplate>

                <EmptyDataTemplate>
                    <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                        <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro disponível."></asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
