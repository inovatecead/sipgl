<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListarPolos.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmListarPolos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
    <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

    <asp:UpdatePanel ID="upGeral" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
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

                <br />

                <asp:Panel ID="PanelAcoes" runat="server">
                    <div class="addbutton" style="float: left; margin-right: 5px">
                        <asp:HyperLink ID="lnkVincularPolos" runat="server" CssClass="minibutton" SkinID="VincularUnidades_VincularNovaUnidade">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Vincular Unidades
                            </span>
                        </asp:HyperLink>
                    </div>

                    <div style="float: right;">
                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
                    </div>
                </asp:Panel>

                <asp:GridView
                    ID="GridView1"
                    runat="server"
                    AutoGenerateColumns="False"
                    Width="100%"
                    CssClass="mGrid"
                    DataKeyNames="enderecoUID"
                    OnRowDataBound="GridView1_RowDataBound"
                    PageSize="100">

                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("enderecoUID")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Unidade" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbTipoUnidadeEnsino" runat="server" CssClass="mestre"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descrição" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("identificacaoEndereco")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Município" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("municipio")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Bairro" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("bairroEndereco")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rua" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("logradouro")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantidade de Vagas" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("quantidadeVagas")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink ID="lnkAtualizar" runat="server" NavigateUrl='<%# "FrmAlterarVinculoPolos.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") + "&enderecoUID=" + Eval("enderecoUID") %>' ToolTip="Atualizar/Detalhes do Polo" SkinID="VincularUnidades_Editar">[ Editar ]</asp:HyperLink>
                                    <br />
                                    <asp:LinkButton ID="lnkExcluirRegistro" runat="server" OnClientClick="return confirm('Deseja realmente excluir este registro?');" CommandName="lnkExcluir_Click" OnCommand="lnkExcluir_Click" CommandArgument='<%# Eval("enderecoUID") %>' SkinID="VincularUnidades_Excluir">[ Excluir ]</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
