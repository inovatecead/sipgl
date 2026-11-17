<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.permissoes.FrmListar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div style="padding: 5px; text-align: left;">

                <h1>
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                </h1>

                <asp:GridView ID="GridView1"
                    runat="server"
                    AutoGenerateColumns="False"
                    Width="100%"
                    CssClass="mGrid"
                    OnRowDataBound="GridView1_RowDataBound"
                    PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbCodigo" runat="server" Text='<%# Eval("permissaoUID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbNome" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="85%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink ID="lnkVincularPermissoes" runat="server" NavigateUrl='<%# "~/webapp/permissoes/FrmListarRecursos.aspx?permissaoUID=" + Eval("permissaoUID") %>' ToolTip="Vincular Permissões aos Perfis" SkinID="MenuPermissoes_VincularPermissoes">[ Vincular Permissões]</asp:HyperLink>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>

                    </Columns>
                    <EmptyDataTemplate>
                        <div
                            style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                            <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
